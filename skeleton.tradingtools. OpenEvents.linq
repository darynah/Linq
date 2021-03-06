<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <NuGetReference>Rock.Core.Newtonsoft</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()
{
    var http = new System.Net.Http.HttpClient();
    var response = http.GetStringAsync("http://192.168.49.197:8009/api/LineItem/current?excludeStatus=Removed").Result;
	//var response = http.GetStringAsync("http://skeleton.tradingtools.betlab.private:8009/api/LineItem/current").Result;
    var Lineitem = JsonConvert.DeserializeObject<LineItem[]>(response);
    
    //response = http.GetStringAsync("http://skeleton.tradingtools.betlab.private:8009/api/Event/BM_13031078").Result;
    //var EventNew = new List<Event> { JsonConvert.DeserializeObject<Event>(response) };   

    var join = (from list in Lineitem
	
                //join right in EventNew on list.eventId equals right.id
                
                select new 
                {
                    //list.id,
                    list.eventId,
                    //right.name,
                    list.id,  
                    list.sport,
                    list.status,
					list.stage,
					list.StartTime,
					//list.timestamp,
                    //FirstDate = DateTime.Today,
					//SecondDate = list.StartTime
                    //outcomeKey = list.marketItems.Select(y => y.outcomes.Select((z => z.selectionKey)))
                    //selectionKey = list.marketItems.Select(y => y.outcomes.Select((z => z.selectionKey)))
                    
                    
                })

                //.Where(i=> i.sport == "Handball")
				//.Where(x => x.FirstDate.Date == x.SecondDate.Date)
				//.Where(k=> k.StartTime is"8/22/2018")
				//from list in Lineitem
				//Where list.FirstDate != SecondDate
                //.Where(e => e.id == "BM_Live_13031080" || e.id == "BM_Prematch_13183955")
                //.Select(z => z.marketItems.Select(y => y.outcomes.Select((w => w.outcomeStatus)).Where(j => j.outcomeStatus =="Resulted"))
                //.OrderBy(a =>a.timestamp)
				.ToList().Dump();
                
                
}

// Define other methods and classes here

    public class Name
{
    public string ru { get; set; }
}
    public class Event
    {
            public string id { get; set; }
            public Name name { get; set; }
            public string tournamentId { get; set; }
            public object taggedNames { get; set; }
            public string sport { get; set; }
            public string type { get; set; }
            public string competitorType { get; set; }
    }
    public class LineItem
    {
        public string id { get; set; }
        public DateTime timestamp { get; set; }
        public int dataVersion { get; set; }
        public string eventId { get; set; }
        public string sport { get; set; }
        public object tradingType { get; set; }
        public string stage { get; set; }
        public string status { get; set; }
        public int index { get; set; }
        public double delay { get; set; }
        public string trader { get; set; }
        public Limit limit { get; set; }
        public List<MarketItem> marketItems { get; set; }
        public bool archived { get; set; }
		public string StartTime { get; set; } 
		
    }

    public class Limit
    {
        public string type { get; set; }
        public int amount { get; set; }
    }

    public class MarketKey
    {
        public int marketType { get; set; }
        public int period { get; set; }
        public int? subPeriod { get; set; }
    }
    
    public class MarketItemKey
    {
        public MarketKey marketKey { get; set; }
        public object value { get; set; }
        public object competitor1Id { get; set; }
        public object competitor2Id { get; set; }
    }

    public class OutcomeKey
    {
        public int outcomeType { get; set; }
        public object outcomeValue { get; set; }
        public object outcomeCompetitorId { get; set; }
    }

    public class Outcome
    {
        public int version { get; set; }
        public OutcomeKey outcomeKey { get; set; }
        public string selectionKey { get; set; }
        public object price { get; set; }
        public object probability { get; set; }
        public string status { get; set; }
        public string result { get; set; }
        public double limitPercentage { get; set; }
    }

    public class MarketItem
    {
        public MarketItemKey marketItemKey { get; set; }
        public bool isOpen { get; set; }
        public List<Outcome> outcomes { get; set; }
    }