CREATE DATABASE sistema_biblioteca;

USE sistema_biblioteca;

CREATE TABLE autor(
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	nombre VARCHAR(100) NOT NULL,
	pais VARCHAR(50),
	activo BIT NOT NULL DEFAULT 1
);

CREATE TABLE libro(
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	titulo VARCHAR(100) NOT NULL,
	anioPublicacion DATETIME,
	autorId INT NOT NULL,
	disponible BIT NOT NULL DEFAULT 1,

	FOREIGN KEY (autorId) REFERENCES autor(id)
);