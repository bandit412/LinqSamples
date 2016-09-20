<Query Kind="Program">
  <Connection>
    <ID>b9167734-3981-4a95-bc5e-978a95550d41</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

void Main()
{
	
	// List<> of Bill counts for all Waiters
	// This query will create a flat DataSet
	// The columns are native DataTypes (i.e. int, string, ...)
	// One is not concerned with repeated data in a column
	// Instead of using an anonymous DataType (new {...})
	//   we wish to use a defined class definition (see below Main)
	var bestWaiter = from x in Waiters
				  select new WaiterBillCounts {
					 	Name = x.LastName + ", " + x.FirstName,
						BCount = x.Bills.Count()
					 };
	bestWaiter.Dump();

	var paramMonth = 4;
	var paramYear = 2014;
	var billsByWaiter = from x in Waiters
					where x.LastName.Contains("k")
                    orderby x.LastName, x.FirstName
					select new WaiterBills {
						Name = x.LastName + ", " + x.FirstName,
						BCount = x.Bills.Count(),
						BillInfo = (
							from y in x.Bills
							where y.BillItems.Count() > 0
							&& y.BillDate.Month == DateTime.Today.Month - paramMonth
							&& y.BillDate.Year == paramYear
							select new BillItemSummary {
								BillID = y.BillID,
								BillDate = y.BillDate,
								TableID = y.TableID,
								Total = y.BillItems.Sum(b => b.SalePrice * b.Quantity)
							}
						).ToList()
					};
	billsByWaiter.Dump();
}

// Define other methods and classes here
// An example of a POCO class, which is flat
public class WaiterBillCounts
{
	// Whatever receiving field on your query in your select
	//   appears as a property in this class
	public string Name {get; set;}
	public int BCount {get; set;}
}

public class BillItemSummary
{
	public int BillID {get; set;}
	public DateTime BillDate {get; set;}
	public int? TableID {get ;set;}
	public decimal Total {get; set;}
}

// This is an example of a DTO, which has a structure
public class WaiterBills
{
	public string Name {get; set;}
	public int BCount {get; set;}
	public List<BillItemSummary> BillInfo {get; set;}
}