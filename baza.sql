CREATE TABLE Korisnici (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Ime NVARCHAR(100),
    Prezime NVARCHAR(100),
);

CREATE PROCEDURE SelectKorisnikById
    @Id INT
AS
BEGIN
    SELECT Id, Ime, Prezime 
    FROM Korisnici
    WHERE Id = @Id;
END;
GO

CREATE PROCEDURE SelectAllKorisnici
AS
BEGIN
    SELECT Id, Ime, Prezime 
    FROM Korisnici;
END;
GO

CREATE PROCEDURE UpdateKorisnik
    @Id INT,
    @Ime NVARCHAR(100),
    @Prezime NVARCHAR(100)
AS
BEGIN
    UPDATE Korisnici
    SET Ime = @Ime,
        Prezime = @Prezime
    WHERE Id = @Id;
END;
GO

CREATE PROCEDURE DeleteKorisnik
    @Id INT
AS
BEGIN
    DELETE FROM Korisnici
    WHERE Id = @Id;
END;
GO

CREATE TABLE Proizvodjac (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Ime NVARCHAR(100),
);

CREATE PROCEDURE SelectAllProizvodjac
AS
BEGIN
    SELECT Id, Ime 
    FROM Proizvodjac;
END;
GO

CREATE PROCEDURE SelectProizvodjacById
    @Id INT
AS
BEGIN
    SELECT Id, Ime 
    FROM Proizvodjac
    WHERE Id = @Id;
END;
GO

CREATE PROCEDURE UpdateProizvodjac
    @Id INT,
    @Ime NVARCHAR(100)
AS
BEGIN
    UPDATE Proizvodjac
    SET Ime = @Ime
    WHERE Id = @Id;
END;
GO

CREATE PROCEDURE DeleteProizvodjac
    @Id INT
AS
BEGIN
    DELETE FROM Proizvodjac
    WHERE Id = @Id;
END;
GO

CREATE TABLE Artikli (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Ime NVARCHAR(100),
    IdProizvodjaca INT,
    DatumDolaska DATETIME,
    Kolicina INT,
    FOREIGN KEY (IdProizvodjaca) REFERENCES Proizvodjac(Id)
);

CREATE PROCEDURE SelectAllArtikli
AS
BEGIN
    SELECT Id, Ime, IdProizvodjaca, DatumDolaska, Kolicina 
    FROM Artikli;
END;
GO

CREATE PROCEDURE SelectArtikalById
    @Id INT
AS
BEGIN
    SELECT Id, Ime, IdProizvodjaca, DatumDolaska, Kolicina 
    FROM Artikli
    WHERE Id = @Id;
END;
GO

CREATE PROCEDURE UpdateArtikal
    @Id INT,
    @Ime NVARCHAR(100),
    @IdProizvodjaca INT,
    @DatumDolaska DATETIME,
    @Kolicina INT
AS
BEGIN
    UPDATE Artikli
    SET Ime = @Ime,
        IdProizvodjaca = @IdProizvodjaca,
        DatumDolaska = @DatumDolaska,
        Kolicina = @Kolicina
    WHERE Id = @Id;
END;
GO

CREATE PROCEDURE DeleteArtikal
    @Id INT
AS
BEGIN
    DELETE FROM Artikli
    WHERE Id = @Id;
END;
GO

CREATE TABLE Izlaz (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    VrstaIzlaza NVARCHAR(100), -- Unutar firme, izvan firme
    Datum DATETIME,
    Kolicina INT,
    IdArtikla INT,
    FOREIGN KEY (IdArtikla) REFERENCES Artikli(Id)
);

CREATE PROCEDURE SelectAllIzlaz
AS
BEGIN
    SELECT Id, VrstaIzlaza, Datum, Kolicina, IdArtikla
    FROM Izlaz;
END;
GO

CREATE PROCEDURE SelectIzlazById
    @Id INT
AS
BEGIN
    SELECT Id, VrstaIzlaza, Datum, Kolicina, IdArtikla
    FROM Izlaz
    WHERE Id = @Id;
END;
GO

CREATE PROCEDURE UpdateIzlaz
    @Id INT,
    @VrstaIzlaza NVARCHAR(100),
    @Datum DATETIME,
    @Kolicina INT,
    @IdArtikla INT
AS
BEGIN
    UPDATE Izlaz
    SET VrstaIzlaza = @VrstaIzlaza,
        Datum = @Datum,
        Kolicina = @Kolicina,
        IdArtikla = @IdArtikla
    WHERE Id = @Id;
END;
GO

CREATE PROCEDURE DeleteIzlaz
    @Id INT
AS
BEGIN
    DELETE FROM Izlaz
    WHERE Id = @Id;
END;
GO

CREATE TABLE Ulaz (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Datum DATETIME,
    IdArtikla INT,
    Kolicina INT,
    IdProizvodjaca INT,
    FOREIGN KEY (IdArtikla) REFERENCES Artikli(Id),
    FOREIGN KEY (IdProizvodjaca) REFERENCES Proizvodjac(Id)
);

CREATE PROCEDURE SelectAllUlaz
AS
BEGIN
    SELECT Id, Datum, IdArtikla, Kolicina, IdProizvodjaca
    FROM Ulaz;
END;
GO

CREATE PROCEDURE SelectUlazById
    @Id INT
AS
BEGIN
    SELECT Id, Datum, IdArtikla, Kolicina, IdProizvodjaca
    FROM Ulaz
    WHERE Id = @Id;
END;
GO

CREATE PROCEDURE UpdateUlaz
    @Id INT,
    @Datum DATETIME,
    @IdArtikla INT,
    @Kolicina INT,
    @IdProizvodjaca INT
AS
BEGIN
    UPDATE Ulaz
    SET Datum = @Datum,
        IdArtikla = @IdArtikla,
        Kolicina = @Kolicina,
        IdProizvodjaca = @IdProizvodjaca
    WHERE Id = @Id;
END;
GO

CREATE PROCEDURE DeleteUlaz
    @Id INT
AS
BEGIN
    DELETE FROM Ulaz
    WHERE Id = @Id;
END;
GO