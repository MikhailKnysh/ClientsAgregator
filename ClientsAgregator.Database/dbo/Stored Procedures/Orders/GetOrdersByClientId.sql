CREATE PROCEDURE GetOrdersByClientId
@ClientId INT
AS
SELECT * FROM [dbo].[Orders]
WHERE [dbo].[Orders].[ClientId] = @ClientId