SELECT distinct Salary FROM EMP ORDER BY Salary DESC OFFSET 2 rows Fetch first 1 rows only;

select top 3 Salary from 
(select distinct top 3 Salary from EMP order by Salary desc) result
order by Salary 
 
select Salary from EMP