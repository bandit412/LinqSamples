<Query Kind="Expression">
  <Connection>
    <ID>572de865-68b8-4314-b75c-94d05052b0b0</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

// Sample of Entity Subset
// Sample of Entity Navigation from Child to Parent on WHERE
// REMINDER: the code is C# and thus the appropriate methods can be used, i.e. .Equals()
from x in Customers
where x.SupportRepIdEmployee.FirstName.Equals("Jane") && x.SupportRepIdEmployee.LastName.Equals("Peacock")
select new {
	Name = x.LastName + ", " + x.FirstName,
	City = x.City,
	State = x.State,
	Phone = x.Phone,
	Email = x.Email
}
