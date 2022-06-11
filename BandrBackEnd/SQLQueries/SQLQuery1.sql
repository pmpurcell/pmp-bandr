INSERT INTO [Match] (SwiperId, SwiperMatch, RecId, RecMatch) VALUES (1, 0, 7, 1);
INSERT INTO [Match] (SwiperId, SwiperMatch, RecId, RecMatch) VALUES (1, 1, 2, 1);
INSERT INTO [Match] (SwiperId, SwiperMatch, RecId, RecMatch) VALUES (7, 1, 1, 1);
INSERT INTO [Match] (SwiperId, SwiperMatch, RecId, RecMatch) VALUES (8, 1, 1, 0);

SELECT * FROM [Match]

DELETE FROM [Match]

SELECT * FROM [User]

CREATE TABLE [Message](
Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
ParticipantId INTEGER NOT NULL,
Body VARCHAR(255) NOT NULL,
TimeSent DATETIME NOT NULL
);

CREATE TABLE Participant(
Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
UserId INTEGER NOT NULL,
);

SELECT * FROM [Message] WHERE ParticipantId = 1;

INSERT INTO [Message] (ParticipantId, Body, TimeSent) VALUES (1, 'Diam quis enim lobortis scelerisque.', '');
INSERT INTO [Message] (ParticipantId, Body, TimeSent) VALUES (2, 'Diam quis enim lobortis scelerisque.', '');
INSERT INTO [Message] (ParticipantId, Body, TimeSent) VALUES (4, 'Diam quis enim lobortis scelerisque.', '');
INSERT INTO [Message] (ParticipantId, Body, TimeSent) VALUES (7, 'Diam quis enim lobortis scelerisque.', '');
INSERT INTO [Message] (ParticipantId, Body, TimeSent) VALUES (5, 'Diam quis enim lobortis scelerisque.', '');


INSERT INTO Instrument (InstrumentName) VALUES ('Trumpet');
INSERT INTO Instrument (InstrumentName) VALUES ('Ukulele');
INSERT INTO Instrument (InstrumentName) VALUES ('Saxophone');
INSERT INTO Instrument (InstrumentName) VALUES ('Bass');
INSERT INTO Instrument (InstrumentName) VALUES ('Voice');
INSERT INTO Instrument (InstrumentName) VALUES ('Guitar');
INSERT INTO Instrument (InstrumentName) VALUES ('Drums');

SELECT * FROM Instrument

INSERT INTO Genre (GenreName) VALUES ('Rock');
INSERT INTO Genre (GenreName) VALUES ('Jazz');
INSERT INTO Genre (GenreName) VALUES ('Ska');
INSERT INTO Genre (GenreName) VALUES ('Folk');
INSERT INTO Genre (GenreName) VALUES ('Pop');
INSERT INTO Genre (GenreName) VALUES ('Metal');

SELECT * FROM Genre

INSERT INTO PlayedInstruments(UserId, instrumentId) VALUES (2,2);

INSERT INTO PlayedGenres(UserId, genreId) VALUES (1,1);
INSERT INTO PlayedGenres(UserId, genreId) VALUES (1,2);
INSERT INTO PlayedGenres(UserId, genreId) VALUES (1,3);
INSERT INTO PlayedGenres(UserId, genreId) VALUES (2,1);
INSERT INTO PlayedGenres(UserId, genreId) VALUES (2,2);
INSERT INTO PlayedGenres(UserId, genreId) VALUES (2,3);

                                       SELECT
                                       p.Id,
                                       p.UserId,
                                       p.GenreId,
                                       g.GenreName
                                       
                                       FROM PlayedGenres as p
                                       LEFT JOIN Genre as g on p.GenreId = g.Id
                                       WHERE UserId = 1


SELECT
p.Id,
p.UserId,
p.InstrumentId,
i.InstrumentName

FROM PlayedInstruments as p
LEFT JOIN Instrument as i on p.InstrumentId = i.Id
WHERE UserId = 2

CREATE TABLE [User](
Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
firebaseUid VARCHAR(255) NOT NULL,
photo VARCHAR(255),
userName VARCHAR(255) NOT NULL,
userAge INT,
userBio VARCHAR(255),
[location] VARCHAR(255),
[skillLevel] VARCHAR(255),
);

SELECT * FROM [USER] WHERE firebaseUid = 'lr879dsyh4VcvUbobsazeDViRvz2'

DROP TABLE [User];

INSERT INTO [User]
(
firebaseUid,
Photo,
UserName,
UserAge,
UserBio,
[Location],
SkillLevel)

OUTPUT Inserted.Id
VALUES ('asdfasdfrgaga', '', 'Sam', 28, '', 'Nashville', 'Advanced')

SELECT * FROM [Match] WHERE SwiperId = 1 OR RecId = 1 AND RecMatch = 1 AND SwiperMatch = 1;

ALTER TABLE Message
ADD MatchId int;