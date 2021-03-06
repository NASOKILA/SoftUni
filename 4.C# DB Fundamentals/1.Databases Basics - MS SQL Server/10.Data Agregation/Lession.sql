/*
Shte grupirame, agregirame i filtrirane na danni.

Grupirane:
Grupiraneto stava chrez koloni koito sa ednakvi i gi sabira v edna.
Obache drugite kolonki se vlivat v edna i za da gi dostupim trqbva da 
agregirame dannite.
*/

SELECT DepartmentId
FROM Employees
group by DepartmentID

--DISTINCT e podobno na group by samoche chrez group by mojem da dostupvame ostanalite koloni.

--Zd da namerim obshtata suma na zaplatite grupirani po DepartmentId.
SELECT 
DepartmentID, SUM(Salary) as [Total Salary]
FROM Employees
GROUP BY DepartmentID
ORDER BY [Total Salary] DESC
--SUM() ni e agregirashtata funkciq koqto sabira vsichki zaplati na dadenata kolonka


/*
Aggregirashti funkcii:
COUNT, SUM, MAX, MIN, AVG ...
*/

--COUNT - Broi kolko zapisa imame v tazi kolonka
SELECT 
JobTitle, COUNT(FirstName) as [NamesCount]
FROM Employees
GROUP BY JobTitle
ORDER BY [NamesCount] DESC
--kazva ni kolko hora ima v tazi profesiq

--Aggregirashtite funkcii mogat da se polzvat i bez da grupirame:
SELECT
COUNT(FirstName) as [PeopleCount]
FROM Employees
--kazva che imame 293 slujiteli NO MOJEM PROSTO DA POLZVAME DISTINCT

--Mojem da vidim primerno rabotnicite koito imat edno i sushto ime
SELECT 
FirstName, COUNT(EmployeeID)
FROM Employees
GROUP BY FirstName

--Mojem da grupirame po chasti ot dumi:
SELECT
LEFT(FirstName, 2), COUNT(FirstName)
FROM Employees
GROUP BY LEFT(FirstName, 2)
--vijdame na kolko hora imenata zapochvat s dadenata kolona  

--Zd. Da prebroim vurhovete na vsqka edna planina
SELECT * FROM Mountains
SELECT * FROM Peaks

SELECT 
MountainId,
COUNT(Id) as [PeakNumber]
FROM Peaks
GROUP BY MountainId
ORDER BY [PeakNumber] DESC



--SUM()  VIDQHME Q PREDI, S NEQ SUMIRAME VSICHKI STOINOSTi V DADENA KOLONKA 
--ZD. Sum prices of every item with same typeId
USE Diablo

SELECT 
SUM(Price),
ItemTypeId
FROM items
GROUP BY ItemTypeId

--Za vseki edint tip igra vijdame kolko pari sa hvurleni
SELECT 
GameId,
SUM(Cash) as [Total Cash Per GameId]
FROM UsersGames
GROUP BY GameId


/*
MAX() namira max stoinost vuv vsqka edna grupa.
Ako ne sme grupirali suotvetno v cqlata tablica.
*/

--Nai golqmata zaplata vuv vseki edin departament
USE SoftUni

SELECT 
MAX(Salary) AS [Max Salary],
DepartmentID
FROM Employees
GROUP BY DepartmentID
ORDER BY [Max Salary] DESC


--Zd. Da vidim nai bogatiq igrach ot diablo bazata
USE Diablo

SELECT 
UserId,
MAX(Cash) as [Richest Players]
FROM UsersGames
GROUP BY UserId
ORDER BY [Richest Players] DESC


--Iskame nai visokiq vruh za vsqka planina ot Geography bzata
USE Geography

SELECT 
MountainId,
MAX(Elevation) AS [Hiest Peak in mountain]
FROM Peaks
GROUP BY MountainId
ORDER BY [Hiest Peak in mountain]

-- samo nqi visokiq vruh kato cqlo
SELECT 
MAX(Elevation) AS [Hiest Peak]
FROM Peaks



/*
MIN() E ABSOLUTNO EDIN I SUSHT KATO MAX().
*/
SELECT 
MountainId,
MAX(Elevation) AS [Lowest Peak in mountain]
FROM Peaks
GROUP BY MountainId
ORDER BY [Lowest Peak in mountain]

-- samo nqi niskiq vruh kato cqlo
SELECT 
MIN(Elevation) AS [Hiest Peak]
FROM Peaks


/*
AVG - oznachava average koeto smqta srednata stoinost
*/
-- shte vzemem srednata zaplata za vseki departament
Use SoftUni

SELECT 
DepartmentID,
AVG(Salary) AS [Average Salary]
FROM Employees
GROUP BY DepartmentID 
ORDER BY [Average Salary] DESC



--kolko e srednata produljitelnost na edna igra:
USE Diablo
SELECT AVG(Duration)
FROM Games

--Ako iskame da vidim realnata stoinost trqbva da kastnem kum float:
SELECT AVG(CAST(Duration AS float))
FROM Games


/*
FILTRIRANE S 'Having' , TO E MALKO KATO WHERE !
FILTRITRANETO STAVA PO AGREGIRANATA STOINOST A NE PO STOINOSTTA OT TABLICATA,
MOJEM DA GO POLZVAME BEZ DA GRUPIRAME.
FILTRIRANETO STAVA SLED AGREGACIQTA A NE PREDI TOVA KAKTO PRAVI WHERE !!!
*/

--ZD: Filter department which have total salary more or equal to 150,000 : 
USE SoftUni 
SELECT 
DepartmentID,
SUM(Salary) AS [Total Salary]
FROM Employees
GROUP BY DepartmentID
HAVING SUM(Salary) >= 150000
ORDER BY [Total Salary] DESC
--ne mojem da slojim [Total Salary] zashtoto HAVING ne raboti s takiva koloni !

--HAVING se polzva kato WHERE samoche sled grupiraneto
--WHERE filtrira edinichnite rezultati dokato HAVING filtrira agregiranite rezultati


--Kolko dushi sme naemali za vseki mesec ot startiraneto na firmata v softuni:
USE SoftUni


SELECT 
COUNT(EmployeeId) AS [People we hired],
DATEDIFF(MONTH, '1998-07-31', HireDate) AS [Mounts in buisness]
FROM Employees
WHERE DATEDIFF(MONTH, '1998-07-31', HireDate) >= 24 AND DATEDIFF( month ,'1998-07-31' ,HireDate) <= 36
GROUP BY DATEDIFF(MONTH, '1998-07-31', HireDate) 
--Filtrirahme s WHERE samo v 3tata godina t.e. sled 24tiq i predi 36tiq mesec	



/*
SUMMARY:
Vidqhme :
grupiraneto, 
agregiraneto i zaedno i po ottdelno, 
HAVING
*/

-- filtrirame polzvaiki imenata na departamentite a ne tehnite Idta !!!
SELECT 
FirstName, LastName, Name AS [Department Name]
FROM Employees, Departments
WHERE Name IN ('Sales', 'Marketing');







