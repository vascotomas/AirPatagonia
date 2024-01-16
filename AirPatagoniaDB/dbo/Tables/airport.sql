CREATE TABLE [dbo].[airport]
(
	[id_airport] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[name] VARCHAR(50) NOT NULL,
	[id_city] INT NOT NULL,
	FOREIGN KEY (id_city) REFERENCES city(id_city)
)
