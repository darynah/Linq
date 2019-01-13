<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <NuGetReference>Rock.Core.Newtonsoft</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()
{
    var http = new System.Net.Http.HttpClient();
    var response = http.GetStringAsync("http://inner-feed-wrapper-live.prod/").Result;
    var events = JsonConvert.DeserializeObject<Dto>(response);
    
    
    
	
	var Prod = (from left in events.Added 
                select new 
                {             
					Name = left.Name,
					//Id = left.Id,
					//ExternalId= left.ExternalId,
					EventId= left.EventId,
					//Status= left.Status,
					//SportType = left.SportType,
					//Category = left.Category,
					//StartDate = left.StartDate,
					//EventType = left.EventType,
					VideoLinks = left.VideoLinks,
                })
				.Where(e => e.VideoLinks.Count >0)
				//.OrderBy(e => e.VideoLinks)
				//.Where(e => e.EventType == "3")//soon
				//.Where(e => e.Category == "BM_913")
				.ToList().Dump();           
}

class Dto
{
	public EventDto[] Added { get ; set; }
}

class EventDto 
{
    public string Id { get; set; }
	public string BetlabEventKey{ get; set; }
    public string[] Odds{ get; set; } 
	public string Name{ get; set; }
	public string ExternalId{ get; set; }
	public string EventId{ get; set; }
	public string Status{ get; set; }
	public string SportType{ get; set; }
	public string Category{ get; set; }
	public string StartDate{ get; set; }
	public string EventType{ get; set; }
	public Dictionary<string,string> VideoLinks { get; set; }
	
}