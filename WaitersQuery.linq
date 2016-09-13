<Query Kind="Statements">
  <Connection>
    <ID>b3bb3203-512a-414a-870a-7d280c74488e</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//Waiters
Console.Write("Enter a First Name");
Console.WriteLine();
string FirstNameV;
FirstNameV=Console.ReadLine();
var results = from x in Waiters where x.FirstName.Equals(FirstNameV) orderby x.LastName select x.FirstName + ", " + x.LastName;
Console.WriteLine(results);