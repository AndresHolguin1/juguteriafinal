CREATE DATABASE Jugueteriah
GO
USE Jugueteriah
GO

CREATE TABLE Permisos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(50),
    Img NVARCHAR(225) DEFAULT 'imagenes\3.jpg'
);

CREATE TABLE Roles (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(50),
    Img NVARCHAR(225) DEFAULT 'imagenes\20250525_0417_image.png'
);

CREATE TABLE Auditoria (
    Id INT PRIMARY KEY IDENTITY(1,1), 
    Tabla VARCHAR(255) NOT NULL,
    Accion VARCHAR(255) NOT NULL,
    LlavePrimaria VARCHAR(255) NOT NULL,
    Cambios VARCHAR(255) NOT NULL,
    Fecha DATETIME NOT NULL,
    Usuario VARCHAR(255) NULL
);

CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(50),
    Correo NVARCHAR(100),
    Direccion NVARCHAR(100),
    RolId INT,
    FOREIGN KEY (RolId) REFERENCES Roles(Id),
	Clave NVARCHAR(150),
    Img NVARCHAR(225) DEFAULT 'imagenes\20250525_0408_image.png'
);

CREATE TABLE Empleados (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(50),
    Correo NVARCHAR(100),
    Cargo NVARCHAR(100),
    Telefono NVARCHAR(100),
	roles int,
	Foreign Key(roles) references Roles(Id),
    Img NVARCHAR(225) DEFAULT 'imagenes\20250525_0410_image.png'
);

CREATE TABLE Estantes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Ubicacion NVARCHAR(50),
    Seccion NVARCHAR(50),
    Img NVARCHAR(225) DEFAULT 'imagenes\20250525_0408_image.png'
);

CREATE TABLE Juguetes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(50),
    Descripcion NVARCHAR(50),
    Precio DECIMAL(10,2),
    Stock INT,
    Estantes INT,
    FOREIGN KEY (Estantes) REFERENCES Estantes(Id),
    Img NVARCHAR(225) DEFAULT 'imagenes\4df467d319257597d4d3108772b756df.png'
);

CREATE TABLE Ventas (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Fecha DATE,
    Total DECIMAL(10,2),
    Usuarios INT,
    Empleados INT,
    FOREIGN KEY (Usuarios) REFERENCES Usuarios(Id),
    FOREIGN KEY (Empleados) REFERENCES Empleados(Id),
    Img NVARCHAR(225) DEFAULT 'imagenes\20250525_0419_image.png'
);

CREATE TABLE Proveedores (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(50),
    Correo NVARCHAR(100),
    Direccion NVARCHAR(100),
    Telefono NVARCHAR(100),
    Img NVARCHAR(225) DEFAULT 'imagenes\proveedores-e1663621176409.jpeg'
);

CREATE TABLE Pedidos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Fecha DATE,
    Proveedores INT,
    Empleados INT,
    FOREIGN KEY (Proveedores) REFERENCES Proveedores(Id),
    FOREIGN KEY (Empleados) REFERENCES Empleados(Id),
    Img NVARCHAR(225) DEFAULT 'imagenes\gestion-de-pedidos1.jpg'
);

CREATE TABLE DetallesVenta (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Cantidad INT,
    PrecioUnitario DECIMAL(10,2),
    Ventas INT,
    Juguetes INT,
    FOREIGN KEY (Ventas) REFERENCES Ventas(Id),
    FOREIGN KEY (Juguetes) REFERENCES Juguetes(Id),
    Img NVARCHAR(225) DEFAULT 'imagenes\20250525_0419_image (1).png'
);

-- INSERTS

INSERT INTO Roles (Nombre) VALUES
('Usuario'), ('Administrador');

INSERT INTO Usuarios (Nombre, Correo, Direccion,Clave, RolId) VALUES
('Rodolfo','rodol@gmail.com','calle2324','123', 1),
('Antonio','Antonio@gmail.com','calle9324','123', 2);


INSERT INTO Empleados (Nombre, Correo, Cargo, Telefono,roles) VALUES
('Rene','renel@mail.com','Comercializador','123',1),
('Marin','Marin@mail.com','Lider','103',2);


INSERT INTO Estantes (Ubicacion, Seccion) VALUES
('A','A5'), ('B','B5'), ('C','C5');

INSERT INTO Juguetes (Nombre, Descripcion, Precio, Stock, Estantes) VALUES
('Pikachu', 'Agua', 49.5, 12, 1),
('Naruto', 'Ninja', 55.5, 32, 2),
('Goku', 'Sajayin', 99.5, 14, 3);

INSERT INTO Ventas (Fecha, Total, Usuarios, Empleados) VALUES
(GETDATE(),100.0,1,1),
(GETDATE(),200.0,2,2);


INSERT INTO Proveedores (Nombre, Correo, Direccion, Telefono) VALUES
('Andres','Anftl@gmail.com','calle04','19234'),
('Samuel','Sam@gmail.com','calle90','0234'),
('Luis','Lui@gmail.com','calle70','1254');

INSERT INTO Pedidos (Fecha, Proveedores, Empleados) VALUES
(GETDATE(),1,1),
(GETDATE(),2,2),
(GETDATE(),3,3);

INSERT INTO DetallesVenta (Cantidad, PrecioUnitario, Ventas, Juguetes) VALUES
(32,93.4,1,1),
(92,29.4,2,2),
(112,83.4,3,3);

INSERT INTO Permisos (Nombre) VALUES
('Permiso1'), ('Permiso2'), ('Permiso3');
