CREATE TABLE [dbo].[Usuarios]
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    Contraseña NVARCHAR(255) NOT NULL,
    IdRol INT NOT NULL,
    Estado BIT DEFAULT 1,
    IdUsuarioCreador INT NOT NULL,
    IdUsuarioModificador INT NULL,
    FechaCreacion DATETIME DEFAULT GETDATE(),
    FechaModificacion DATETIME NULL,
    CONSTRAINT FK_Usuarios_Rol FOREIGN KEY (IdRol) REFERENCES Roles(Id)
)
