CREATE PROCEDURE [ClientsAgregatorDB].[DeleteProductSubgroupByProductId]
@productId int
AS
DELETE [ClientsAgregatorDB].[Product_Subgroup]
WHERE [ClientsAgregatorDB].[Product_Subgroup].[ProductId]  = @productId