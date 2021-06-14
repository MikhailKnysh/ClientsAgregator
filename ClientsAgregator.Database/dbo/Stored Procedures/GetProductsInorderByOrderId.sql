CREATE PROCEDURE [ClientsAgregatorDB].[GetProductsInOrderByOrderId]
@OrderId INT
AS
SELECT [ClientsAgregatorDB].[Products].[Articul], [ClientsAgregatorDB].[Products].[Id] AS ProductId,
[ClientsAgregatorDB].[Products].[Title] AS ProductTitle, [ClientsAgregatorDB].[Products].[Price],
[ClientsAgregatorDB].[Product_Order].[Quantity], [ClientsAgregatorDB].[MeasureUnits].[Id] AS MeasureUnitId,
[ClientsAgregatorDB].[MeasureUnits].[Title] AS MeasureUnitTitle, [ClientsAgregatorDB].[Groups].[Title] AS GroupTitle,
[ClientsAgregatorDB].[Subgroups].[Title] AS SubgroupTitle, [ClientsAgregatorDB].[Feedbacks].[Rate]
FROM [ClientsAgregatorDB].[Products]
LEFT JOIN [ClientsAgregatorDB].[MeasureUnits] 
ON [ClientsAgregatorDB].[Products].[MeasureId] = [ClientsAgregatorDB].[MeasureUnits].[Id]
LEFT JOIN [ClientsAgregatorDB].[Product_Subgroup]
ON [ClientsAgregatorDB].[Product_Subgroup].[ProductId] = [ClientsAgregatorDB].[Products].[Id]
LEFT JOIN [ClientsAgregatorDB].[Subgroups]
ON [ClientsAgregatorDB].[Product_Subgroup].[SubgroupId] = [ClientsAgregatorDB].[Subgroups].[Id]
LEFT JOIN [ClientsAgregatorDB].[Subgroup_Group]
ON [ClientsAgregatorDB].[Subgroups].[Id] = [ClientsAgregatorDB].[Subgroup_Group].[SubgroupId]
LEFT JOIN [ClientsAgregatorDB].[Groups]
ON [ClientsAgregatorDB].[Groups].[Id] = [ClientsAgregatorDB].[Subgroup_Group].[GroupId]
LEFT JOIN [ClientsAgregatorDB].[Product_Order]
ON [ClientsAgregatorDB].[Products].[Id] = [ClientsAgregatorDB].[Product_Order].[ProductId]
LEFT JOIN [ClientsAgregatorDB].[Feedbacks]
ON [ClientsAgregatorDB].[Product_Order].[OrderId] = [ClientsAgregatorDB].[Feedbacks].[OrderId]
WHERE [ClientsAgregatorDB].[Product_Order].[OrderId] = @OrderId