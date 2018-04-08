<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <NuGetReference>Rock.Core.Newtonsoft</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()
{
    var http = new System.Net.Http.HttpClient();
    var response = http.GetStringAsync("https://sport.betlab.com/inner-feed-wrapper-live/").Result;
    var eventsProd = JsonConvert.DeserializeObject<Dto>(response);
    
    response = http.GetStringAsync("https://sport3.betlab.com/inner-feed-wrapper-live/").Result;
    var eventsStage = JsonConvert.DeserializeObject<Dto>(response);
	
	var Prod = (from left in eventsProd.Added 
                select new 
                {
                    left.Id,  

                }).ToList().Dump();
              
                
}

class Dto
{
	public EventDto[] Added { get ; set; }
}

class EventDto 
{
    public int Id { get; set; }
    public Odds[] Market{ get; set; } 
}

// Define other methods and classes here

class Odds 
{
    public string Market { get; set; }
}

