<Query Kind="Statements">
  <Connection>
    <ID>c9d21e00-7aae-48d2-848f-3598a34808d9</ID>
    <Persist>true</Persist>
    <Server>W309-AANDERSON\SQLEXPRESS</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

var results = from x in Waiters
    orderby x.LastName ascending
     select new
     {
         Name = x.LastName + ", " + x.FirstName,
		 Phone = x.Phone,
         Address = x.Address
     };
results.Dump();