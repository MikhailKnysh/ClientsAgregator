CREATE PROCEDURE AddBulkStatus
@Title VARCHAR(255)
AS
INSERT BulkStatus VALUES
(@Title) 