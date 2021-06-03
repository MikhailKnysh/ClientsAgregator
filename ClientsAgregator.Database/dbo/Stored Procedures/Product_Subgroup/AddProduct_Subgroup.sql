CREATE PROCEDURE [dbo].[AddProduct_Subgroup]
@ProductID INT,
@SubgroupID INT
AS
INSERT [dbo].[Product_Subgroup]
VALUES (@ProductID,@SubgroupID)