CREATE TABLE dispatcher (
	id_dispatcher INT PRIMARY KEY IDENTITY (1,1),
	birth_date DATETIME,
	first_name VARCHAR(50) NOT NULL,
	last_name VARCHAR(50) NOT NULL,
	active BIT NOT NULL,
	id_document_type INT,
    no_document VARCHAR(20) NOT NULL,
    FOREIGN KEY (id_document_type) REFERENCES document_type(id_document_type)
)