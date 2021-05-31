CREATE PROCEDURE GetProductArticulAndTitleById
AS
SELECT [dbo].[Products].[Articul], [dbo].[Products].[Title]
FROM [dbo].[Products]