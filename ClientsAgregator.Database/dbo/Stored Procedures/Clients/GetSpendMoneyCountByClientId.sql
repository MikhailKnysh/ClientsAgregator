CREATE PROCEDURE [ClientsAgregatorDB].[GetSpendMoneyCountByClientId]
@Id INT
AS
(SELECT SUM(P.Price * PO.Quantity)
FROM [ClientsAgregatorDB].[Clients] AS C
join [ClientsAgregatorDB].[Orders] AS O ON C.Id = O.ClientId
join [ClientsAgregatorDB].[Product_Order] AS PO ON O.Id = PO.OrderId
join [ClientsAgregatorDB].[Products] AS P ON PO.ProductId = P.Id
WHERE C.Id = @Id)