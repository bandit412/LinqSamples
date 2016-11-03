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
	territories = from terr in y.Territories
	select new {
		tdesc = terr.TerritoryDescription,
		fn = terr.EmployeeTerritories.FirstOrDefault().Employee.FirstName,
		ln = terr.EmployeeTerritories.FirstOrDefault().Employee.LastName,
		pc = terr.EmployeeTerritories.FirstOrDefault().Employee.PostalCode,
		hd = terr.EmployeeTerritories.FirstOrDefault().Employee.HireDate
	}
}