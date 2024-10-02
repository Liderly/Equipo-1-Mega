-- Declarar tablas de variables para nombres y apellidos, son tablas temporales que utilizaran solo en este while
DECLARE @Nombres TABLE (Nombre NVARCHAR(30))
DECLARE @Apellidos TABLE (Apellido NVARCHAR(30))
DECLARE @Domicilios TABLE (Domicilio NVARCHAR(30))

-- Insertar nombres y apellidos comunes
INSERT INTO @Nombres VALUES 
('Juan'), ('Emmanuel'), ('Aldair'), ('Jesus'), ('Miguel'), 
('Angel'), ('Pedro'), ('Moises'), ('José'), ('Ruben')

INSERT INTO @Apellidos VALUES 
('García'), ('Rodríguez'), ('Martínez'), ('López'), ('González'), 
('Pérez'), ('Sánchez'), ('Ramírez'), ('Torres'), ('Flores')

INSERT INTO @Domicilios VALUES
('Avenida Siempreviva'), ('P.Sherman'), ('Privet Drive'), ('Baker Street'), ('Grimmauld Place'),
('Calle Alga'), ('Spooner Street'), ('Calle Wallaby'), ('Calle Maple'), ('Calle del Sol') 

DECLARE @Contador INT = 1 --Se declara el contador

WHILE @Contador <= 10 --Cantidad de registros a insertar
BEGIN

--Declración de variables que se utilizaran
DECLARE @Nombre NVARCHAR(30), @Apellido NVARCHAR(30), @Domicilio NVARCHAR(30)

-- Seleccionar un nombre, apellido y domicilio aleatorio
SELECT TOP 1 @Nombre = Nombre 
FROM @Nombres ORDER BY NEWID() --NEWID() funciona para crear selecciones aleatorias y ordenar estos datos por esas selecciones, el selec TOP 1 funciona para seleccionar el primer registro de esa tabla
    
SELECT TOP 1 @Apellido = Apellido 
FROM @Apellidos ORDER BY NEWID()

SELECT TOP 1 @Domicilio = Domicilio
FROM @Domicilios ORDER BY NEWID()

-- Generar NumCliente con al menos 4 dígitos
DECLARE @NumCliente INT = @Contador + 1000

-- Insertar un nuevo registro en la tabla Clientes
INSERT INTO Clientes (NumCliente, Nombre, Apellido, Domicilio, Telefono)
VALUES (
	@NumCliente,
        @Nombre,
        @Apellido,
        'Calle ' + @Domicilio + ' ' + CAST(@Contador AS NVARCHAR(2)), --
	CAST(ABS(CHECKSUM(NEWID())) % 10000000000 AS VARCHAR(10))
)
    
SET @Contador = @Contador + 1
END

GO