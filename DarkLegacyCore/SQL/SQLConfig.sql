CREATE DATABASE [DB_DarkLegacy]
GO

USE [DB_DarkLegacy]
GO

CREATE TABLE [dbo].[Game](
	[IdGame] [int] IDENTITY(1,1) NOT NULL,
	[NmGame] [nvarchar](100) NOT NULL,
	[IdGenre] [int] NOT NULL,
	[LaunchYear] [int] NOT NULL,
	[Score] [int] NOT NULL,
	[FlEnabled] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdGame] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Genre](
	[IdGenre] [int] IDENTITY(1,1) NOT NULL,
	[DsGenre] [nvarchar](100) NOT NULL,
	[FlEnabled] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdGenre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Game] ADD  DEFAULT ((1)) FOR [FlEnabled]
GO

ALTER TABLE [dbo].[Genre] ADD  DEFAULT ((1)) FOR [FlEnabled]
GO

ALTER TABLE [dbo].[Game]  WITH CHECK ADD FOREIGN KEY([IdGenre])
REFERENCES [dbo].[Genre] ([IdGenre])
GO


insert into Genre (DsGenre)
VALUES
('Aventura'),
('RPG'),
('FPS (First-Person Shooter)'),
('Terror'),
('Esportes'),
('Ação'),
('Mundo Aberto')


insert into Game (NmGame, IdGenre, LaunchYear, Score)
VALUES
('The Legend of Zelda: Breath of the Wild', (SELECT IdGenre from Genre where DsGenre = 'Aventura' ), 2017, 97),
('The Witcher 3: Wild Hunt', (SELECT IdGenre from Genre where DsGenre = 'RPG' ), 2015, 94),
('Overwatch', (SELECT IdGenre from Genre where DsGenre = 'FPS (First-Person Shooter)' ), 2016, 90),
('Resident Evil 2 (2019)', (SELECT IdGenre from Genre where DsGenre = 'Terror' ), 2019, 92),
('FIFA 22', (SELECT IdGenre from Genre where DsGenre = 'Esportes' ), 2021, 85),
('God of War (2018)', (SELECT IdGenre from Genre where DsGenre = 'Ação' ), 2018, 95),
('Red Dead Redemption 2', (SELECT IdGenre from Genre where DsGenre = 'Mundo Aberto' ), 2018, 96)