CREATE PROCEDURE GetSpendMoneyCountByClientId
	@Id INT,
	@Cost INT OUTPUT
AS
SET @Cost = (SELECT SUM(P.Price * PO.Quantity)
FROM [dbo].[Clients] AS C
join [dbo].[Orders] AS O ON C.Id = O.ClientId
join [dbo].[Product_Order] AS PO ON O.Id = PO.OrderId
join [dbo].[Products] AS P ON PO.ProductId = P.Id
WHERE C.Id = @Id)