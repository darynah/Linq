<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <NuGetReference>Rock.Core.Newtonsoft</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()
{
    var http = new System.Net.Http.HttpClient();
    var response = http.GetStringAsync("https://sport.betlab.com/inner-feed-wrapper-prematch-airpm/").Result;
    var eventsProd = JsonConvert.DeserializeObject<Dto>(response);
    
    response = http.GetStringAsync("https://sport3.betlab.com/inner-feed-wrapper-prematch-airpm/").Result;
    var eventsStage = JsonConvert.DeserializeObject<Dto>(response);
	
	var Prod = (from left in eventsProd.Added 
				join right in eventsStage.Added  on left.BetlabEventKey equals right.BetlabEventKey
                select new 
                {
                    ProdSportType = left?.SportType, 
					ProdOdds = left?.Odds, 
					StageOdds = right?.Odds,

                }).Where(s => s.ProdSportType == "PS33").ToList().Dump();
              
                
}

class Dto
{
	public EventDto[] Added { get ; set; }
}

class EventDto 
{
    public int Id { get; set; }
	public string BetlabEventKey{ get; set; }
	public string SportType{ get; set; }
    public string[] Odds{ get; set; } 
}