select EmployeeTasks.Name,Employees.FullName, max(SpentTimes.Duration) as Duration
from EmployeeTasks left join SpentTimes
on EmployeeTasks.Id = SpentTimes.TaskId
left join Employees ON SpentTimes.EmployeeId = Employees.Id
group by EmployeeTasks.Name, Employees.FullName
order by EmployeeTasks.Name ASC

SELECT ET.Name, E.FullName, MAX(ST.Duration) FROM SpentTimes ST
INNER JOIN Employees E ON E.Id = ST.EmployeeId
INNER JOIN EmployeeTasks ET ON ET.Id = ST.TaskId
WHERE ST.Duration = (SELECT MAX(Duration) FROM SpentTimes)
GROUP BY  ET.Name, E.FullName
ORDER BY ET.Name ASC

SELECT ET.Name, E.FullName, ST.Duration FROM SpentTimes ST
INNER JOIN Employees E ON E.Id = ST.EmployeeId
INNER JOIN EmployeeTasks ET ON ET.Id = ST.TaskId
WHERE ST.Duration = (SELECT MAX(S.Duration) FROM SpentTimes S INNER JOIN Employees EE ON S.EmployeeId = EE.Id)

SELECT ET.Name, E.FullName, ST.Duration FROM EmployeeTasks ET 
INNER JOIN SpentTimes ST ON ET.Id = ST.Id
INNER JOIN Employees E ON E.Id = ST.EmployeeId

GROUP BY  ET.Name, E.FullName
ORDER BY ET.Name ASC

SELECT Name, FullName, Duration FROM EmployeeTasks, Employees, SpentTimes

GROUP BY  Name, FullName, Duration
ORDER BY EName ASC
