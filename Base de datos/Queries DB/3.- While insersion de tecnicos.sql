-- Declarar tablas de variables para nombres y apellidos
DECLARE @Nombres TABLE (Nombre NVARCHAR(30))
DECLARE @Apellidos TABLE (Apellido NVARCHAR(30))

-- Insertar nombres y apellidos comunes
INSERT INTO @Nombres VALUES 
('Juan'), ('Carlos'), ('Miguel'), ('Pedro'), ('Jos�'),
('Antonio'), ('Francisco'), ('Luis'), ('Javier'), ('Manuel')

INSERT INTO @Apellidos VALUES 
('Garc�a'), ('Rodr�guez'), ('Mart�nez'), ('L�pez'), ('Gonz�lez'),
('P�rez'), ('S�nchez'), ('Ram�rez'), ('Torres'), ('Hern�ndez')

-- Variables para el bucle
DECLARE @Contador INT = 1
DECLARE @TotalRegistros INT = 10

-- Obtener el n�mero total de cuadrillas
DECLARE @TotalCuadrillas INT
SELECT @TotalCuadrillas = COUNT(*) FROM Cuadrilla

WHILE @Contador <= @TotalRegistros
BEGIN
    -- Seleccionar un nombre y apellido aleatorio
    DECLARE @Nombre NVARCHAR(30), @Apellido NVARCHAR(30)
    
    SELECT TOP 1 @Nombre = Nombre 
    FROM @Nombres ORDER BY NEWID()
    
    SELECT TOP 1 @Apellido = Apellido 
    FROM @Apellidos ORDER BY NEWID()

    -- Generar un n�mero de t�cnico aleatorio
    DECLARE @NumTecnico NVARCHAR(20) = CAST(FLOOR(RAND() * 900000 + 100000) AS NVARCHAR(6));

    -- Seleccionar una CuadrillaID aleatoria
    DECLARE @CuadrillaID INT = CAST(RAND() * 5 AS INT) + 1

    -- Insertar un nuevo registro en la tabla TecnicoInstalador
    INSERT INTO TecnicoInstalador (Nombre, Apellido, NumTecnico, CuadrillaID)
    VALUES (
        @Nombre,
        @Apellido,
        @NumTecnico,
        @CuadrillaID
    )
    
    SET @Contador = @Contador + 1
END

GO