<Query Kind="Program">
  <Reference>&lt;ProgramFilesX86&gt;\LINQPad5\ngen006\StackExchange.Redis.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <NuGetReference>Rock.Core.Newtonsoft</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()
{
	var connection = StackExchange.Redis.ConnectionMultiplexer.Connect("uat.redis.betlab.private");
    var db = connection.GetDatabase(0);
	var result = db.StringGet("sportsbook:tt:entry:2:BM_Live_10905359").Dump();
    
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