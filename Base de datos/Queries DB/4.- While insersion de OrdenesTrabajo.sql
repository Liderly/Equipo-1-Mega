DECLARE @Counter INT = 1;

WHILE @Counter <= 4
BEGIN
    INSERT INTO OrdenesTrabajo (ClienteID, CuadrillaID, TrabajoID, ServicioID, EstatusID, FechaFinalizacion)
    VALUES (
        -- ClienteID (1-16)
        FLOOR(RAND() * 16) + 1,
        
        -- CuadrillaID (1-5)
        FLOOR(RAND() * 5) + 1,
        
        -- TrabajoID (1-4)
        FLOOR(RAND() * 4) + 1,
        
        -- ServicioID (1-7)
        FLOOR(RAND() * 7) + 1,
        
        -- EstatusID (1-3)
        FLOOR(RAND() * 3) + 1,

        -- FechaFinalización: suma un número aleatorio de días (1-8) a la fecha actual
        DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 8 + 1, GETDATE())
    );

    SET @Counter = @Counter + 1;
END;