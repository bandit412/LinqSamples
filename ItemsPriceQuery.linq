<Query Kind="Expression">
  <Connection>
    <ID>b9167734-3981-4a95-bc5e-978a95550d41</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

from x in Items
where x.CurrentPrice > 5.00m
select new{
	x.Description,
	x.Calories
}