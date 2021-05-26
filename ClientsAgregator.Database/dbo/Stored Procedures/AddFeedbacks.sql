
CREATE PROCEDURE AddFeedbacks
@ClientId INT,
@ProductId INT,
@Description VARCHAR(800),
@Date VARCHAR(255),
@Rate INT
AS
INSERT [dbo].[Feedbacks] VALUES
(@ClientId, @ProductId, @Description, @Date, @Rate)