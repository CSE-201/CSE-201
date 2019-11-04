Use cse201
GO

-- Drops search sp(s)
DROP PROCEDURE [dbo].[spSearchBySoftwareName]
GO
DROP PROCEDURE [dbo].[spSearchByAuthorName]
GO
DROP PROCEDURE [dbo].[spSearchByPublisherName]
GO
DROP PROCEDURE [dbo].[spSearchByTAGName]
GO

-- sp for searching by software
CREATE PROCEDURE [dbo].[spSearchBySoftwareName]
	@SoftwareName nvarchar(70)
AS
	SELECT *
	FROM Software
	WHERE Software.SoftwareName LIKE (@SoftwareName) 
	ORDER BY Software.SoftwareName
GO

-- sp for searching by author name
CREATE PROCEDURE [dbo].[spSearchByAuthorName]
	@AuthorName varchar(70)
AS
	SELECT *
	FROM Software
	WHERE Software.Authors LIKE (@AuthorName) 
	ORDER BY Software.SoftwareName
GO

-- sp for searching by publisher
CREATE PROCEDURE [dbo].[spSearchByPublisherName]
	@PublisherName nvarchar(70)
AS
	SELECT *
	FROM Software
	WHERE Software.Publisher LIKE (@PublisherName) 
	ORDER BY Software.SoftwareName
GO

-- sp for searching by a tag
CREATE PROCEDURE [dbo].[spSearchByTagName]
	@tag varchar(50)
AS
	SELECT *
	FROM Software
	WHERE Software.tag LIKE (@tag) 
	ORDER BY Software.SoftwareName
GO
