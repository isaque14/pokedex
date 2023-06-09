USE [pokedex_temp]
GO
/****** Object:  Table [dbo].[Pokemons]    Script Date: 05/07/2023 09:05:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pokemons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](25) NOT NULL,
	[PokedexNumber] [int] NOT NULL,
	[Type] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[EvolutionStage] [int] NOT NULL,
	[EvolutionLine] [nvarchar](max) NOT NULL,
	[IsStarter] [bit] NOT NULL,
	[IsLegendary] [bit] NOT NULL,
	[IsMythical] [bit] NOT NULL,
	[IsUltraBeast] [bit] NOT NULL,
	[IsMega] [bit] NOT NULL,
	[UrlImage] [nvarchar](max) NOT NULL,
	[RegionId] [int] NOT NULL,
 CONSTRAINT [PK_Pokemons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Regions]    Script Date: 05/07/2023 09:05:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Regions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_Regions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Pokemons]  WITH CHECK ADD  CONSTRAINT [FK_Pokemons_Regions_RegionId] FOREIGN KEY([RegionId])
REFERENCES [dbo].[Regions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Pokemons] CHECK CONSTRAINT [FK_Pokemons_Regions_RegionId]
GO
