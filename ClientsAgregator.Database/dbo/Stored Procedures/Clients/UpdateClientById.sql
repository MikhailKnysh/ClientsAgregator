CREATE PROCEDURE UpdateClientById
@Id INT,
@FirstName VARCHAR(255),
@LastName VARCHAR(255),
@MiddleName VARCHAR(255),
@Phone VARCHAR(60),
@Email VARCHAR(255),
@BulkStatus INT,
@Male VARCHAR(50),
@СommentAboutСlient VARCHAR(800)
AS
UPDATE [dbo].[Clients]
SET
FirstName = @FirstName,
LastName = @LastName,
Phone = @Phone,
Email = @Email,
BulkStatusId = @BulkStatus,
Male = @Male,
СommentAboutСlient = @СommentAboutСlient 
WHERE Id = @Id