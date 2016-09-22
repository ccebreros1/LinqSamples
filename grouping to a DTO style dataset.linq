<Query Kind="Expression">
  <Connection>
    <ID>b3bb3203-512a-414a-870a-7d280c74488e</ID>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//This is a multi-column group
//Grouping data placed in a local temp Data Set for further processing 
//.Key allows you to have access to the value(s) in your group key(s)
//If you have multiple group columns they MUST be in an anonymous datatype
//to create a DTO type collection you can use .ToList() on the TempDataSet
//You can have a custom anonymous data collection by using a nested query

//STEP A
from food in Items
    group food by new {food.MenuCategoryID, food.CurrentPrice}

//STEP B DTO style dataset

from food in Items
    group food by new {food.MenuCategoryID, food.CurrentPrice} into TempDataSet
	select new
					{
						MenuCategoryID = TempDataSet.Key.MenuCategoryID,
						CurrentPrice = TempDataSet.Key.CurrentPrice,
						FoodItems = TempDataSet.ToList()
					}

//STEP C DTO custom style dataset
from food in Items
    group food by new {food.MenuCategoryID, food.CurrentPrice} into TempDataSet
	select new
					{
						MenuCategoryID = TempDataSet.Key.MenuCategoryID,
						CurrentPrice = TempDataSet.Key.CurrentPrice,
						FoodItems = from ItemsInList in TempDataSet select new
																	{
																		ItemID=ItemsInList.ItemID,
																		FoodDescription = ItemsInList.Description,
																		Calories = ItemsInList.Calories,
																		TimeServed = ItemsInList.BillItems.Count()
																	}
					}