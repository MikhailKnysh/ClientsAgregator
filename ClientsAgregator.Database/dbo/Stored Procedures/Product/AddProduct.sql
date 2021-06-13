CREATE PROCEDURE [ClientsAgregatorDB].[AddProduct]
@Articul VARCHAR(255),
@Title VARCHAR(255),
@Price FLOAT,
@Quantity INT,
@MeasureId INT
AS
INSERT [ClientsAgregatorDB].[Products] 
OUTPUT INSERTED.Id 
VALUES (@Articul, @Title, @Price, @Quantity, @MeasureId, NULL)

