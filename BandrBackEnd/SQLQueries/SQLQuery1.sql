INSERT INTO [Match] (SwiperId, SwiperMatch, RecId, RecMatch) VALUES (1, 0, 7, 1);
INSERT INTO [Match] (SwiperId, SwiperMatch, RecId, RecMatch) VALUES (1, 1, 2, 1);
INSERT INTO [Match] (SwiperId, SwiperMatch, RecId, RecMatch) VALUES (3, 0, 4, 1);
INSERT INTO [Match] (SwiperId, SwiperMatch, RecId, RecMatch) VALUES (1, 1, 5, 0);

SELECT * FROM [Match]

DELETE FROM [Match] WHERE Id = 5;

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

SELECT
p.Id,
p.UserId,
p.InstrumentId,
i.InstrumentName

FROM PlayedInstruments as p
LEFT JOIN Instrument as i on p.InstrumentId = i.Id
WHERE UserId = 2