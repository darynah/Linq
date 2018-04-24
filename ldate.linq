<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <NuGetReference>Rock.Core.Newtonsoft</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()

//scope: 
//airpm - desktop; -mobile; 
//EventType: 1 - prematch, 3 - soon, 2 - live, check the test without EventType parameter
{
    var http = new System.Net.Http.HttpClient();
    var response = http.GetStringAsync("https://sport.betlab.com/inner-feed-wrapper-prematch-airpm/").Result;
	//var response = http.GetStringAsync("https://sport3.betlab.com/inner-feed-wrapper-prematch/").Result;
	//var response = http.GetStringAsync("https://sport3.betlab.com/inner-feed-wrapper-live/").Result;
	//var response = http.GetStringAsync("https://sport3.betlab.com/inner-feed-wrapper-airpm/").Result;
	//var response = http.GetStringAsync("https://sport3.betlab.com/inner-feed-wrapper-virtual-sports/").Result;
	//var response = http.GetStringAsync("https://sport3.betlab.com/inner-feed-wrapper-virtual-sports-airpm/").Result;
    var eventsList = JsonConvert.DeserializeObject<Dto>(response);
	DateTime todaysDate = DateTime.Now;
	var Responce = (
				from list in eventsList.Added
				select new 
                {                   
					todaysDate,
					ExternalId = list?.ExternalId,
					BetlabEventKey = list?.BetlabEventKey, 
					EventType = list?.EventType,
                })
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