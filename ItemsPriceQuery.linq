<Query Kind="Statements">
  <Connection>
    <ID>b3bb3203-512a-414a-870a-7d280c74488e</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

var query = Items.Where(x=>x.CurrentPrice>5.00m).
Select(x=> new {x.Description, x.CurrentPrice}); 
query.Dump();