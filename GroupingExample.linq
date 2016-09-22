<Query Kind="Expression">
  <Connection>
    <ID>605deebd-d6b0-4c62-aa34-1abf11cbc3dc</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

// This is a multi-column grouping placed in a local temp
//   DataSet for further processing
// The .Key allows you to have access to the value(s) in
//   in your group key(s)
// If you have multiple group columns they MUST be in an
//   anonymous Data Type
// To create a DTO type collection you can use can use the
//  .ToList() on the temp DataSet
// You can have a custom anonymous Data Collection by using
//   a nested query

// Step A
//from food in Items
//	group food by new {food.MenuCategoryID, food.CurrentPrice}
	
// Step B
from food in Items
    // put data into a temporary DataSet
	group food by new {food.MenuCategoryID, food.CurrentPrice} into tempDataSet
	//select tempDataSet
	select new {
		MenuCategoryID = tempDataSet.Key.MenuCategoryID,
		CurrentPrice = tempDataSet.Key.CurrentPrice,
		// The line below brings back all the columns = DTO Style
		FoodItems1 = tempDataSet.ToList(),
		// To get specific columns do the following = DTO Custom
		FoodItems2 =
			from x in tempDataSet
			select new {
				ItemID = x.ItemID,
				FoodDescription = x.Description,
				TimesServed = x.BillItems.Count()
			}
	}