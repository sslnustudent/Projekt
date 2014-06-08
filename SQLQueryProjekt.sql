ALTER PROCEDURE appSchema.usp_getpatients
AS
BEGIN

	SELECT PatientID, (Patient.Fnamn + ' ' + Patient.Enamn) AS Namn, Adress, Postnr, Ort, (Läkare.Fnamn + ' ' + Läkare.Enamn) AS Läkare, Läkartyp
	FROM Patient LEFT JOIN Läkare ON Patient.LäkareID = Läkare.LäkareID
	LEFT JOIN Läkartyp ON Läkare.LäkartypID = Läkartyp.LäkartypID
END

ALTER PROCEDURE appSchema.usp_addpatients

   @Fnamn    varchar(50),
   @Enamn     varchar(50),
   @Adress varchar(50),
   @Postnr varchar(6),
   @Ort varchar(25),
   @Läkare int,
   @PatientID    int OUTPUT

AS
BEGIN
	INSERT INTO Patient (Fnamn,Enamn, Adress,Postnr, Ort, LäkareID)
	VALUES(@Fnamn,@Enamn,@Adress,@Postnr,@Ort,@Läkare )
	
	SET @PatientID = SCOPE_IDENTITY();
END

ALTER PROCEDURE appSchema.usp_getdoctors
AS
BEGIN

	SELECT LäkareID, (Fnamn + ' ' + Enamn) AS Namn, Fnamn, Enamn, Läkartyp, Läkartyp.LäkartypID
	FROM Läkare INNER JOIN Läkartyp ON Läkare.LäkartypID = Läkartyp.LäkartypID
END

CREATE PROCEDURE appSchema.usp_updatepatient
AS
BEGIN 
END

CREATE PROCEDURE appSchema.usp_getdoctortype
AS
BEGIN

	SELECT LäkartypID, Läkartyp
	FROM Läkartyp
END

CREATE PROCEDURE appSchema.usp_adddoctor

   @Fnamn    varchar(50),
   @Enamn     varchar(50),
   @Läkartyp varchar(50),
   @LäkareID    int OUTPUT

AS
BEGIN
	INSERT INTO Läkare (Fnamn, Enamn, LäkartypID)
	VALUES(@Fnamn,@Enamn,@Läkartyp )
	
	SET @LäkareID = SCOPE_IDENTITY();
END

ALTER PROCEDURE appSchema.usp_deletedoctor
@LäkareID int
AS
BEGIN
	DELETE
	FROM Läkare
	WHERE Läkare.LäkareID = @LäkareID

END
EXEC appSchema.usp_deletedoctor 4

Alter PROCEDURE appSchema.usp_updatedoctor
   @LäkareID    int,
   @Fnamn    varchar(50),
   @Enamn     varchar(50),
   @Läkartyp int
AS
BEGIN
	
	IF (EXISTS(SELECT LäkareID FROM Läkare WHERE LäkareID = @LäkareID))
	BEGIN
		UPDATE    Läkare
		SET       Fnamn = @Fnamn, Enamn = @Enamn, LäkartypID = @Läkartyp
		WHERE     (LäkareID = @LäkareID)
	END

END

ALTER PROCEDURE appSchema.usp_getpatientsbyid
	@PatientID int

AS
BEGIN

	SELECT PatientID, Patient.Fnamn, Patient.Enamn, Adress, Postnr, Ort, (Läkare.Fnamn + ' ' + Läkare.Enamn) AS Läkare, Läkartyp, Patient.LäkareID
	FROM Patient LEFT JOIN Läkare ON Patient.LäkareID = Läkare.LäkareID
	LEFT JOIN Läkartyp ON Läkare.LäkartypID = Läkartyp.LäkartypID
	WHERE PatientID = @PatientID
END

ALTER PROCEDURE appSchema.usp_getdoctorbyid

	@LäkareID int

AS
BEGIN

	SELECT     LäkareID, Fnamn, Enamn, Läkare.LäkartypID, Läkartyp
	FROM       Läkare LEFT JOIN Läkartyp ON Läkare.LäkartypID = Läkartyp.LäkartypID
	WHERE      LäkareID = @LäkareID
END

exec appSchema.usp_getdoctorbyid 1


ALTER PROCEDURE appSchema.usp_updatepatient
   @PatientID int,
   @LäkarID int,
   @Fnamn    varchar(50),
   @Enamn     varchar(50),
   @Adress varchar(50),
   @Postnr varchar(6),
   @Ort varchar(25)
AS
BEGIN

	IF (EXISTS(SELECT PatientID FROM Patient WHERE PatientID = @PatientID))
	BEGIN
		UPDATE    Patient
		SET       Fnamn = @Fnamn, Enamn = @Enamn, Adress = @Adress, Postnr = @Postnr, Ort = @Ort, LäkareID =@LäkarID
		WHERE     (PatientID = @PatientID)
	END
END

CREATE PROCEDURE appSchema.usp_deletepatient
@PatientID int
AS
BEGIN
	DELETE
	FROM Patient
	WHERE Patient.PatientID = @PatientID

END


SELECT Läkare.LäkareID
FROM Läkare
WHERE(Fnamn + ' ' + Enamn) = 'Sven Karlsson'
Sven Karlsson
