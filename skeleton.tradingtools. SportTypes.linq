<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <NuGetReference>Rock.Core.Newtonsoft</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>System.Collections</Namespace>
</Query>

void Main()
{
    var http = new System.Net.Http.HttpClient();
	//var response = http.GetStringAsync("http://skeleton.tradingtools.betlab.private:8009/api/LineItem/current").Result;
	//var responseOpened = http.GetStringAsync("http://mirror.tradingfeed.tradingtools.betlab.private:8009/api/LineItem/current?excludeStatus=Removed&excludeStatus=Suspended").Result;
	//var responseSuspended = http.GetStringAsync("http://mirror.tradingfeed.tradingtools.betlab.private:8009/api/LineItem/current?excludeStatus=Removed&excludeStatus=Opened").Result;
	var responseOpened = http.GetStringAsync("http://192.168.49.197:8009/api/LineItem/current?excludeStatus=Removed&excludeStatus=Removed").Result;
	var responseSuspended = http.GetStringAsync("http://192.168.49.197:8009/api/LineItem/current?excludeStatus=Removed&excludeStatus=Opened").Result;
	var LineitemSuspended = JsonConvert.DeserializeObject<LineItem[]>(responseSuspended);
    var LineItemOpened = JsonConvert.DeserializeObject<LineItem[]>(responseOpened);
	
    var join = LineItemOpened.Union(LineitemSuspended)
                .Distinct(new LineItemComparrer())
				.Select(i => new 
				{
					i.sport,
					i.stage
				})
				.OrderBy(x => x.stage)
                .ToList().Dump(); 
}

public class LineItemComparrer : System.Collections.Generic.IEqualityComparer<LineItem>
{
	public bool Equals(LineItem x, LineItem y)
	{
		return x.sport == y.sport && x.stage == y.stage;
	}
	
	public int GetHashCode(LineItem x)
	{
		return x.sport.GetHashCode();
	}
}

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