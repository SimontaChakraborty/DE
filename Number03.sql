
select em.EMP_ID as ManagerID, em.EMP_NAME as Manager_Name, avg(e.Salary) 
from EMP e , EMP em where e.MANAGER_ID = em.EMP_ID
group by em.EMP_ID, em.EMP_NAME
order by em.EMP_ID;

 