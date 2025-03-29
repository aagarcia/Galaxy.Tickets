CREATE TABLE [dbo].[Tickets]
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
    Titulo NVARCHAR(255) NOT NULL,
    Descripcion TEXT NOT NULL,
    IdUsuarioCreador INT NOT NULL,
    IdUsuarioAsignado INT NULL,
    IdCategoria INT NOT NULL,
    IdPrioridad INT NOT NULL,
    IdEstado INT NOT NULL DEFAULT 1, -- Estado inicial "Abierto"
    FechaCierre DATETIME NULL,
    Estado BIT DEFAULT 1,
    IdUsuarioModificador INT NULL,
    FechaCreacion DATETIME DEFAULT GETDATE(),
    FechaModificacion DATETIME NULL,
    CONSTRAINT FK_Tickets_UsuarioCreador FOREIGN KEY (IdUsuarioCreador) REFERENCES Usuarios(Id),
    CONSTRAINT FK_Tickets_UsuarioAsignado FOREIGN KEY (IdUsuarioAsignado) REFERENCES Usuarios(Id),
    CONSTRAINT FK_Tickets_Categoria FOREIGN KEY (IdCategoria) REFERENCES Categorias(Id),
    CONSTRAINT FK_Tickets_Prioridad FOREIGN KEY (IdPrioridad) REFERENCES Prioridades(Id),
    CONSTRAINT FK_Tickets_Estado FOREIGN KEY (IdEstado) REFERENCES Estados(Id)
)
