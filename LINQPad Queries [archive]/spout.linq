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
    var eventsStage = JsonConvert.DeserializeObject<EventDto[]>(response);

    
    var join = (from left in eventsProd 
                join right in eventsStage on left.Id equals right.Id
                select new 
                {
                    left.Id,  
                    ProdName = left?.Name?.FirstOrDefault(x => x.Lang == "en")?.Text, 
                    StageName = right?.Name?.FirstOrDefault(x => x.Lang == "en")?.Text
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
}