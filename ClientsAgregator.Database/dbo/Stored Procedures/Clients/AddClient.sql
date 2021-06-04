CREATE PROCEDURE AddClient
@LastName VARCHAR(255),
@FirstName VARCHAR(255),
@MiddleName VARCHAR(255),
@Phone VARCHAR(60),
@Email NVARCHAR(50),
@BulkStatus INT,
@Male VARCHAR(50),
@СommentAboutСlient VARCHAR(800)
AS
INSERT Clients VALUES
(@LastName, @FirstName, @MiddleName, @Phone, @Email, @BulkStatus, @Male, @СommentAboutСlient)