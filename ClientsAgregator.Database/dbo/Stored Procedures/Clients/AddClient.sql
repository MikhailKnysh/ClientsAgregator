CREATE PROCEDURE AddClient
@FirstName VARCHAR(255),
@LastName VARCHAR(255),
@Phone VARCHAR(60),
@Email VARCHAR(255),
@BulkStatus INT,
@Male BIT
AS
INSERT Clients VALUES
(@FirstName, @LastName, @Phone, @Email, @BulkStatus, @Male)