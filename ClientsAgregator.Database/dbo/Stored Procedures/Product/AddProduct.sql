CREATE PROCEDURE AddProduct
@Articul VARCHAR(255),
@Title VARCHAR(255),
@Price FLOAT,
@Quantity INT,
@MeasureId INT
AS
INSERT [dbo].[Products] 
VALUES (@Articul, @Title, @Price, @Quantity, @MeasureId)

