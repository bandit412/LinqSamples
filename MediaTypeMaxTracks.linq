<Query Kind="Expression">
  <Connection>
    <ID>572de865-68b8-4314-b75c-94d05052b0b0</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

// Media Type with the most tracks
(from x in MediaTypes

select new {
	MediaType = x.Name,
	Tracks = x.Tracks.Count()
	
}).Max(y => y.Tracks)