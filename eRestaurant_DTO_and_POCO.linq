<Query Kind="Expression">
  <Connection>
    <ID>b9167734-3981-4a95-bc5e-978a95550d41</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

from food in Items
	group food by new {food.MenuCategory.Description} into tempdataset
	select new {
		MenuCategoryDescription = tempdataset.Key.Description,
		FoundItems = from x in tempdataset
			select new {
				ItemID = x.ItemID,
				FoodDescription = x.Description,
				CurrentPrice = x.CurrentPrice,
				TimeServed = x.BillItems.Count()
			}
	}
	
from food in Items
	orderby food.MenuCategory.Description
	select new {
		MenuCategoryDescription = food.MenuCategory.Description,
				ItemID = food.ItemID,
				FoodDescription = food.Description,
				CurrentPrice = food.CurrentPrice,
				TimeServed = food.BillItems.Count()
	}