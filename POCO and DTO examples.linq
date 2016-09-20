<Query Kind="Program">
  <Connection>
    <ID>b3bb3203-512a-414a-870a-7d280c74488e</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

void Main()
{

	//A list of bill counts for all waiters
	//This query will create a flat data set (POCO used)
	//The columns are native data types (int, String, etc)
	//One is not concerned with repeated data in a column
	//Instead of using an anonymous datatype (new {...}) we wish to use a defined class definition	
	var WaiterBillCount =  from x in Waiters
							select new WaiterBillCounts
							{
								Name = x.FirstName + " " + x.LastName,
								NumberOfBills = x.Bills.Count()
							};
	WaiterBillCount.Dump();
	
	var ParamMonth = 4;
	var ParamYear = 2016;
	var WaiterBills = from x in Waiters where x.LastName.Contains("k") orderby x.LastName, x.FirstName
					select new WaiterBills
							{
								Name = x.LastName + ", " + x.FirstName,
								TotalBillCount = x.Bills.Count(),
								BillInfo = (from y in x.Bills 
								where y.BillItems.Count > 0 
								&& y.BillDate.Month == DateTime.Today.Month - ParamMonth
								&& y.BillDate.Year == ParamYear
								select new BillItemSummary			
								{
									BillID = y.BillID, 
									BillDate = y.BillDate,
									Table=y.TableID,
									Total=y.BillItems.Sum(b => b.SalePrice * b.Quantity)
								}).ToList()
							};
							
	WaiterBills.Dump();

}

// Define other methods and classes here
//An example of a POCO class (flat)

public class WaiterBillCounts
{
	//Whatever recieving field on your query in your select
	//Appears as a property in this class
	public string Name {get; set;}
	public int NumberOfBills {get; set;}
}

public class BillItemSummary
{
	public int BillID {get; set;}
	public DateTime BillDate {get; set;}
	public int? Table {get; set;}
	public decimal Total {get; set;}
}

//An example of a DTO class (structured)

public class WaiterBills
{
	public string Name {get; set;}
	public int TotalBillCount {get; set;}
	public List<BillItemSummary> BillInfo{get; set;}
}
