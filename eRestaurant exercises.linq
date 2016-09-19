<Query Kind="Statements">
  <Connection>
    <ID>b3bb3203-512a-414a-870a-7d280c74488e</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//Which waiter has the most bills

var MaxCount = (from x in Waiters select x.Bills.Count()).Max();

//To display the contents of a variable in LINQPad you use the method .Dump()

var PopularWaiter =  from x in Waiters where x.Bills.Count() == MaxCount
							select new
							{
								Name = x.FirstName + " " + x.LastName,
								NumberOfBills = x.Bills.Count()
							};

PopularWaiter.Dump();

//Proof that this is right
var AllWaiters =  from x in Waiters
							select new
							{
								Name = x.FirstName + " " + x.LastName,
								NumberOfBills = x.Bills.Count()
							};
AllWaiters.Dump();

//Create a dataset which contains the summary bill info by waiter

var WaiterBills = from x in Waiters orderby x.LastName, x.FirstName
					select new 
							{
								Name = x.LastName + ", " + x.FirstName,
								BillInfo = (from y in x.Bills 
								where y.BillItems.Count != 0 
								select new			
								{
									BillID = y.BillID, 
									BillDate = y.BillDate,
									Table=y.TableID,
									Total=y.BillItems.Sum(b => b.SalePrice * b.Quantity)
								})
							};
							
WaiterBills.Dump();