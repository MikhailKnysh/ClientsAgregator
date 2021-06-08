CREATE PROCEDURE GetProductTitles
AS
SELECT [dbo].[Products].[Id], [dbo].[Products].[Title]
FROM [dbo].[Products]