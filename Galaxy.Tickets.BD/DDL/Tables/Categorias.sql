CREATE TABLE [dbo].[Categorias]
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Estado BIT DEFAULT 1,
    IdUsuarioCreador INT NOT NULL,
    IdUsuarioModificador INT NULL,
    FechaCreacion DATETIME DEFAULT GETDATE(),
    FechaModificacion DATETIME NULL
)
