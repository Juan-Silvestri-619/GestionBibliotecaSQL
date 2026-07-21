INSERT INTO autor (nombre, pais, activo)
VALUES
('J.R.R. Tolkien', 'Reino Unido', 1),
('George Orwell', 'Reino Unido', 1),
('Julio Cortázar', 'Argentina', 1),
('Gabriel García Márquez', 'Colombia', 1),
('Agatha Christie', 'Reino Unido', 1);

INSERT INTO libro (titulo, anioPublicacion, autorId, disponible)
VALUES
('El Hobbit', '1937-09-21', 1, 1),
('El Señor de los Anillos', '1954-07-29', 1, 1),
('1984', '1949-06-08', 2, 1),
('Rebelión en la granja', '1945-08-17', 2, 0),
('Rayuela', '1963-06-28', 3, 1),
('Cien años de soledad', '1967-05-30', 4, 1),
('Crónica de una muerte anunciada', '1981-03-01', 4, 1),
('Asesinato en el Orient Express', '1934-01-01', 5, 0);