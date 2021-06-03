CREATE PROCEDURE GetProductBuyClientById
@Id INT
AS
SELECT P.[Articul], P.[Title], SUM(PO.Quantity) SUMQuantity, 
[Groups].[Title] AS GroupName, [Subgroups].[Title] AS SubGroupName, AVG(F.[Rate]) AS AVGRate
FROM [dbo].[Products] AS P 
JOIN [dbo].[Orders] ON Orders.ClientId = @Id
JOIN [dbo].[Product_Order] AS PO ON PO.OrderId = [Orders].[Id] and PO.ProductId = P.Id
JOIN [dbo].[Product_Subgroup] ON P.Id = [Product_Subgroup].[ProductId]
JOIN [dbo].[Subgroups] ON  Subgroups.Id = [Product_Subgroup].[SubgroupId]
JOIN [dbo].[Subgroup_Group] ON Subgroups.Id= [Subgroup_Group].[SubgroupId]
JOIN [dbo].[Groups] ON Groups.Id = [Subgroup_Group].[GroupId]
JOIN [dbo].[Feedbacks] AS F ON F.ProductId = PO.ProductId and F.ClientId = @Id and F.OrderId = Orders.Id
GROUP BY P.[Articul], P.[Title], [Groups].[Title], [Subgroups].[Title]
