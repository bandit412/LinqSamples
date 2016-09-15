<Query Kind="Expression">
  <Connection>
    <ID>572de865-68b8-4314-b75c-94d05052b0b0</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

// Use of Aggregates in Queries
// TIP: Look for the parent you want to Aggregate
// .Sum() totals a specific field, or expression, thus you will likely need to use a Delegate
//        to indicate the collection Instnace attribute to be used.
// .Average() averages a specific field, or expression, thus you will likely need to use a Delegate
//        to indicate the collection Instnace attribute to be used.
from x in Albums
orderby x.Title
// The WHERE clause is there because an ALBUM may not have any TRACKS
where x.Tracks.Count() > 0
select new {
	Title = x.Title,
	NumberOfTracks = x.Tracks.Count(),
	TotalTrackPrice = x.Tracks.Sum(y => y.UnitPrice),
	AverageTrackLengthInSecondsA = (x.Tracks.Average(y => y.Milliseconds)/1000),
	// the line below uses an Expression
	AverageTrackLengthInSecondsB = (x.Tracks.Average(y => y.Milliseconds/1000))
}