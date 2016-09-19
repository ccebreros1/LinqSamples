<Query Kind="Expression">
  <Connection>
    <ID>51999ef4-bfd4-446c-bb35-4f3ee9b8236a</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//All costumers served by employee Jane Peacock
//Sample of entity subset and navigation from child to parent on Where
//Reminder that code is c# and thus appropate methods can be used .Equals()
from x in Customers
where x.SupportRepIdEmployee.FirstName.Equals("Jane") &&
x.SupportRepIdEmployee.LastName.Equals("Peacock")
select new
{
	Name = x.LastName + ", " + x.FirstName,
	City = x.City,
	State = x.State,
	Phone = x.Phone,
	Email = x.Email
}

//Sample of use of aggregates in queries
//Agregates are .Count(), .Sum(), .Max(), etc
//Go to this webpage for more info about delegates: http://dmit-2018.github.io/demos/docs/demos/eRestaurant/linq/extensions.html
//Count() counts the number of instances of the collection reference
//Sum() totals a specific field or expresion, thus you will likely need to use a delegate to indicate the collection instance attribute to be used
//Average() averages a specific field or expresion, thus you will likely need to use a delegate to indicate the collection instance attribute to be used
from x in Albums
orderby x.Title
where x.Tracks.Count() > 0 // This where was added since there are albums with no tracks in it
select new
{
	x.Title,
	NumberofTracks = x.Tracks.Count(),
	PriceOfAlbum = x.Tracks.Sum(y => y.UnitPrice),
	AverageTrackLenghtInSeconds = x.Tracks.Average(y => y.Milliseconds / 1000) //Using an expresion is useful when we are doing invoices for example. (I have 3 things that cost 30, and 4 that cost 40 how much is the sum?)
}

