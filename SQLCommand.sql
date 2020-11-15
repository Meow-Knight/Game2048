USE Data2048Game

CREATE TABLE ScoreLevel4 (
	ID INT PRIMARY KEY IDENTITY(1,1),
	UserName VARCHAR(30) NOT NULL,
	Score INT NOT NULL
);

CREATE TABLE ScoreLevel5 (
	ID INT PRIMARY KEY,
	UserName VARCHAR(30) NOT NULL,
	Score INT NOT NULL
);

CREATE TABLE ScoreLevel6 (
	ID INT PRIMARY KEY,
	UserName VARCHAR(30) NOT NULL,
	Score INT NOT NULL
);

SELECT * FROM ScoreLevel4;
SELECT * FROM ScoreLevel5;
SELECT * FROM ScoreLevel6;

DELETE ScoreLevel6
	WHERE Score = 72;

INSERT dbo.ScoreLevel4
        ( UserName, Score )
VALUES  ( 'Minh', 200 );