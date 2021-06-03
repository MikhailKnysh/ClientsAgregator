CREATE PROCEDURE AddClient
@FirstName VARCHAR(255),
@MiddleName VARCHAR(255),
@LastName VARCHAR(255),
@Phone VARCHAR(60),
@Email VARCHAR(255),
@BulkStatus INT,
@Male VARCHAR(50),
@СommentAboutСlient VARCHAR(800)
AS
INSERT Clients VALUES
(@FirstName, @MiddleName, @LastName, @Phone, @Email, @BulkStatus, @Male, @СommentAboutСlient)