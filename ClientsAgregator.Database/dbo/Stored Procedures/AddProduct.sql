CREATE PROCEDURE AddProduct
@Title varchar(255),
@Price float,
@Quantity int,
@MeasureId int
AS
INSERT [dbo].[Products] 
VALUES (@Title, @Price, @Quantity, @MeasureId)

