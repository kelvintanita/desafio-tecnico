/****** Object:  Table [dbo].[Livro]    Script Date: 13/02/2020 21:55:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Livro](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GeneroId] [int] NOT NULL,
	[Titulo] [varchar](200) NOT NULL,
	[CodigoLivro] [uniqueidentifier] NOT NULL,
	[DataPublicacao] [datetime] NOT NULL,
	[Paginas] [int] NOT NULL,
	[Autor] [varchar](200) NOT NULL,
	[Editora] [varchar](200) NOT NULL,
	[Descricao] [varchar](2000) NOT NULL,
	[Sinopse] [varchar](1000) NOT NULL,
	[Imagem] [varchar](150) NOT NULL,
	[Links] [varchar](4000) NULL,
 CONSTRAINT [PK_Livro] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Livro]  WITH CHECK ADD  CONSTRAINT [FK_Livro_Genero] FOREIGN KEY([GeneroId])
REFERENCES [dbo].[Genero] ([Id])
GO

ALTER TABLE [dbo].[Livro] CHECK CONSTRAINT [FK_Livro_Genero]
GO


