﻿-- Drops Software Table
DROP TABLE Software

-- Creates Software Table
CREATE TABLE Software(
	Id	int	IDENTITY PRIMARY KEY,
	SoftwareName	NVARCHAR(70),
	Authors	VARCHAR(70),
	UploaderID	NVARCHAR(450)	FOREIGN KEY	REFERENCES	dbo.AspNetUsers(id),	
	UploadDate	SMALLDATETIME,
	[Description]	VARCHAR(MAX),
	Publisher	NVARCHAR(70),
	DownloadUrl	NVARCHAR(MAX),
	Tag	VARCHAR(50)
);
GO

