USE TelerikAcademy

-- 4 Write a SQL query to find all information about all departments (use "TelerikAcademy" database).

SELECT * FROM Departments

-- 5 Write a SQL query to find all department names.

SELECT d.Name FROM Departments d

-- 6 Write a SQL query to find the salary of each employee.

SELECT FirstName + ' ' + LastName AS Employee, Salary FROM Employees

-- 7 Write a SQL to find the full name of each employee.

SELECT FirstName + ' ' + LastName AS 'Full Name' FROM Employees

-- 8 Write a SQL query to find the email addresses of each employee (by his first and last name). Consider that the mail domain is telerik.com. Emails should look like “John.Doe@telerik.com". The produced column should be named "Full Email Addresses".

SELECT FirstName + '.' + LastName + '@telerik.com' AS 'Full Email Addresses' FROM Employees

-- 9 Write a SQL query to find all different employee salaries.

SELECT DISTINCT Salary FROM Employees

-- 10 Write a SQL query to find all information about the employees whose job title is “Sales Representative“.

SELECT * 
FROM Employees
WHERE JobTitle = 'Sales Representative'

-- 11 Write a SQL query to find the names of all employees whose first name starts with "SA".

SELECT FirstName, LastName
FROM Employees
WHERE FirstName LIKE 'SA%'

-- 12 Write a SQL query to find the names of all employees whose last name contains "ei".

SELECT FirstName, LastName
FROM Employees
WHERE LastName LIKE '%ei%'

-- 13 Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000].

SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary BETWEEN 20000 AND 30000
ORDER BY Salary

-- 14 Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.

SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600)
ORDER BY Salary

-- 15 Write a SQL query to find all employees that do not have manager. (like CEO's)

SELECT *
FROM Employees
WHERE ManagerID IS NULL

-- 16 Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary.

SELECT FIrstName, LastName, Salary 
FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC

-- 17 Write a SQL query to find the top 5 best paid employees.

SELECT TOP(5) FirstName, LastName, Salary
FROM Employees
ORDER BY Salary DESC

-- 18 Write a SQL query to find all employees along with their address. Use inner join with ON clause.
 
SELECT e.FirstName, e.LastName, t.Name AS 'Town', a.AddressText AS 'Street' 
FROM Employees e INNER JOIN  Addresses a
ON e.AddressID = a.AddressID
INNER JOIN Towns t
ON a.TownID = t.TownID

-- 19 (EQUI JOIN) Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause). (EQUI JOIN)

SELECT e.FirstName, e.LastName, t.Name AS 'Town', a.AddressText AS 'Street' 
FROM Employees e, Addresses a, Towns t
WHERE e.AddressID = a.AddressID AND a.TownID = t.TownID

-- 20 (SELF JOIN) Write a SQL query to find all employees along with their manager. (SELF JOIN)

SELECT e.FirstName + ' ' + e.LastName AS 'Employee', m.FirstName + ' ' + m.LastName AS 'Manager'
FROM Employees e JOIN Employees m
ON e.ManagerID = m.EmployeeID

-- 21 Write a SQL query to find all employees, along with their manager and their address. Join the 3 tables: Employees e, Employees m and Addresses a.

SELECT e.FirstName + ' ' + e.LastName AS 'Employee', m.FirstName + ' ' + m.LastName AS 'Manager', 'City: ' + t.Name + ' Street: ' + a.AddressText AS 'Manager Address'
FROM Employees e JOIN Employees m
ON e.ManagerID = m.EmployeeID
INNER JOIN Addresses a
ON m.AddressID = a.AddressID
INNER JOIN Towns t
ON t.TownID = a.TownID

-- 22 Write a SQL query to find all departments and all town names as a single list. Use UNION.

SELECT Name AS 'Department Or Town'
FROM Departments
UNION
SELECT Name
FROM Towns

-- 23 Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager. Use right outer join. Rewrite the query to use left outer join.

SELECT e.FirstName + ' ' + e.LastName AS 'Employee', m.FirstName + ' ' + m.LastName AS 'Manager'
FROM Employees m RIGHT OUTER JOIN Employees e
ON e.ManagerID = m.EmployeeID

SELECT e.FirstName + ' ' + e.LastName AS 'Employee', m.FirstName + ' ' + m.LastName AS 'Manager'
FROM Employees e LEFT OUTER JOIN Employees m
ON e.ManagerID = m.EmployeeID

-- 24 Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" whose hire year is between 2001 and 2004.

SELECT e.FirstName + ' ' + e.LastName AS 'Employee', d.Name, e.HireDate
FROM Employees e INNER JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name IN ('Sales', 'Finance') AND DATEPART(yyyy, e.HireDate) BETWEEN 2001 AND 2004