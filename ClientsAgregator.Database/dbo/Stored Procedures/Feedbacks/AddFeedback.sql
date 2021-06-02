
CREATE PROCEDURE AddFeedback
@ClientId INT,
@ProductId INT,
@OrderId INT,
@Description VARCHAR(800),
@Date VARCHAR(255),
@Rate INT
AS
INSERT [dbo].[Feedbacks] VALUES
(@ClientId, @ProductId, @OrderId, @Description, @Date, @Rate)