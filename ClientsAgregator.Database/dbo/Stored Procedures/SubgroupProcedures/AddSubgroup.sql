CREATE PROCEDURE AddSubgroup
@Title VARCHAR(255)
AS
INSERT [dbo].[Subgroups] VALUES
(@Title)
