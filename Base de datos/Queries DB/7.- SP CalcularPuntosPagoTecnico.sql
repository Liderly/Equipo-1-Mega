CREATE PROCEDURE sp_CalcularPuntosPagoTecnico
	@NumTecnicoInstalador INT
AS
BEGIN
    SET NOCOUNT ON;

    WITH PuntosTecnicos AS (
        SELECT
            TI.NumTecnico,
            TI.Nombre + ' ' + TI.Apellido AS NombreTecnico,
            C.NumCuadrilla AS Cuadrilla,
            T.Descripcion AS TrabajoRealizado,
            S.NombreServicio AS Servicio,
            CASE WHEN e.Nombre = 'Instalado' THEN PT.Valor ELSE 0 END AS PuntosGenerados,
            SUM(CASE WHEN e.Nombre = 'Instalado' THEN PT.Valor ELSE 0 END)
                OVER (PARTITION BY C.NumCuadrilla, TI.TecnicoInstaladorID) AS TotalPuntosPorTecnico,
            e.Nombre AS Estatus,
            CL.NumCliente AS NumSuscriptor,
            CL.Nombre + ' ' + CL.Apellido AS NombreSuscriptor,
            OT.FechaCreacion AS Fecha
        FROM OrdenesTrabajo OT
        INNER JOIN Clientes CL ON OT.ClienteID = CL.ClienteID
        INNER JOIN Cuadrilla C ON OT.CuadrillaID = C.CuadrillaID
        INNER JOIN TecnicoInstalador TI ON C.CuadrillaID = TI.CuadrillaID
        INNER JOIN Trabajos T ON OT.TrabajoID = T.TrabajoID
        INNER JOIN Servicios S ON OT.ServicioID = S.ServicioID
        INNER JOIN PuntosTrabajo PT ON T.PuntosTrabajoID = PT.PuntosTrabajoID
        INNER JOIN Estatus e ON e.EstatusID = OT.EstatusID
		WHERE TI.NumTecnico = @NumTecnicoInstalador
    )
    SELECT
        PT.*,
        PP.Valor AS ValorPago
    FROM PuntosTecnicos PT
    LEFT JOIN RangoPuntos RP ON PT.TotalPuntosPorTecnico >= RP.RangoInicio
        AND (PT.TotalPuntosPorTecnico <= RP.RangoFin OR RP.RangoFin IS NULL)
    LEFT JOIN PagoPuntos PP ON RP.PagoPuntosID = PP.PagoPuntosID
    ORDER BY PT.Cuadrilla, PT.Fecha DESC;
END

EXEC sp_CalcularPuntosPagoTecnico @NumTecnicoInstalador = 374123;