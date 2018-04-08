<Query Kind="Expression" />

//spout-prematch
//void Main()
{
    var http = new System.Net.Http.HttpClient();
    var response = http.GetStringAsync("http://sport.betlab.com/spout-prematch/api/events").Result;
    var eventsProd = JsonConvert.DeserializeObject<EventDto[]>(response);
    
    response = http.GetStringAsync("http://sport3.betlab.com/spout-prematch/api/events").Result;
    var eventsStage = JsonConvert.DeserializeObject<EventDto[]>(response);

    
    var join = (from left in eventsProd 
                join right in eventsStage on left.Id equals right.Id
                select new 
                {
                    left.Id,left.GroupName,left.GroupId,  
                    ProdName = left?.GroupComment.FirstOrDefault(x => x.Lang == "ru")?.Text, 
                    StageName = right?.GroupComment.FirstOrDefault(x => x.Lang == "ru")?.Text
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
    public LangText[] GroupComment { get; set; } 
	public string GroupName { get; set; }
	public string GroupId { get; set; }
}