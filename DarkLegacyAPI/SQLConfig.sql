CREATE DATABASE [DB_DarkLegacy]
GO

USE [DB_DarkLegacy]
GO

CREATE TABLE [dbo].[Jogos](
	[IdJogo] [int] IDENTITY(1,1) NOT NULL,
	[NmJogo] [nvarchar](100) NOT NULL,
	[IdGenero] [int] NOT NULL,
	[AnoLancamento] [int] NOT NULL,
	[Nota] [int] NOT NULL,
	[FlAtivo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdJogo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Generos](
	[IdGenero] [int] IDENTITY(1,1) NOT NULL,
	[DsGenero] [nvarchar](100) NOT NULL,
	[FlAtivo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdGenero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Jogos] ADD  DEFAULT ((1)) FOR [FlAtivo]
GO

ALTER TABLE [dbo].[Jogos]  WITH CHECK ADD FOREIGN KEY([IdGenero])
REFERENCES [dbo].[Generos] ([IdGenero])
GO


insert into Generos (DsGenero)
VALUES
('Aventura'),
('RPG'),
('FPS (First-Person Shooter)'),
('Terror'),
('Esportes'),
('Ação'),
('Mundo Aberto')


insert into Jogos (NmJogo, IdGenero, AnoLancamento, Nota)
VALUES
('The Legend of Zelda: Breath of the Wild', (SELECT IdGenero from Generos where DsGenero = 'Aventura' ), 2017, 97),
('The Witcher 3: Wild Hunt', (SELECT IdGenero from Generos where DsGenero = 'RPG' ), 2015, 94),
('Overwatch', (SELECT IdGenero from Generos where DsGenero = 'FPS (First-Person Shooter)' ), 2016, 90),
('Resident Evil 2 (2019)', (SELECT IdGenero from Generos where DsGenero = 'Terror' ), 2019, 92),
('FIFA 22', (SELECT IdGenero from Generos where DsGenero = 'Esportes' ), 2021, 85),
('God of War (2018)', (SELECT IdGenero from Generos where DsGenero = 'Ação' ), 2018, 95),
('Red Dead Redemption 2', (SELECT IdGenero from Generos where DsGenero = 'Mundo Aberto' ), 2018, 96)
