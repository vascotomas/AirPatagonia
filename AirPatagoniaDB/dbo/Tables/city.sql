CREATE TABLE [dbo].[city]
(
	[id_city] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[name] VARCHAR(50) NOT NULL,
	[id_country] INT NOT NULL,
	FOREIGN KEY (id_country) REFERENCES country(id_country)

)
