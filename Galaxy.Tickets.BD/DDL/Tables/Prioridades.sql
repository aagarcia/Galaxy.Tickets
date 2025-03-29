CREATE TABLE [dbo].[Prioridades]
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) UNIQUE NOT NULL,
    Estado BIT DEFAULT 1,
    IdUsuarioCreador INT NOT NULL,
    IdUsuarioModificador INT NULL,
    FechaCreacion DATETIME DEFAULT GETDATE(),
    FechaModificacion DATETIME NULL
)
