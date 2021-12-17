DROP FUNCTION IF EXISTS dbo.GETRANDOM
GO
CREATE FUNCTION GETRANDOM(@ONE int, @TWO int, @RAND FLOAT)
RETURNS int
AS
BEGIN
   RETURN FLOOR(@RAND * @ONE + @TWO)
END;
GO

DROP PROC IF EXISTS dbo.FillTables
GO
CREATE PROC FillTables(@Name nvarchar(15),
					   @BirthDate nvarchar(10),
					   @ElectiveName nvarchar(15),
					   @StartDate nvarchar(10),
					   @EndDate nvarchar(10),
					   @CurrentId int)
AS
BEGIN
	DECLARE @textId AS nvarchar(10);
	SET @textId = CAST(@CurrentId AS nvarchar(10));
	INSERT INTO Schoolchildren VALUES (dbo.GETRANDOM(10, 1, RAND()),
									   @Name + @textId,
									   @BirthDate,
									   dbo.GETRANDOM(2, 1, RAND()),
									   dbo.GETRANDOM(80, 50, RAND()));

	INSERT INTO Electives VALUES (@ElectiveName + @textId,
								  dbo.GETRANDOM(14, 1, RAND()),
								  @StartDate,
								  @EndDate,
								  dbo.GETRANDOM(5, 1, RAND()));

	INSERT INTO SchoolchildrenElectives	VALUES (dbo.GETRANDOM(@CurrentId, 1, RAND()),
												dbo.GETRANDOM(@CurrentId, 1, RAND()));
END;
GO

DECLARE @Id int;
SET @Id = 0;
WHILE @Id < 50 BEGIN
	SET @Id = @Id + 1
	
	IF @Id < 10  EXEC FillTables 'Mikhail', '01-12-2005', 'Math', '09-05-2021', '09-25-2021', @Id
	IF @Id < 20  EXEC FillTables 'Gonchar', '05-04-2007', 'Biology', '09-25-2021', '10-05-2021', @Id
	IF @Id < 30  EXEC FillTables 'Ramsay', '08-01-2010', 'Science', '10-05-2021', '10-25-2021', @Id
	IF @Id < 40  EXEC FillTables 'Polk', '10-20-2015', 'Health', '10-25-2021', '12-15-2021', @Id
	ELSE EXEC FillTables 'Johnson', '12-17-2013', 'Chemistry', '12-15-2021', '12-25-2021', @Id
END

SELECT * FROM [BasicDotNet].[dbo].[Electives]

SELECT * FROM [BasicDotNet].[dbo].Schoolchildren

SELECT * FROM [BasicDotNet].[dbo].SchoolchildrenElectives