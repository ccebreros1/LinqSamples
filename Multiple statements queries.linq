<Query Kind="Statements">
  <Connection>
    <ID>51999ef4-bfd4-446c-bb35-4f3ee9b8236a</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//Know the media type with the most tracks
//When you need to use multiple steps to solve a problem, switch your language choice to either Statement or Program

//The results of each query will now be saved in a variable 
//The variable can then be used in future queries 

var MaxCount = (from x in MediaTypes select x.Tracks.Count()).Max();

//To display the contents of a variable in LINQPad you use the method .Dump()

MaxCount.Dump();

var PopularMediaType =  from x in MediaTypes where x.Tracks.Count() == MaxCount
							select new
							{
								Type = x.Name,
								TCount = x.Tracks.Count()
							};

PopularMediaType.Dump();