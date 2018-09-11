CREATE DATABASE [APIGameDB]
GO

USE [APIGameDB]
GO

CREATE TABLE dbo.Game (
    [GameId]			INT        PRIMARY KEY  IDENTITY (1, 1) NOT NULL, 
    [Title]				NVARCHAR (30)	NOT NULL,
    [GameDescription]	NVARCHAR (30)	NOT NULL,
    [MinPlayer]			INT				NOT NULL,
    [MaxPlayer]			INT				NOT NULL,
    [ImgPath]			NVARCHAR (100),
    [ThumbPath]			NVARCHAR (200),

);
	
CREATE TABLE dbo.Player (
    [PlayerId]	INT				PRIMARY KEY IDENTITY (1, 1) NOT NULL, 
    [PlayerName]	NVARCHAR (30)								NOT NULL,

);
GO

CREATE TABLE dbo.Library (
	[LibraryId] INT IDENTITY (1, 1)				NOT NULL,
	[PlayerId]  INT FOREIGN KEY REFERENCES Player(PlayerId)	NOT NULL,
	[GameId]    INT FOREIGN KEY REFERENCES Game(GameId)		NOT NULL,
	CONSTRAINT PK_Library PRIMARY KEY (GameId, PlayerId)

);
GO

CREATE TABLE dbo.GameNight (
    [GameNightId]		INT           PRIMARY KEY IDENTITY (1, 1)	NOT NULL, 
    [EventTitle]		NVARCHAR (50)								NOT NULL,
    [EventDate]		DATETIME2 (7)								NOT NULL,
    [Notes]			NVARCHAR (280),

);
GO

CREATE TABLE dbo.EventGames (
    [EventGamesId]				INT IDENTITY (1, 1)									NOT NULL, 
    [GameNightId]					INT FOREIGN KEY REFERENCES GameNight(GameNightId)	NOT NULL,
    [GameId]						INT FOREIGN KEY REFERENCES Game(GameId)				NOT NULL,
	[GameVotes]					INT, 
	CONSTRAINT	PK_EventGames	PRIMARY KEY (GameNightId, GameId)
);
GO

CREATE TABLE dbo.EventPlayers (
    [EventPlayersId]	INT IDENTITY (1, 1)									NOT NULL, 
    [GameNightId]     INT FOREIGN KEY REFERENCES GameNight(GameNightId)	NOT NULL,
    [PlayerID]		INT FOREIGN KEY REFERENCES Player(PlayerId)			NOT NULL,
	CONSTRAINT		PK_EventPlayers PRIMARY KEY (GameNightId, PlayerId)
);
GO


