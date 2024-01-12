--CREATE DATABASE AirPatagonia;

CREATE TABLE document_type (
    id_document_type INT PRIMARY KEY,
    name_document VARCHAR(20) NOT NULL
);

CREATE TABLE dispatcher (
	id_dispatcher INT PRIMARY KEY IDENTITY (1,1),
	birth_date DATETIME,
	first_name VARCHAR(50) NOT NULL,
	last_name VARCHAR(50) NOT NULL,
	password_hash binary(1000) NULL,
	password_salt binary(1000) NULL,
    no_document VARCHAR(20) NOT NULL,
	id_document_type INT,
    FOREIGN KEY (id_document_type) REFERENCES document_type(id_document_type)
);