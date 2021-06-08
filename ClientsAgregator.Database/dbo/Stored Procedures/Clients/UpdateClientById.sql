CREATE PROCEDURE [ClientsAgregatorDB].[UpdateClientById]
@Id INT,
@LastName VARCHAR(255),
@FirstName VARCHAR(255),
@MiddleName VARCHAR(255),
@Phone VARCHAR(60),
@Email NVARCHAR(50),
@BulkStatus INT,
@Male VARCHAR(50),
@СommentAboutСlient VARCHAR(800)
AS
UPDATE [ClientsAgregatorDB].[Clients]
SET
LastName = @LastName,
FirstName = @FirstName,
MiddleName = @MiddleName,
Phone = @Phone,
Email = @Email,
BulkStatusId = @BulkStatus,
Male = @Male,
СommentAboutСlient = @СommentAboutСlient 
WHERE Id = @Id