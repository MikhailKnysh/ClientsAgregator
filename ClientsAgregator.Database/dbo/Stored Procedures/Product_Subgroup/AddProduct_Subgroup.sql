CREATE PROCEDURE [ClientsAgregatorDB].[AddProduct_Subgroup]
@ProductID INT,
@SubgroupID INT
AS
INSERT [ClientsAgregatorDB].[Product_Subgroup]
VALUES (@ProductID,@SubgroupID)