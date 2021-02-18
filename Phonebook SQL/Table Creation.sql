USE dbPhonebook
GO

--Create table Information
CREATE TABLE CLIENT
(
	clientID INT NOT NULL IDENTITY(1, 1),
	clientName VARCHAR(255),
	clientSurname VARCHAR(255),
	clientIdNumber VARCHAR (13),
	clientTelephone VARCHAR(10) UNIQUE,
	clientEmail VARCHAR(100) UNIQUE,
	clientAddress VARCHAR(800) UNIQUE,
	PRIMARY KEY(clientID)
)
GO