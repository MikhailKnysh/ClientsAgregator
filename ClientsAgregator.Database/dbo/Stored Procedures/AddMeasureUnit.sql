CREATE PROCEDURE AddMeasureUnit
@Title varchar(255)
AS
INSERT [dbo].[MeasureUnits]
VALUES (@Title)