/*
Plantilla de script posterior a la implementación							
--------------------------------------------------------------------------------------
 Este archivo contiene instrucciones de SQL que se anexarán al script de compilación.		
 Use la sintaxis de SQLCMD para incluir un archivo en el script posterior a la implementación.			
 Ejemplo:      :r .\miArchivo.sql								
 Use la sintaxis de SQLCMD para hacer referencia a una variable en el script posterior a la implementación.		
 Ejemplo:      :setvar TableName miTabla							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
-- Insertar Roles
INSERT INTO Roles (Nombre, Estado, IdUsuarioCreador, FechaCreacion)
VALUES 
    ('Administrador', 1, 1, GETDATE()),
    ('Soporte', 1, 1, GETDATE()),
    ('Cliente', 1, 1, GETDATE());

-- Insertar Categorías de Tickets
INSERT INTO Categorias (Nombre, Estado, IdUsuarioCreador, FechaCreacion)
VALUES 
    ('Soporte Técnico de Computadoras', 1, 1, GETDATE()),
    ('Soporte Técnico de Sistemas', 1, 1, GETDATE());

-- Insertar Prioridades
INSERT INTO Prioridades (Nombre, Estado, IdUsuarioCreador, FechaCreacion)
VALUES 
    ('Baja', 1, 1, GETDATE()),
    ('Media', 1, 1, GETDATE()),
    ('Alta', 1, 1, GETDATE()),
    ('Crítica', 1, 1, GETDATE());

-- Insertar Estados de Ticket
INSERT INTO Estados (Nombre, Estado, IdUsuarioCreador, FechaCreacion)
VALUES 
    ('Abierto', 1, 1, GETDATE()),
    ('En proceso', 1, 1, GETDATE()),
    ('Cerrado', 1, 1, GETDATE());

-- Insertar Usuario Master (Administrador)
INSERT INTO Usuarios (Nombre, Email, Contraseña, IdRol, Estado, IdUsuarioCreador, FechaCreacion)
VALUES 
    ('admin', 'admin@example.com', '123', 
    (SELECT Id FROM Roles WHERE Nombre = 'Administrador'), 1, 1, GETDATE());
