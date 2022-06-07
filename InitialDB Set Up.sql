USE MASTER

GO

IF NOT EXISTS (
	SELECT [name]
	FROM sys.databases
	WHERE [name] = N'Bandr'
	)
CREATE DATABASE Bandr
GO

USE Bandr
GO

DROP TABLE IF EXISTS [Match];
DROP TABLE IF EXISTS [User];
DROP TABLE IF EXISTS Instruments;
DROP TABLE IF EXISTS PlayedInstruments;
DROP TABLE IF EXISTS Genres;
DROP TABLE IF EXISTS PlayedGenres;
DROP TABLE IF EXISTS Participants;
DROP TABLE IF EXISTS [Messages];

CREATE TABLE [User] (
Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
firebaseUid INTEGER,
Photo VARCHAR(255) NOT NULL,
UserName VARCHAR(55) NOT NULL,
UserAge Int NOT NULL,
UserBio VARCHAR(255),
[Location] VARCHAR(55),
SkillLevel VARCHAR(55),
);

CREATE TABLE [Match] (
Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
SwiperId INTEGER,
SwiperMatch BIT,
RecId INTEGER,
RecMatch BIT,
);

CREATE TABLE Instrument (
Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
InstrumentName VARCHAR(55) NOT NULL,
);

CREATE TABLE PlayedInstruments(
Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
userId INTEGER NOT NULL,
instrumentId INTEGER NOT NULL
);

CREATE TABLE Genre(
Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
GenreName VARCHAR(55) NOT NULL,
);

CREATE TABLE PlayedGenres(
Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
userId INTEGER NOT NULL,
genreId INTEGER NOT NULL
);


INSERT INTO [User] ([UserName], Photo, UserAge, UserBio, [Location], SkillLevel) VALUES ('Corey', 'https://thumbs.dreamstime.com/b/thumbs-up-musician-4154514.jpg', 27, 'Just a duude who plays music!', 'Canada', 'Intermediate')
INSERT INTO [User] ([UserName], Photo, UserAge, UserBio, [Location], SkillLevel) VALUES ('Noah', 'https://thumbs.dreamstime.com/b/thumbs-up-musician-4154514.jpg', 26, '', '', '')
INSERT INTO [User] ([UserName], Photo, UserAge, UserBio, [Location], SkillLevel) VALUES ('Kyle', 'https://thumbs.dreamstime.com/b/thumbs-up-musician-4154514.jpg', 23, 'Trombone', 'Nashville', 'Advanced')
INSERT INTO [User] ([UserName], Photo, UserAge, UserBio, [Location], SkillLevel) VALUES ('Gertude&Ernest', 'https://thumbs.dreamstime.com/z/elderly-man-woman-electric-guitars-showing-thumbs-up-elderly-man-woman-electric-guitars-showing-thumbs-up-153659955.jpg', 85, 'Husband and Wife who love music as much as each other!', 'Retirement Home', 'Advanced')
INSERT INTO [User] ([UserName], Photo, UserAge, UserBio, [Location], SkillLevel) VALUES ('Vanessa', 'https://assets.classicfm.com/2013/23/bad-stock-photos-20-1371224808-view-0.jpg', 24, 'Just picked up the Violin!', 'Alabama', 'Beginner')
