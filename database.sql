-- CREAR LA BASE DE DATOS
CREATE DATABASE POKEMON_PROYECT;
GO

-- USAR LA BASE CREADA
USE POKEMON_PROYECT;
GO

-- TABLA: Roles
CREATE TABLE Roles (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(50) NOT NULL
);

-- INSERTAR DATOS EN LA TABLA Roles
INSERT INTO Roles (Nombre) VALUES 
('Entrenador'),
('Administrador'),
('Enfermero'),
('Jugador'),
('Analista'),
('Desarrollador'),
('Moderador'),
('Visitante'),
('Líder de equipo'),
('Instructor'),
('Médico'),
('Cuidador'),
('Veterinario'),
('Organizador'),
('Asistente');
GO

-- TABLA: Usuarios
CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    RolId INT NOT NULL,
    Usuario NVARCHAR(50) NOT NULL,
    Contraseña VARBINARY(256) NOT NULL,
    Nombre NVARCHAR(100) NOT NULL,
    CONSTRAINT FK_Usuarios_Roles FOREIGN KEY (RolId) REFERENCES Roles(Id)
);

-- INSERTAR DATOS EN LA TABLA Usuarios
INSERT INTO Usuarios (RolId, Usuario, Contraseña, Nombre) VALUES 
(1, 'AshKetchum', HASHBYTES('SHA2_256', 'password1'), 'Ash Ketchum'),
(1, 'Misty', HASHBYTES('SHA2_256', 'password2'), 'Misty Waterflower'),
(1, 'Brock', HASHBYTES('SHA2_256', 'password3'), 'Brock Harrison'),
(2, 'Oak', HASHBYTES('SHA2_256', 'password4'), 'Professor Oak'),
(2, 'Jenny', HASHBYTES('SHA2_256', 'password5'), 'Officer Jenny'),
(3, 'NurseJoy', HASHBYTES('SHA2_256', 'password6'), 'Nurse Joy'),
(4, 'Gary', HASHBYTES('SHA2_256', 'password7'), 'Gary Oak'),
(5, 'Tracey', HASHBYTES('SHA2_256', 'password8'), 'Tracey Sketchit'),
(6, 'Red', HASHBYTES('SHA2_256', 'password9'), 'Red'),
(7, 'Blue', HASHBYTES('SHA2_256', 'password10'), 'Blue'),
(8, 'Green', HASHBYTES('SHA2_256', 'password11'), 'Green'),
(9, 'Daisy', HASHBYTES('SHA2_256', 'password12'), 'Daisy Oak'),
(10, 'Silver', HASHBYTES('SHA2_256', 'password13'), 'Silver'),
(11, 'Giovanni', HASHBYTES('SHA2_256', 'password14'), 'Giovanni'),
(12, 'Lorelei', HASHBYTES('SHA2_256', 'password15'), 'Lorelei');
GO

-- TABLA: Pokemon
CREATE TABLE Pokemon (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(50) NOT NULL,
    Tipo NVARCHAR(50) NOT NULL,
    Debilidad NVARCHAR(50),
    Evolucion NVARCHAR(50),
    Peso DECIMAL(5, 2),
    Numero INT NOT NULL
);

-- INSERTAR DATOS EN LA TABLA Pokemon
INSERT INTO Pokemon (Nombre, Tipo, Debilidad, Evolucion, Peso, Numero) VALUES 
('Pikachu', 'Eléctrico', 'Tierra', 'Raichu', 6.00, 25),
('Bulbasaur', 'Planta/Veneno', 'Fuego', 'Ivysaur', 6.90, 1),
('Charmander', 'Fuego', 'Agua', 'Charmeleon', 8.50, 4),
('Squirtle', 'Agua', 'Eléctrico', 'Wartortle', 9.00, 7),
('Jigglypuff', 'Normal/Hada', 'Acero', 'Wigglytuff', 5.50, 39),
('Meowth', 'Normal', 'Lucha', 'Persian', 4.20, 52),
('Psyduck', 'Agua', 'Eléctrico', 'Golduck', 19.60, 54),
('Machop', 'Lucha', 'Psíquico', 'Machoke', 19.50, 66),
('Geodude', 'Roca/Tierra', 'Agua', 'Graveler', 20.00, 74),
('Eevee', 'Normal', 'Lucha', 'Vaporeon', 6.50, 133),
('Snorlax', 'Normal', 'Lucha', NULL, 460.00, 143),
('Mewtwo', 'Psíquico', 'Bicho', NULL, 122.00, 150),
('Pidgey', 'Normal/Volador', 'Eléctrico', 'Pidgeotto', 1.80, 16),
('Rattata', 'Normal', 'Lucha', 'Raticate', 3.50, 19),
('Abra', 'Psíquico', 'Fantasma', 'Kadabra', 19.50, 63);
GO
