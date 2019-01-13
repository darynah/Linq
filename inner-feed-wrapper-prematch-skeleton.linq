<Query Kind="Program">
  <Reference>&lt;ProgramFilesX86&gt;\LINQPad5\ngen006\StackExchange.Redis.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <NuGetReference>Rock.Core.Newtonsoft</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()
{

    var http = new System.Net.Http.HttpClient();
    var response = http.GetStringAsync("http://inner-feed-wrapper-prematch-skeleton-bl.hp.consul/").Result;
    var events = JsonConvert.DeserializeObject<Dto>(response);
	var Prod = (from left in events.Added
				from team in left.Teams
                //where team == "BM_Team_25999"
				where left.EventType == EventType.Prematch
				select new 
                {             
					Name = left.Name,
					Id = left.Id,
					//ExternalId= left.ExternalId,
					EventId= left.EventId,
					Status= left.Status,
					SportType = left.SportType,
					Category = left.Category,
					StartDate = left.StartDate,
					EventType = left.EventType,
                })
				//.Where(e => e.EventType == "1")//prematch
				//.Where(e => e.EventType == "3")//soon
				//.Where(e => e.Category == "BM_913")
				//.Where(e => e.EventId == "BM_14020905")
				.ToList().Dump();           
}

class Dto
{
	public EventDto[] Added { get ; set; }
}

enum EventType
{
	Prematch = 1,
	Live = 2
}

enum Status
{
	Open = 1,
	Suspended = 2
}

class EventDto 
{
    public string Id { get; set; }
	public string BetlabEventKey{ get; set; }
    public string[] Odds{ get; set; } 
	public string Name{ get; set; }
	public string ExternalId{ get; set; }
	public string EventId{ get; set; }
	public Status Status{ get; set; }
	public string SportType{ get; set; }
	public string Category{ get; set; }
	public DateTime StartDate{ get; set; }
	public EventType EventType{ get; set; }
	public IEnumerable<string> Teams { get; set; }
}