ALTER PROCEDURE appSchema.usp_getpatients
AS
BEGIN

	SELECT PatientID, (Patient.Fnamn + ' ' + Patient.Enamn) AS Namn, Adress, Postnr, Ort, (L�kare.Fnamn + ' ' + L�kare.Enamn) AS L�kare, L�kartyp
	FROM Patient LEFT JOIN L�kare ON Patient.L�kareID = L�kare.L�kareID
	LEFT JOIN L�kartyp ON L�kare.L�kartypID = L�kartyp.L�kartypID
END

ALTER PROCEDURE appSchema.usp_addpatients

   @Fnamn    varchar(50),
   @Enamn     varchar(50),
   @Adress varchar(50),
   @Postnr varchar(6),
   @Ort varchar(25),
   @L�kare int,
   @PatientID    int OUTPUT

AS
BEGIN
	INSERT INTO Patient (Fnamn,Enamn, Adress,Postnr, Ort, L�kareID)
	VALUES(@Fnamn,@Enamn,@Adress,@Postnr,@Ort,@L�kare )
	
	SET @PatientID = SCOPE_IDENTITY();
END

ALTER PROCEDURE appSchema.usp_getdoctors
AS
BEGIN

	SELECT L�kareID, (Fnamn + ' ' + Enamn) AS Namn, Fnamn, Enamn, L�kartyp, L�kartyp.L�kartypID
	FROM L�kare INNER JOIN L�kartyp ON L�kare.L�kartypID = L�kartyp.L�kartypID
END

CREATE PROCEDURE appSchema.usp_updatepatient
AS
BEGIN 
END

CREATE PROCEDURE appSchema.usp_getdoctortype
AS
BEGIN

	SELECT L�kartypID, L�kartyp
	FROM L�kartyp
END

CREATE PROCEDURE appSchema.usp_adddoctor

   @Fnamn    varchar(50),
   @Enamn     varchar(50),
   @L�kartyp varchar(50),
   @L�kareID    int OUTPUT

AS
BEGIN
	INSERT INTO L�kare (Fnamn, Enamn, L�kartypID)
	VALUES(@Fnamn,@Enamn,@L�kartyp )
	
	SET @L�kareID = SCOPE_IDENTITY();
END

ALTER PROCEDURE appSchema.usp_deletedoctor
@L�kareID int
AS
BEGIN
	DELETE
	FROM L�kare
	WHERE L�kare.L�kareID = @L�kareID

END
EXEC appSchema.usp_deletedoctor 4

Alter PROCEDURE appSchema.usp_updatedoctor
   @L�kareID    int,
   @Fnamn    varchar(50),
   @Enamn     varchar(50),
   @L�kartyp int
AS
BEGIN
	
	IF (EXISTS(SELECT L�kareID FROM L�kare WHERE L�kareID = @L�kareID))
	BEGIN
		UPDATE    L�kare
		SET       Fnamn = @Fnamn, Enamn = @Enamn, L�kartypID = @L�kartyp
		WHERE     (L�kareID = @L�kareID)
	END

END

ALTER PROCEDURE appSchema.usp_getpatientsbyid
	@PatientID int

AS
BEGIN

	SELECT PatientID, Patient.Fnamn, Patient.Enamn, Adress, Postnr, Ort, (L�kare.Fnamn + ' ' + L�kare.Enamn) AS L�kare, L�kartyp, Patient.L�kareID
	FROM Patient LEFT JOIN L�kare ON Patient.L�kareID = L�kare.L�kareID
	LEFT JOIN L�kartyp ON L�kare.L�kartypID = L�kartyp.L�kartypID
	WHERE PatientID = @PatientID
END

ALTER PROCEDURE appSchema.usp_getdoctorbyid

	@L�kareID int

AS
BEGIN

	SELECT     L�kareID, Fnamn, Enamn, L�kare.L�kartypID, L�kartyp
	FROM       L�kare LEFT JOIN L�kartyp ON L�kare.L�kartypID = L�kartyp.L�kartypID
	WHERE      L�kareID = @L�kareID
END

exec appSchema.usp_getdoctorbyid 1


ALTER PROCEDURE appSchema.usp_updatepatient
   @PatientID int,
   @L�karID int,
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
		SET       Fnamn = @Fnamn, Enamn = @Enamn, Adress = @Adress, Postnr = @Postnr, Ort = @Ort, L�kareID =@L�karID
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


SELECT L�kare.L�kareID
FROM L�kare
WHERE(Fnamn + ' ' + Enamn) = 'Sven Karlsson'
Sven Karlsson
