<Query Kind="Statements">
  <Connection>
    <ID>572de865-68b8-4314-b75c-94d05052b0b0</ID>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

// Media Type with the most tracks
// When you need to use multiple steps to solve a problem
//   switch your language choice to either STATEMENT or PROGRAM
// The results of each query will now be saved in a variable
// The variable can then be used in future queries

var maxCount = (from x in MediaTypes
select x.Tracks.Count()).Max();
// To display the contents of a variable in LinqPad
//   you use the method .Dump(), i.e.
//maxCount.Dump();

// Get the MediaType that matches the maxCount
var popularType = from x in MediaTypes
                  where x.Tracks.Count() == maxCount
				  select new {
				  	Type = x.Name,
					TCount = x.Tracks.Count()
				  };
popularType.Dump();

// Can the above statements be done as 1 Query?
// Possibly, but not always. In this case yes, using a sub-query

var popularTypeSub = from x in MediaTypes
                  where x.Tracks.Count() == (from y in MediaTypes select y.Tracks.Count()).Max()
				  select new {
				  	Type = x.Name,
					TCount = x.Tracks.Count()
				  };
popularTypeSub.Dump();

// Can we have a mix of Methods and Query syntax at the same time
// This example uses the Method syntax to determine the count value for
//   the WHERE expression
// This demonstrates that queries can be constructed using both Query syntax
//   and Method syntax
var popularTypeSubMethod = from x in MediaTypes
                  where x.Tracks.Count() == MediaTypes.Select(mt => mt.Tracks.Count()).Max()
				  select new {
				  	Type = x.Name,
					TCount = x.Tracks.Count()
				  };
popularTypeSubMethod.Dump();