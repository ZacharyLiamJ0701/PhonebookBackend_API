USE master
GO

--Create database
CREATE DATABASE dbPhonebook
ON PRIMARY
(
	--Primary data file
	NAME = 'dbPhonebook_data',
	FILENAME = 'c:\sql12\dbPhonebook.mdf',
	SIZE = 5MB,
	FILEGROWTH = 10%
)
LOG ON
(
	--Log file
	NAME = 'dbPhonebook_log',
	FILENAME = 'c:\sql12\dbPhonebook.ldf',
	SIZE = 5MB,
	FILEGROWTH = 10%
)
GO