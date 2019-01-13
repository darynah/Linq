<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <NuGetReference>Rock.Core.Newtonsoft</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()
{
    var http = new System.Net.Http.HttpClient();
    var response = http.GetStringAsync("http://sport.betlab.com/spout/api/events").Result;
    var eventsProd = JsonConvert.DeserializeObject<EventDto[]>(response);
    
    response = http.GetStringAsync("http://sport3.betlab.com/spout/api/events").Result;
	//response = http.GetStringAsync("http://spout.hp.consul/api/events").Result;
    var eventsStage = JsonConvert.DeserializeObject<EventDto[]>(response);
	
	
    
    var join = (from left in eventsProd 
                join right in eventsStage on left.BetlabEventKey equals right.BetlabEventKey
				//join prod in eventsStage on left.EventKind equals prod.EventKind
				orderby left.SportType 
                select new 
                {
                    left.Id,
					//BetlabEventKeyProd = left?.BetlabEventKey,
					//BetlabEventKeyStage = right?.BetlabEventKey,
					//GroupIdProd = left?.GroupId,
					//GroupNameProd = left?.GroupName,
					//EventKindProd = left?.EventKind,
					//EventKindStage = right?.EventKind,
					SportTypeStage = right?.SportType,
					ExternalIdStage = right?.ExternalId,
					BetlabEventKeyStage= right?.BetlabEventKey,
					//URLStage = right?.Url,
                    ProdName = left?.Name.FirstOrDefault(x => x.Lang == "en")?.Text, 
                    StageName = right?.Name.FirstOrDefault(x => x.Lang == "en")?.Text,
					//StageNameEN = right?.Name.FirstOrDefault(x => x.Lang == "en")?.Text,
					//ProdNameEN = left?.Name.FirstOrDefault(x => x.Lang == "en")?.Text, 
                }).Where(e => e.ProdName != e.StageName).ToList().Dump();
                
                
}

// Define other methods and classes here

class LangText 
{
    public string Lang { get; set; }
    public string Text { get; set; }
}

class EventDto 
{
    public int Id { get; set; }
    public LangText[] Name { get; set; } 
	public string GroupName { get; set; }
	public string GroupId { get; set; }
	public string SportType { get; set; }
	public string EventKind { get; set; }
	public string BetlabEventKey{ get; set; }
	public string Url { get; set; }
	public string ExternalId { get; set; }
}