CREATE TABLE [dbo].[Jugadores] (
        [JugadorId] [int] NOT NULL IDENTITY(1,1),
        [usuario] [nvarchar](max),
        [correo] [nvarchar](max),
        [contrasenia] [nvarchar](max),
        [puntaje][float](23),
		Primary Key (JugadorId)
    )
