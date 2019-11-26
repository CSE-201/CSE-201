CREATE TABLE [ClippedSoftware]	(
	ClippedSoftwareId		INT		PRIMARY KEY		IDENTITY	NOT NULL,
	UserId	NVARCHAR(450)	REFERENCES AspNetUsers(Id)	NOT NULL,
	SoftwareId int	REFERENCES	Software(id)	NOT NULL,
	ClipDate	datetime	NOT NULL
);
GO