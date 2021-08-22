/****** Object:  Table [dbo].[Documento]    Script Date: 12/27/2018 15:35:00 ******/
CREATE TABLE [dbo].[Documento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](20) NULL,
	[Titulo] [varchar](200) NULL,
	[DepartamentoId] [int] NULL,
	[CategoriaId] [int] NULL,
 CONSTRAINT [PK_Documento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Documento]  WITH CHECK ADD  CONSTRAINT [FK_Documento_Categoria] FOREIGN KEY([CategoriaId])
REFERENCES [dbo].[Categoria] ([Id])
GO

ALTER TABLE [dbo].[Documento] CHECK CONSTRAINT [FK_Documento_Categoria]
GO

ALTER TABLE [dbo].[Documento]  WITH CHECK ADD  CONSTRAINT [FK_Documento_Departamento] FOREIGN KEY([DepartamentoId])
REFERENCES [dbo].[Departamento] ([Id])
GO

ALTER TABLE [dbo].[Documento] CHECK CONSTRAINT [FK_Documento_Departamento]
GO


