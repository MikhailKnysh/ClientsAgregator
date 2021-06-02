CREATE PROCEDURE [dbo].[GetCommentAboutClientById]
	@Id INT
AS
SELECT C.[СommentAboutСlient]
FROM [dbo].[Clients] AS C
WHERE C.Id = @Id