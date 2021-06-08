CREATE PROCEDURE [ClientsAgregatorDB].[GetProductBuyClientById]
@Id INT
AS
SELECT P.[Articul], P.[Title], SUM(PO.Quantity) SUMQuantity, 
[Groups].[Title] AS GroupName, [Subgroups].[Title] AS SubGroupName, AVG(F.[Rate]) AS AVGRate
FROM [ClientsAgregatorDB].[Products] AS P 
JOIN [ClientsAgregatorDB].[Orders] ON Orders.ClientId = @Id
JOIN [ClientsAgregatorDB].[Product_Order] AS PO ON PO.OrderId = [Orders].[Id] and PO.ProductId = P.Id
JOIN [ClientsAgregatorDB].[Product_Subgroup] ON P.Id = [Product_Subgroup].[ProductId]
JOIN [ClientsAgregatorDB].[Subgroups] ON  Subgroups.Id = [Product_Subgroup].[SubgroupId]
JOIN [ClientsAgregatorDB].[Subgroup_Group] ON Subgroups.Id= [Subgroup_Group].[SubgroupId]
JOIN [ClientsAgregatorDB].[Groups] ON Groups.Id = [Subgroup_Group].[GroupId]
JOIN [ClientsAgregatorDB].[Feedbacks] AS F ON F.ProductId = PO.ProductId and F.ClientId = @Id and F.OrderId = Orders.Id
GROUP BY P.[Articul], P.[Title], [Groups].[Title], [Subgroups].[Title]
