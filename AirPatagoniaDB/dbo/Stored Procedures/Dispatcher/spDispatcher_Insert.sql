CREATE PROCEDURE InsertDispatcher
    @birth_date DATETIME,
    @first_name VARCHAR(50),
    @last_name VARCHAR(50),
    @active BIT,
    @id_document_type INT,
    @no_document VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dispatcher (birth_date, first_name, last_name, active, id_document_type, no_document)
    VALUES (@birth_date, @first_name, @last_name, @active, @id_document_type, @no_document);
END;
