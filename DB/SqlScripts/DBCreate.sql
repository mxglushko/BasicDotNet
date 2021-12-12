GO

DROP FUNCTION IF EXISTS dbo.GETRANDOM
GO

CREATE FUNCTION GETRANDOM(@ONE int, @TWO int, @RAND FLOAT)
RETURNS int
AS
BEGIN
   RETURN FLOOR(@RAND * @ONE + @TWO)
END;
GO

DECLARE @Id int;
SET @Id = 0;

DECLARE @textId AS nvarchar(10);
SET @textId = 0;

WHILE @Id < 20 BEGIN
	SET @textId = CAST(@Id AS nvarchar(10));
	INSERT INTO Schoolchildren(Name, ClassNumber) VALUES ('Mikhail' + @textId, dbo.GETRANDOM(10, 1, RAND()));
	INSERT INTO Electives VALUES ('Math' + @textId);
	INSERT INTO SchoolchildrenElectives	VALUES (@Id, @Id);
	SET @Id = @Id + 1
END

WHILE @Id < 40 BEGIN
	SET @textId = CAST(@Id AS nvarchar(10));
	INSERT INTO Schoolchildren(Name, ClassNumber) VALUES ('Gonchar' + @textId, dbo.GETRANDOM(10, 1, RAND()));
	INSERT INTO Electives VALUES ('Biology' + @textId);
	INSERT INTO SchoolchildrenElectives	VALUES (@Id, @Id)
	SET @Id = @Id + 1
END

WHILE @Id < 50 BEGIN
	SET @textId = CAST(@Id AS nvarchar(10));
	INSERT INTO Schoolchildren(Name, ClassNumber) VALUES ('Ramsay' + @textId, dbo.GETRANDOM(10, 1, RAND()));
	INSERT INTO Electives VALUES ('Chemistry' + @textId);
	SET @Id = @Id + 1;
END

SELECT [Id], [Name]
FROM [BasicDotNet].[dbo].[Electives]

SELECT [Id], [Name]
FROM [BasicDotNet].[dbo].Schoolchildren

SELECT [Id], SchoolchildrenId, ElectivesId
FROM [BasicDotNet].[dbo].SchoolchildrenElectives