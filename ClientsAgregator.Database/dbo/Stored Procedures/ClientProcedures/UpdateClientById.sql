CREATE PROCEDURE UpdateClientById
@Id INT,
@FirstName VARCHAR(255),
@LastName VARCHAR(255),
@Phone VARCHAR(60),
@Email VARCHAR(255),
@BulkStatus INT,
@Male BIT
AS
UPDATE [dbo].[Clients]
SET
FirstName = @FirstName,
LastName = @LastName,
Phone = @Phone,
Email = @Email,
BulkStatusId = @BulkStatus,
Male = @Male
WHERE Id = @Id