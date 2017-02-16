<Query Kind="Statements">
  <Connection>
    <ID>2207c5f3-37ec-463d-a34c-f978c2848596</ID>
    <Persist>true</Persist>
    <Server>W309-AANDERSON\SQLEXPRESS</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

var artistResults = from x in Tracks
				where x.Album.ArtistId == 1
				select new {
					TrackID = x.TrackId,
					Name = x.Name,
					MediaName = x.MediaType.Name,
					GenreName = x.Genre.Name,
					Composer = x.Composer,
					Milliseconds = x.Milliseconds,
					Bytes = x.Bytes,
					UnitPrice = x.UnitPrice
				};
artistResults.Dump();

var genreResults = from x in Tracks
				where x.Genre.GenreId == 1
				select new {
					TrackID = x.TrackId,
					Name = x.Name,
					MediaName = x.MediaType.Name,
					GenreName = x.Genre.Name,
					Composer = x.Composer,
					Milliseconds = x.Milliseconds,
					Bytes = x.Bytes,
					UnitPrice = x.UnitPrice
				};
genreResults.Dump();

var mediaResults = from x in Tracks
				where x.MediaType.MediaTypeId == 1
				select new {
					TrackID = x.TrackId,
					Name = x.Name,
					MediaName = x.MediaType.Name,
					GenreName = x.Genre.Name,
					Composer = x.Composer,
					Milliseconds = x.Milliseconds,
					Bytes = x.Bytes,
					UnitPrice = x.UnitPrice
				};
mediaResults.Dump();

var albumResults = from x in Tracks
				where x.Album.AlbumId == 1
				select new {
					TrackID = x.TrackId,
					Name = x.Name,
					MediaName = x.MediaType.Name,
					GenreName = x.Genre.Name,
					Composer = x.Composer,
					Milliseconds = x.Milliseconds,
					Bytes = x.Bytes,
					UnitPrice = x.UnitPrice
				};
albumResults.Dump();