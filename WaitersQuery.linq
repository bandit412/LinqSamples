<Query Kind="Statements">
  <Connection>
    <ID>b9167734-3981-4a95-bc5e-978a95550d41</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//Waiters
var results = from x in Waiters
where x.FirstName.Contains("a")
orderby x.LastName ascending
select x.LastName + ", " + x.FirstName;
results.Dump();