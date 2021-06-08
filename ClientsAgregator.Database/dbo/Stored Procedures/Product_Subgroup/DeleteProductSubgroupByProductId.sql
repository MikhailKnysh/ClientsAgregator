CREATE PROCEDURE [dbo].[DeleteProductSubgroupByProductId]
@productId int
AS
DELETE [dbo].[Product_Subgroup]
WHERE [dbo].[Product_Subgroup].[ProductId]  = @productId