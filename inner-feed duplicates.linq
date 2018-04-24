<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <NuGetReference>Rock.Core.Newtonsoft</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()

//*scope: 
//airpm - desktop; -momile; 
//EventType: 1 - prematch, 3 - soon, 2 - live, 
{
    var http = new System.Net.Http.HttpClient();
    var response = http.GetStringAsync("https://sport3.betlab.com/inner-feed-wrapper-prematch-airpm/").Result;
	//var response = http.GetStringAsync("https://sport3.betlab.com/inner-feed-wrapper-prematch/").Result;
	//var response = http.GetStringAsync("https://sport3.betlab.com/inner-feed-wrapper-live/").Result;
	//var response = http.GetStringAsync("https://sport3.betlab.com/inner-feed-wrapper-airpm/").Result;
    var eventsList = JsonConvert.DeserializeObject<Dto>(response);
	
	var Responce = (
				from list in eventsList.Added
				select new 
                {                   
					EventType = list?.EventType, 
					StageExternalId = list?.ExternalId
                })
				.Where(t =>t.EventType == 1)
				.GroupBy(x => x)
				.Where(e => e.Count() > 1).Select(g => g.Key.StageExternalId)
				.ToList().Dump();
}

class Dto
{
	public EventDto[] Added { get ; set; }
}

class EventDto 
{
    public int Id { get; set; }
	public string BetlabEventKey{ get; set; }
    public string[] Odds{ get; set; } 
	public string ExternalId { get; set; } 
	public int EventType { get; set; }
	public int EventKind { get; set; }
}