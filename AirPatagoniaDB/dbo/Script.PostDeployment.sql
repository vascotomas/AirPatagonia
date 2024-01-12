IF NOT EXISTS(SELECT 1 FROM dispatcher)
BEGIN
	-- Insert type of documents
	INSERT INTO document_type (name_document) VALUES
	('Dni'),
	('Pasaporte');

	-- Insert dispatchers
	INSERT INTO dispatcher (birth_date, first_name, last_name, active, id_document_type, no_document)
	VALUES ('1990-05-15', 'Juan', 'Perez', 1, 1, '12345678'),
		   ('1985-03-20', 'Maria', 'Lopez', 1, 2, 'AB123456'),
		   ('1995-11-10', 'Carlos', 'Gomez', 1, 1, '87654321'),
		   ('1980-07-25', 'Ana', 'Martinez', 1, 2, 'CD987654'),
		   ('2000-02-05', 'Pedro', 'Rodriguez', 1, 1, '11112222'),
		   ('1975-09-30', 'Laura', 'Garcia', 1, 2, 'XYZ987654'),
		   ('1992-12-12', 'Daniel', 'Fernandez', 1, 1, '99998888')

END