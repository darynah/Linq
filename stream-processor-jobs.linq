<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <NuGetReference>Rock.Core.Newtonsoft</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()
{
    var http = new System.Net.Http.HttpClient();
    var response = http.GetStringAsync("http://stream-processor.hp.consul/api/Job").Result;
    var Status = JsonConvert.DeserializeObject<Status[]>(response);
	var join = (from list in Status
	select new 
                {
				list.name,
				type = list.source.type,
				topic = list.source.topic,
				})
				.OrderBy(a => a.name)
				.Dump();
	
} 
    public class Status
    {
        public string name { get; set; }	
		public Source source { get; set; }
	}
	 public class Source
    {
	public string type { get; set; }	
	public string topic { get; set; }	
	public string server_url { get; set; }	
	}
	