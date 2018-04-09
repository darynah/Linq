<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <NuGetReference>Rock.Core.Newtonsoft</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()
{
    var http = new System.Net.Http.HttpClient();
    var response = http.GetStringAsync("https://sport.betlab.com/inner-feed-wrapper-live-airpm/").Result;
    var eventsProd = JsonConvert.DeserializeObject<Dto>(response);
    
    response = http.GetStringAsync("https://sport.betlab.com/inner-feed-wrapper-live-airpm/").Result;
    var eventsStage = JsonConvert.DeserializeObject<Dto>(response);
	
	var Prod = (from left in eventsProd.Added 
				join right in eventsStage.Added  on left.BetlabEventKey equals right.BetlabEventKey
                select new 
                {
                   
					ProdOdds = left?.Odds, 
					StageOdds = right?.Odds,

                }).Where(e => e.ProdOdds != e.StageOdds).ToList().Dump();
              
                
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
}




