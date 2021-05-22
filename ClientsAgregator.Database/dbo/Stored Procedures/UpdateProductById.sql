CREATE PROCEDURE UpdateProductById
@Id int,
@Title varchar(255),
@Price float,
@Quantity int,
@MeasureId int
AS
UPDATE [dbo].[Products] 
SET
Title = @Title,
Price = @Price,
Quantity = Quantity,
MeasureId = @MeasureId
where Id = @Id
