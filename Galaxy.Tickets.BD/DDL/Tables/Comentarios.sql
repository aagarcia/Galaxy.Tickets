CREATE TABLE [dbo].[Comentarios]
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
    IdTicket INT NOT NULL,
    IdUsuario INT NOT NULL,
    Comentario TEXT NOT NULL,
    Estado BIT DEFAULT 1,
    IdUsuarioCreador INT NOT NULL,
    IdUsuarioModificador INT NULL,
    FechaCreacion DATETIME DEFAULT GETDATE(),
    FechaModificacion DATETIME NULL,
    CONSTRAINT FK_Comentarios_Ticket FOREIGN KEY (IdTicket) REFERENCES Tickets(Id),
    CONSTRAINT FK_Comentarios_Usuario FOREIGN KEY (IdUsuario) REFERENCES Usuarios(Id)
)
