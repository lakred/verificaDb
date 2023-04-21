-- 1) script per lo schema
CREATE TABLE MUSEUM (
Id_Museum INT PRIMARY KEY,
MuseumName VARCHAR(255) NOT NULL,
City VARCHAR(255) NOT NULL
);

CREATE TABLE ARTIST (
Id_Artist INT PRIMARY KEY,
Name VARCHAR(255) NOT NULL,
Country VARCHAR(255) NOT NULL
);

CREATE TABLE CHARACTER (
ID_Character INT PRIMARY KEY,
Name VARCHAR(255) NOT NULL
);

CREATE TABLE ARTWORK (
ID_Artwork INT PRIMARY KEY,
Name VARCHAR(255) NOT NULL,
ID_Museum INT,
ID_Artist INT,
ID_Character INT,
FOREIGN KEY (ID_Museum) REFERENCES MUSEUM(Id_Museum),
FOREIGN KEY (ID_Artist) REFERENCES ARTIST(Id_Artist),
FOREIGN KEY (ID_Character) REFERENCES CHARACTER(ID_Character)
);

--2) script insert

INSERT INTO MUSEUM (Id_Museum, MuseumName, City) VALUES (1, 'Santa Maria Gloriosa dei Frari', 'Venezia');
INSERT INTO MUSEUM (Id_Museum, MuseumName, City) VALUES (2, 'Louvre', 'Parigi');
INSERT INTO MUSEUM (Id_Museum, MuseumName, City) VALUES (3, 'Galleria Borghese', 'Roma');
INSERT INTO MUSEUM (Id_Museum, MuseumName, City) VALUES (4, 'Art Institute of Chicago', 'Chicago');

INSERT INTO ARTIST (Id_Artist, Name, Country) VALUES (1, 'Tiziano Vecellio', 'Italia');
INSERT INTO ARTIST (Id_Artist, Name, Country) VALUES (2, 'Caravaggio', 'Italia');
INSERT INTO ARTIST (Id_Artist, Name, Country) VALUES (3, 'Picasso', 'Spagna');

INSERT INTO CHARACTER (ID_Character, Name) VALUES (1, 'Flora');
INSERT INTO CHARACTER (ID_Character, Name) VALUES (2, 'Davide');
INSERT INTO CHARACTER (ID_Character, Name) VALUES (3, 'Chitarrista');

INSERT INTO ARTWORK (ID_Artwork, Name, ID_Museum, ID_Artist, ID_Character) VALUES (1, 'Flora', 1, 1, 1);
INSERT INTO ARTWORK (ID_Artwork, Name, ID_Museum, ID_Artist, ID_Character) VALUES (2, 'Concerto campestre', 2, 1, NULL);
INSERT INTO ARTWORK (ID_Artwork, Name, ID_Museum, ID_Artist, ID_Character) VALUES (3, 'Davide con la testa di Golia', 3, 2, 2);
INSERT INTO ARTWORK (ID_Artwork, Name, ID_Museum, ID_Artist, ID_Character) VALUES (4, 'Il vecchio chitarrista cieco', 4, 3, 3);

SELECT * FROM MUSEUM;
SELECT * FROM ARTIST;
SELECT * FROM ARTWORK;
SELECT * FROM CHARACTER;

--3) Scrivere una query "select" per recuperare la lista contenete: museo, nome opera, nome personaggio degli artisti italiani
SELECT M.MuseumName, A.Name as ArtworkName, C.Name as CharacterName
FROM MUSEUM M
JOIN ARTWORK AW ON M.Id_Museum = AW.ID_Museum
JOIN ARTIST A ON AW.ID_Artist = A.Id_Artist
JOIN CHARACTER C ON AW.ID_Character = C.ID_Character
WHERE A.Country = 'Italia';
--4) Scrivere una query per recuperare i nomi degli artisti, opere di quali sono conservate a Parigi
SELECT a.Name as ArtistName, aw.Name as ArtWorkName
FROM ARTIST a
JOIN ARTWORK aw ON a.Id_Artist = aw.Id_Artist
JOIN MUSEUM m ON aw.ID_Museum = m.Id_Museum
WHERE m.City = 'Parigi';
--5) Scrivere una query “select” per recuperare la città in quale è conservato quadro "Flora"
SELECT M.City
FROM MUSEUM as M
JOIN ARTWORK as aw ON aw.ID_Museum = m.Id_Museum
WHERE aw.Name='Flora';