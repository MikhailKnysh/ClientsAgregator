CREATE PROCEDURE [ClientsAgregatorDB].[UpdateProductById]
@Id INT,
@Articul VARCHAR(255),
@Title VARCHAR(255),
@Price FLOAT,
@Quantity FLOAT,
@MeasureId INT
AS
UPDATE [ClientsAgregatorDB].[Products] 
SET
Articul = @Articul,
Title = @Title,
Price = @Price,
Quantity = Quantity,
MeasureId = @MeasureId
where Id = @Id
