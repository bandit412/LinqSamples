<Query Kind="Expression">
  <Connection>
    <ID>41eae4e9-c686-472d-bbe5-77c1be7ae2fb</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Northwind_CPSC1517</Database>
  </Connection>
</Query>

from y in Regions
orderby y.RegionDescription
select new {
	rdesc = y.RegionDescription,
	employees = from terr in y.Territories
				from emp in terr.EmployeeTerritories
				group emp by emp.Employee into empgroup
				select new {
					fn = empgroup.Key.FirstName,
					ln = empgroup.Key.LastName,
					pc = empgroup.Key.PostalCode,
					hd = empgroup.Key.HireDate,
					territories = from t in empgroup
					select new {
						tdesc = t.Territory.TerritoryDescription
					}
				}
}