
  --1.
  SELECT COUNT(Id) AS [Count]
  FROM WizzardDeposits

  --2.
	SELECT 
	MAX(MagicWandSize) AS [LongestMagicWand]
	FROM WizzardDeposits

  --3.
  SELECT 
  DepositGroup,
  MAX(MagicWandSize) AS [LongestMagicWand]
  FROM WizzardDeposits
  GROUP BY DepositGroup

  --4.
  SELECT TOP 1 WITH TIES
  DepositGroup
  FROM WizzardDeposits
  GROUP BY DepositGroup
  ORDER BY AVG(MagicWandSize)

  --POLZVAME with ties za da selectirame i dvete inache selektira samo purvoto

  --NE MOJEM DA NAPISHEM MIN(AVG(MagicWandSize)) ZASHTOTO 
  --NE MOJE EDNA AGREGIRASHTA FUNKCIQ DA SE SUDURJA V DRUGA !

  --5.
  SELECT
  DepositGroup,
  SUM(DepositAmount) AS [TotalSum]
  FROM WizzardDeposits
  GROUP BY DepositGroup

  --6.
  SELECT
  DepositGroup,
  SUM(DepositAmount) AS [TotalSum]
  FROM WizzardDeposits
  WHERE(MagicWandCreator = 'Ollivander family')
  GROUP BY DepositGroup

  --7.

  SELECT
  DepositGroup,
  SUM(DepositAmount) AS [TotalSum]
  FROM WizzardDeposits
  WHERE(MagicWandCreator = 'Ollivander family')
  GROUP BY DepositGroup
  HAVING (SUM(DepositAmount) < 150000)
  ORDER BY SUM(DepositAmount) DESC


  --8.
  SELECT 
  DepositGroup,
  MagicWandCreator,
  MIN(DepositCharge) AS [MinDepositCharge]
  FROM WizzardDeposits
  GROUP BY DepositGroup, MagicWandCreator
  ORDER BY MagicWandCreator, DepositGroup;



  --9.
SELECT 
CASE
   WHEN (Age >= 0 AND Age <= 10)
     THEN '[0-10]'
   WHEN (Age >= 11 AND Age <= 20)
     THEN '[11-20]'
   WHEN (Age >= 21 AND Age <= 30)
     THEN '[21-30]'
   WHEN (Age >= 31 AND Age <= 40)
     THEN '[31-40]'
   WHEN (Age >= 41 AND Age <= 50)
     THEN '[41-50]'
   WHEN (Age >= 51 AND Age <= 60)
     THEN '[51-60]'	
ELSE '[61+]'
END AS AgeGroup,
Count(Id) AS [WizardCount] 
FROM WizzardDeposits
GROUP BY CASE
   WHEN (Age >= 0 AND Age <= 10)
     THEN '[0-10]'
   WHEN (Age >= 11 AND Age <= 20)
     THEN '[11-20]'
   WHEN (Age >= 21 AND Age <= 30)
     THEN '[21-30]'
   WHEN (Age >= 31 AND Age <= 40)
     THEN '[31-40]'
   WHEN (Age >= 41 AND Age <= 50)
     THEN '[41-50]'
   WHEN (Age >= 51 AND Age <= 60)
     THEN '[51-60]'	
   ELSE '[61+]'
END



--10.
SELECT 
LEFT(FirstName,1) AS FirstLetter
FROM WizzardDeposits
WHERE(DepositGroup = 'Troll Chest')
GROUP BY LEFT(FirstName,1)


--11.
SELECT 
DepositGroup,
IsDepositExpired,
AVG(DepositInterest) AverageInterest
FROM WizzardDeposits
WHERE DepositStartDate > '01/01/1985'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired;


--12.
--Polzvame kursori koito ni pomagat da minem prez vseki edin red na edna tablica

--Deklarirame si promenlivi koito shte polzvame : te shte sa ot sushtiq tip ot koito 
--e DepositAmount t.e. DECIMAL(8,2) t.e. 8 cifri ot koito 2 otivat sled desetichnata zapetaq.

--Trqbva ni i totalSum koqto shte ima 0 kato default stoinost

--Deklarirame kursora kato mu davame ime, kazvame che e za vseki edin deposit 
--koito imame v WizzardDeposits, kazvame che iskame da vzemem kolonata DepositAmount.

--S IF() kazvame che @previousDeposit trqbva da ne e null za da setnem @totalSum !!!

--Trqbva da napishem Open CursorName za da mojemda go polzvame i nakraq go zatvarqme
--s CLOSE CursorName i nakraq go delokirame S DEALLOCATE CursorName za da ne ni habi poveche ot pametta.

--S FETCH NEXT FROM wizardCursor INTO @currentDeposit nie kazvame : 
--vzemi mi sledvashoto ot  wizardCursor i go zapishi v @currentDeposit


 --Za iterirane trqbva da polzvame cikul, vmesto skobi imame BEGIN i END:
 -- Imame funkciq @@FETCH_STATUS koqto vrushta 0 kogato e pulna i 1 kogato e prazna
 --Setvame totalSum  i previous sum za vsqka iteraciq
	
--Nakraq trqbva samo da pokajem @totalSum

--VAJNO : NA IZPITA NQMA DA IMAME KURSORI !!!!!!!!!!!!!



DECLARE @currentDeposit DECIMAL(8,2)
DECLARE @previousDeposit DECIMAL(8,2)
DECLARE @totalSum DECIMAL(8,2) = 0


DECLARE wizardCursor CURSOR FOR SELECT DepositAmount FROM WizzardDeposits
OPEN wizardCursor 
FETCH NEXT FROM wizardCursor INTO @currentDeposit

WHILE (@@FETCH_STATUS = 0)
BEGIN
	IF(@previousDeposit IS NOT NULL)
	BEGIN
		SET @totalSum += (@previousDeposit - @currentDeposit)
	END
		SET @previousDeposit = @currentDeposit
		FETCH NEXT FROM wizardCursor INTO @currentDeposit
END

CLOSE wizardCursor 
DEALLOCATE wizardCursor 

SELECT @totalSum


--VTORI NACHIN ZA RESHAVANE : Kato polzvame LEAD(What) OVER(ORDER BY What) AS GiveItAName
--Davame zadachata kato podzaqvka zashtoto ni trqbva samo obshtata suma na razlikite

SELECT SUM(wizardDep.Difference) FROM 
(
	SELECT 
	FirstName AS [Host Wizard],
	DepositAmount [Host Wizard Deposit],
	LEAD(FirstName) OVER (ORDER BY Id) AS [Guest Wizard],
	LEAD(DepositAmount) OVER (ORDER BY Id) AS [Guest Wizard Deposit],
	(DepositAmount - LEAD(DepositAmount) OVER (ORDER BY Id)) AS [Difference]
	FROM WizzardDeposits
) AS wizardDep



--13.
USE SoftUni

SELECT
DepartmentID,
SUM(Salary) AS TotalSalary
FROM Employees
GROUP BY DepartmentID


--14.
SELECT
DepartmentID,
MIN(Salary) AS MinimalSalary
FROM Employees
WHERE DepartmentID IN (2,5,7)
GROUP BY DepartmentID


--15.
--NOT FINISHED
Create TABLe EmployeesAverageSalaries(

)

UPDATE Employees
SET Salary = Salary - 5000
WHERE DepartmentID = 1

DELETE FROM Employees
WHERE ManagerID = 42

SELECT
DepartmentID,
AVG(Salary) AS AverageSalary
FROM Employees
WHERE Salary > 30000 
GROUP BY DepartmentID


--16.
SELECT * FROM Employees

SELECT
DepartmentID,
MAX(Salary) AS MaxSalary
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000


 
--17.
SELECT 
COUNT(Salary) AS [Count]
FROM Employees
WHERE ManagerID IS NULL


--18.

--DENSE_RANK() ni pozvolqva da podredime elementite po kriterii po koito nie zadavame.
--Tq ne e agregirashta funkciq
-- Obache trqbva da e razpredelen sprqmo DepartmentId zatova polzvame PARTITION BY

--Slagame vsichko v ottelna zaqvka ot koqto vzimame departmenta i ThirdHighesthSalary
-- NO SAMO TAM KUDETO SalaryDep.Rank = 3

SELECT
SalaryDep.DepartmentID,
SalaryDep.ThirdHighesthSalary FROM 
(
	SELECT
	DepartmentID,
	MAX(Salary) AS ThirdHighesthSalary,
	DENSE_RANK() OVER(PARTITION BY DepartmentID ORDER BY Salary DESC) AS [Rank]
	FROM Employees
	GROUP BY DepartmentID, Salary
) AS SalaryDep
WHERE SalaryDep.Rank = 3;


--19.
--NOT WORKING
SELECT 
FirstName, LastName, DepartmentID, Salary FROM Employees AS e
WHERE Salary > (
				SELECT AVG(Salary) FROM Employees AS emp
				WHERE e.DepartmentID = emp.DepartmentID
				GROUP BY DepartmentID
				) 
ORDER BY DepartmentID

