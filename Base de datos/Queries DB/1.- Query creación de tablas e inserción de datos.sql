CREATE DATABASE TestHackaton
GO

USE TestHackaton
GO

CREATE TABLE Clientes(
ClienteID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
NumCliente INT NOt NULL,
Nombre NVARCHAR(30) NOT NULL,
Apellido NVARCHAR(30) NOT NULL,
Domicilio NVARCHAR(50) NOT NULL,
Telefono NVARCHAR(20) NULL
);
GO

CREATE TABLE Servicios(
ServicioID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
NombreServicio NVARCHAR(30) NOT NULL
);
GO

CREATE TABLE Cuadrilla(
CuadrillaID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
NumCuadrilla INT NOT NULL
);
GO

CREATE TABLE TecnicoInstalador(
TecnicoInstaladorID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
Nombre NVARCHAR(30) NOT NULL,
Apellido NVARCHAR(30) NOT NULL,
NumTecnico NVARCHAR(20) NOT NULL,
CuadrillaID INT NOT NULL
FOREIGN KEY (CuadrillaID) REFERENCES Cuadrilla(CuadrillaID)
);
GO

CREATE TABLE PagoPuntos(
PagoPuntosID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
Valor INT NOT NULL
);
GO

CREATE TABLE PuntosTrabajo(
PuntosTrabajoID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
Valor INT NOT NULL
);
GO

CREATE TABLE Trabajos(
TrabajoID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
Descripcion NVARCHAR(50) NOT NULL,
PuntosTrabajoID INT,
FOREIGN KEY (PuntosTrabajoID) REFERENCES PuntosTrabajo(PuntosTrabajoID),
);
GO

CREATE TABLE Estatus(
EstatusID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
Nombre NVARCHAR(30) NOT NULL
);
GO

CREATE TABLE OrdenesTrabajo (
OrdenTrabajoID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
ClienteID INT NOT NULL,
CuadrillaID INT NOT NULL,
TrabajoID INT NOT NULL,
ServicioID INT NOT NULL,
EstatusID INT NOT NULL,
FechaCreacion DATETIME DEFAULT GETDATE(),
FechaFinalizacion DATETIME,
FOREIGN KEY (ClienteID) REFERENCES Clientes(ClienteID),
FOREIGN KEY (TrabajoID) REFERENCES Trabajos(TrabajoID),
FOREIGN KEY (CuadrillaID) REFERENCES Cuadrilla(CuadrillaID),
FOREIGN KEY (EstatusID) REFERENCES Estatus(EstatusID),
FOREIGN KEY (ServicioID) REFERENCES Servicios(ServicioID)
);
GO

CREATE TABLE RangoPuntos (
RangoInicio INT NOT NULL,
RangoFin INT NULL,
PagoPuntosID INT NOT NULL,
FOREIGN KEY (PagoPuntosID) REFERENCES PagoPuntos(PagoPuntosID),
);
GO

---Inserts en tabla Clientes
INSERT INTO Clientes (NumCliente, Nombre, Apellido, Domicilio, Telefono) 
VALUES 
(1250, 'Juan', 'P�rez', 'Calle Falsa 123', '3325551234'),
(1251, 'Mar�a', 'G�mez', 'Avenida Siempre Viva 456', '3515555678'),
(1252, 'Carlos', 'Rodr�guez', 'Boulevard de los Sue�os 789', '3335558765');
GO

---Inserts en tabla Servicios
INSERT INTO Servicios (NombreServicio) 
VALUES 
('TV basico'),
('TV conecta'),
('Internet Residencial 1 GB'),
('Internet Residencial 500MB'),
('Internet Residencial 200 MB'),
('Telefon�a Fija Ilimitada'),
('Telefon�a m�vil paquete 300'),
('Telefon�a m�vil paquete 200'),
('Sin Servicio')
GO

---Interts en Tabla Cuadrilla
INSERT INTO Cuadrilla (NumCuadrilla) 
VALUES 
(1),
(2),
(3),
(4),
(5);
GO

---Insert en tabla Tecnicos
INSERT INTO TecnicoInstalador (Nombre, Apellido, NumTecnico, CuadrillaID) 
VALUES 
('Luis', 'Fern�ndez', '374123', 1),
('Josue', 'Mart�nez', '737456', 2),
('Pedro', 'S�nchez', '737789', 3),
('Pomelo', 'Ochoa', '737628', 1),
('Saturnino', 'S�nchez', '729011', 2),
('Moises', 'Medina', '719477', 3)
GO

---Insert en tabla PagoPuntos
INSERT INTO PagoPuntos (Valor) 
VALUES 
(0),
(300),
(500),
(650)
GO

---Insert en tabla PuntosTrabajo
INSERT INTO PuntosTrabajo (Valor) 
VALUES 
(50),
(40),
(33), 
(20),
(10)
GO

---Insert en tabla Trabajos
INSERT INTO Trabajos (Descripcion, PuntosTrabajoID) 
VALUES 
('Instalaci�n de acometida', 1),
('Instalaci�n de equipo', 2),
('Cambio de lugar', 3),
('Instalaci�n de servicio', 4)
GO

---Insert en tabla Estatus
INSERT INTO Estatus (Nombre) 
VALUES 
('Pendiente de instalar'),
('Instalado'),
('Cancelado');
GO

---Inserts en tabla RangoPuntos
INSERT INTO RangoPuntos (RangoInicio, RangoFin, PagoPuntosID) 
VALUES
(0, 80, 1),
(81, 150, 2),
(151, 210, 3),
(211, NULL, 4);

---Insert en tabla OrdenesTrabajo
INSERT INTO OrdenesTrabajo(ClienteID,CuadrillaID,TrabajoID,ServicioID,EstatusID,FechaFinalizacion)
VALUES 
(3, 1, 1, 7, 2, DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 8 + 1, GETDATE())),
(13, 1, 3, 7, 2, DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 8 + 1, GETDATE())),
(10, 1, 2, 7, 1, DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 8 + 1, GETDATE())),
(1, 1, 1, 7, 1, DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 8 + 1, GETDATE())),
(2, 1, 4, 3, 3, DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 8 + 1, GETDATE())),

(5, 2, 1, 7, 2, DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 8 + 1, GETDATE())),
(7, 2, 1, 7, 2, DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 8 + 1, GETDATE())),
(11, 2, 4, 2, 2, DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 8 + 1, GETDATE())),
(4, 2, 4, 5, 2, DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 8 + 1, GETDATE())),
(6, 2, 3, 7, 1,DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 8 + 1, GETDATE())),
(3, 2, 2, 7, 3, DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 8 + 1, GETDATE())),

(15, 3, 1, 7, 2, DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 8 + 1, GETDATE())),
(14, 3, 1, 7, 2, DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 8 + 1, GETDATE())),
(16, 3, 1, 7, 2, DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 8 + 1, GETDATE())),
(7, 3, 4, 1, 2, DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 8 + 1, GETDATE())),
(5, 3, 4, 5, 2, DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 8 + 1, GETDATE())),
(2, 1, 4, 3, 2, DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 8 + 1, GETDATE())),
(3, 3, 2, 7, 2, DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 8 + 1, GETDATE())),

(12, 4, 1, 7, 2, DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 8 + 1, GETDATE())),
(8, 4, 1, 7, 2, DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 8 + 1, GETDATE())),
(9, 4, 1, 7, 2, DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 8 + 1, GETDATE())),
(12, 4, 2, 7, 2, DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 8 + 1, GETDATE())),
(8, 4, 2, 7, 2, DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 8 + 1, GETDATE())),
(9, 4, 2, 7, 2, DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 8 + 1, GETDATE())),
(12, 4, 4, 5, 2, DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 8 + 1, GETDATE())),
(8, 4, 4, 4, 2, DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 8 + 1, GETDATE())),
(9, 4, 4, 3, 2, DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 8 + 1, GETDATE())),
(2, 4, 3, 7, 1, DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 8 + 1, GETDATE())),

(15, 5, 2, 7, 2, DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 8 + 1, GETDATE())),
(14, 5, 2, 7, 2, DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 8 + 1, GETDATE())),
(3, 5, 2, 7, 2, DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 8 + 1, GETDATE())),
(5, 5, 2, 7, 2, DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 8 + 1, GETDATE())),
(7, 5, 2, 7, 1, DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 8 + 1, GETDATE())),
(15, 5, 2, 7, 1, DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 8 + 1, GETDATE())),
(14, 5, 2, 7, 1, DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 8 + 1, GETDATE())),
(16, 5, 2, 7, 1, DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 8 + 1, GETDATE()))
GO