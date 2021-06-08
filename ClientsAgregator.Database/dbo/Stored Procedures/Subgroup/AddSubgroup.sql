CREATE PROCEDURE AddSubgroup
@Title VARCHAR(255)
AS
INSERT [dbo].[Subgroups]
OUTPUT inserted.Id
VALUES (@Title)