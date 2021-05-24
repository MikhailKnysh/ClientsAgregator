
CREATE PROCEDURE AddFeedbacks
@Clientid INT,
@Productid INT,
@Description VARCHAR(800),
@Date VARCHAR(255),
@Rate INT

AS
INSERT Clients VALUES
(@Clientid, @Productid, @Description, @Date, @Rate)