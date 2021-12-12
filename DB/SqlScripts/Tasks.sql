  -- �������� ������ �������������, ������� �� �������� ���������
  SELECT Electives.Name
  FROM Electives
  LEFT JOIN SchoolchildrenElectives ON SchoolchildrenElectives.ElectivesId = Electives.Id
  WHERE SchoolchildrenElectives.SchoolchildrenId IS NULL

  -- �������� ������ ����������, ������� �������� ��������� �������������
  SELECT Schoolchildren.Name,
         Count(Schoolchildren.Name) AS 'Count of schoolchildren'
  FROM Schoolchildren
  JOIN SchoolchildrenElectives ON SchoolchildrenElectives.SchoolchildrenId = Schoolchildren.Id
  GROUP BY Schoolchildren.Name
  HAVING Count(Schoolchildren.Name) > 1

  -- �������� ������ ����������, ������� �������� ������������, ������� �������� � �������� Math1
  SELECT Schoolchildren.Name
  FROM Schoolchildren
  JOIN SchoolchildrenElectives ON SchoolchildrenElectives.SchoolchildrenId = Schoolchildren.Id
  JOIN Electives ON Electives.Id = SchoolchildrenElectives.ElectivesId
  WHERE Electives.Name in
      (SELECT Electives.Name
       FROM Electives
       WHERE Electives.Name like 'Math1%')
	

  -- �������� ��������� �������������, �� ������� ����� ��������� � ����� Gonchar20,
  -- ��� ������� ��� ���� � ������ ���������, � ������� ������ 'Gonchar'
  SELECT COUNT(Electives.id) AS 'Count of Electives'
  FROM Electives
  RIGHT JOIN SchoolchildrenElectives ON SchoolchildrenElectives.ElectivesId = Electives.Id
  JOIN Schoolchildren ON Schoolchildren.Id = SchoolchildrenElectives.SchoolchildrenId WHERE SchoolchildrenElectives.ElectivesId IS NOT NULL
  AND Schoolchildren.Name like 'Gonchar2%'
  AND EXISTS
      (SELECT *
       FROM Schoolchildren
       WHERE Schoolchildren.Name like 'Gonchar%')
	 
  -- �������� ������ ���������� ������� �������, � ������� ��� ������������� (������������� �� ������)
  SELECT Schoolchildren.Name, Schoolchildren.ClassNumber
  FROM Schoolchildren
  LEFT JOIN SchoolchildrenElectives ON SchoolchildrenElectives.SchoolchildrenId = Schoolchildren.Id
  WHERE SchoolchildrenElectives.ElectivesId IS NULL AND
		Schoolchildren.ClassNumber BETWEEN 9 and 11
  ORDER BY Schoolchildren.ClassNumber DESC, Schoolchildren.Name

  -- ����������, ��� ������ �� �������������, � ������� ��������� ������� �Mikhail1�.
  SELECT Schoolchildren.Name
  FROM Schoolchildren
  JOIN SchoolchildrenElectives ON SchoolchildrenElectives.SchoolchildrenId = Schoolchildren.Id
  WHERE Schoolchildren.Name <> 'Mikhail1' AND
		SchoolchildrenElectives.ElectivesId IN (SELECT Electives.id AS 'Electives'
											    FROM Electives
											    JOIN SchoolchildrenElectives ON SchoolchildrenElectives.ElectivesId = Electives.Id
											    JOIN Schoolchildren ON Schoolchildren.Id = SchoolchildrenElectives.SchoolchildrenId
											    WHERE Schoolchildren.Name = 'Mikhail1')