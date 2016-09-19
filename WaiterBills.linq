<Query Kind="Statements">
  <Connection>
    <ID>b9167734-3981-4a95-bc5e-978a95550d41</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

// Create a DataSet which contains the summary of Bills info by Waiter
var billsByWaiter = from x in Waiters
                    orderby x.LastName, x.FirstName
					select new {
						Name = x.LastName + ", " + x.FirstName,
						BillInfo = (
							from y in x.Bills
							where y.BillItems.Count() > 0
							select new {
								BillID = y.BillID,
								BillDate = y.BillDate,
								TableID = y.TableID,
								Total = y.BillItems.Sum(b => b.SalePrice * b.Quantity)
							}
						)
					};
billsByWaiter.Dump();