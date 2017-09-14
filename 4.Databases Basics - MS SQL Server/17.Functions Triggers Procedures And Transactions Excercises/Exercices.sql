

--01. Employees with salary above 35000

CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
	
		SELECT FirstName, LastName FROM Employees
		WHERE Salary > 35000;
GO
--Ne slagai GO v Judja

--EXEC dbo.usp_GetEmployeesSalaryAbove35000;




--02.Employees with Salary Above Number
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber(@Number money)
AS
	select 
		FirstName, LastName
	From Employees	
	WHERE Salary >= @Number;
GO
--Ne slagai GO v Judja

--EXEC usp_GetEmployeesSalaryAboveNumber 48100;




--03.Town Names Starting With
CREATE PROCEDURE usp_GetTownsStartingWith(@Str varchar(max))
AS
	select 
		Name
	FROM Towns
	Where left(Name, LEN(@Str)) = @Str;
GO	
--Ne slagai GO v Judja

--EXEC dbo.usp_GetTownsStartingWith 'Bor';


--04. Employees from Town
CREATE PROCEDURE usp_GetEmployeesFromTown(@TownName varchar(MAX))
AS
	select 
		e.FirstName, e.LastName
	from Employees AS e
		JOIN Addresses AS a
		ON e.AddressID = a.AddressID
		JOIN Towns AS t
		ON a.TownID = t.TownID
	WHERE t.Name = @TownName;
GO
--Ne slagai GO v Judja

--EXEC dbo.usp_GetEmployeesFromTown 'Sofia';



--05. Salary Level Function

CREATE FUNCTION ufn_GetSalaryLevel2 (@salary money)
RETURNS varchar(max)
BEGIN

	DECLARE @Result varchar(MAX);

	IF(@salary < 30000)
	BEGIN 
		SET @Result = 'Low';
	END

	IF(@salary > 50000)
	BEGIN 
		SET @Result = 'High';
	END

	IF(@salary BETWEEN 30000 AND 50000)
	BEGIN 
		SET @Result = 'Average';
	END

	RETURN @Result;

END


/*
SELECT 
	Salary,
	dbo.ufn_GetSalaryLevel2(Salary) AS SalaryLevel 
FROM Employees
*/



--06. Employees by Salary Level

CREATE PROCEDURE usp_EmployeesBySalaryLevel (@Level varchar(MAX))
AS

	CREATE FUNCTION ufn_GetSalaryLevel2 (@salary money)
RETURNS varchar(max)
BEGIN

	DECLARE @Result varchar(MAX);

	IF(@salary < 30000)
	BEGIN 
		SET @Result = 'Low';
	END

	IF(@salary > 50000)
	BEGIN 
		SET @Result = 'High';
	END

	IF(@salary BETWEEN 30000 AND 50000)
	BEGIN 
		SET @Result = 'Average';
	END

	RETURN @Result;

END
	

	select
		FirstName,
		LastName
	from Employees
	WHERE dbo.ufn_GetSalaryLevel2(Salary) = @Level;	
GO
--Ne slagai GO v Judja


EXEC dbo.usp_EmployeesBySalaryLeve 'Low';





























