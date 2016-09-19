<Query Kind="Statements">
  <Connection>
    <ID>b9167734-3981-4a95-bc5e-978a95550d41</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

// Which Waiter has the most Bills

var waiterBills = from x in Waiters
                  where x.Bills.Count() == Waiters.Select(mb => mb.Bills.Count()).Max()
				  select new {
				  	Name = x.LastName + ", " + x.FirstName,
					BCount = x.Bills.Count()
				  };
waiterBills.Dump();

var waiterBillsSub = from x in Waiters
                     where x.Bills.Count() == (from y in Waiters select y.Bills.Count()).Max()
					 select new {
					 	Name = x.LastName + ", " + x.FirstName,
						BCount = x.Bills.Count()
					 };
waiterBillsSub.Dump();

var maxBills = (from y in Waiters select y.Bills.Count()).Max();
var bestWaiter = from x in Waiters
                 where x.Bills.Count() == maxBills
				  select new {
					 	Name = x.LastName + ", " + x.FirstName,
						BCount = x.Bills.Count()
					 };
bestWaiter.Dump();