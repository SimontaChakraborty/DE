Select Department.ID, Department.Name, DepartmentHead.Name, count(Employee.ID) as NumberOfEmployees from Employee 
inner join Department on Employee.DepartmentID = Department.ID
inner join DepartmentHead on Department.ID = DepartmentHead.DeptId
group by Department.ID , Department.Name,DepartmentHead.Name
order by NumberOfEmployees desc;

