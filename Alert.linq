<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.WebRequest.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ServiceModel.Http.dll</Reference>
  <NuGetReference>Rock.Core.Newtonsoft</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net.Http.Headers</Namespace>
</Query>

static void Main()
{
    var http = new System.Net.Http.HttpClient();
	http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiIxMG8xQ0xVQ0M0aXAzVGc5MkN6emhtT0R5ZTV0cHZqNlJiVFB1bkdXS3EwPSIsInN1YiI6IjE2NjQiLCJuYW1lIjoiYWRtaW5AYmV0bGFiIiwicm9sZXMiOiJBZG1pbiwuLENvcmVTdXBwb3J0TWFuYWdlcixDcm1Ob3RpZmljYXRpb25Pbmx5LFVDU1VzZXJNYW5hZ2VyLEJldE9mZmljZVVzZXIsU3VwZXJ2aXNvcixDb3JlUGF5bWVudE1hbmFnZXIsQ29yZVJpc2tNYW5hZ2VyLFVDU0FkbWluLENyaXN0YXRhRXZlbnRNYW5hZ2VyLFVDU1JvbGVNYW5hZ2VyLENvcmVWaWV3ZXIsbWltb3Byb2hvZGlsLFJlcG9ydGluZ01hbmFnZXIsQ29yZVBheW1lbnRUcmFpbmVlLENyaXN0YXRhQWRtaW4sbmV3X3JvbGUsQ3Jpc3RhdGFTdXBlcnZpc29yLENybVN1cHBvcnRTdXBlcnZpc29yLENybVN1cHBvcnRWaXAsVFRHdWVzdCxCcm9hZGNhc3QsU0VPTWFuYWdlcixQYXltZW50c0FkbWluLENvcmVQbGF5ZXJNYW5hZ2VyLFJldGFpbFN5c3RlbUFkbWluLENvcmVTdXBwb3J0T3BlcmF0b3IsVHJhbnNsYXRvclN1cGVydmlzb3IsQ3Jpc3RhdGFUb3BMaXZlLFRyYW5zbGF0b3JBZG1pbixVQ1MsQ29yZVJlc3RyaWN0b3IsQ29yZUFudGlGcmF1ZE9wZXJhdG9yLFRyYW5zbGF0b3JNYW5hZ2VyLENybVVzZXIsU3BvcnRCb29rLENybSxGZWVkVHJhZGVyLFNycyxSZXBvcnRpbmcsQW50aUZyYXVkT3BlcmF0b3IsVHJhZGluZ1Rvb2xzLFRyYW5zbGF0b3JEZXZlbG9wZXIsQmV0T2ZmaWNlLENvcmVPcGVyYXRvcixTZWN1cml0eU9wZXJhdG9yLFRUUmVzdWx0c01hbmFnZXJBZG1pbixDcmlzdGF0YUNvbnRlbnRNYW5hZ2VyLFNwb3J0QWRtaW4sQ29yZVBheW1lbnRPcGVyYXRvcixDb3JlUUEyLFNlcnZpY2UsVFRBZG1pbixCZXRnZW5pdXMsU3BvcnRCZXRsYWJBZG1pbixDb3JlUUEsUHJlbWF0Y2hUcmFkZXIsQ3JtU3VwcG9ydCxMaXZlVHJhZGVyLFVDU1VzZXJFdmVudExvZyxDb3JlU3BvcnRzYm9vayxFZGl0b3IsQ29yZUFkbWluaXN0cmF0b3IsQlNTLFNldHRsZW1lbnRPcGVyYXRvcixiZXRzaG9wLENvcmUsQnJvYWRjYXN0T3BlcmF0b3IsU00sR2VuZXJhbCxTdGF0TWFuYWdlcixtaW1vcHJvaG9kaWxfcHJlZGVmLENybUFkbWluLFBheW1lbnRzLEpvdXJuYWxpc3QsQmV0T2ZmaWNlQWRtaW4sU3JzTWFuYWdlcixDcm1NYW5hZ2VyIiwicHJvdmlkZXIiOiJCZXRMYWIiLCJhdHRyaWJ1dGVzIjpbWyJwZXJtLmluZnJhLnRlc3QuMWQ3MWZlODQtNGYxOS00NjM2LTg2NTgtNTU2NjRjNzM2ZDM4Iiwie1widmVyXCI6MS4wLFwibGVuXCI6MyxcImJpdHNcIjpcIkJ3PT1cIn0iLDY3Ml0sWyJwZXJtLmNvcmUiLCJ7XCJ2ZXJcIjoxLjAsXCJsZW5cIjo2NixcImJpdHNcIjpcIi8vLy8vLy8vLy84RFwifSIsODA3XSxbInBlcm0ucWExIiwie1widmVyXCI6MS4wLFwibGVuXCI6MyxcImJpdHNcIjpcIkJ3PT1cIn0iLDc3Ml0sWyJwZXJtLnFhMiIsIntcInZlclwiOjEuMCxcImxlblwiOjIsXCJiaXRzXCI6XCJBdz09XCJ9Iiw3NzRdLFsicGVybS5pbmZyYS50ZXN0LjQ2Y2E0OGIwLTc2MjgtNDkwYi1hNTY3LTlmNGZjYThkMzY3MiIsIntcInZlclwiOjEuMCxcImxlblwiOjEsXCJiaXRzXCI6XCJBUT09XCJ9Iiw2NzRdLFsicGVybS5xYSIsIntcInZlclwiOjEuMCxcImxlblwiOjQsXCJiaXRzXCI6XCJBQT09XCJ9Iiw3NzhdLFsicGVybS5pbmZyYS5zc28iLCJ7XCJ2ZXJcIjoxLjAsXCJsZW5cIjoxMyxcImJpdHNcIjpcIi94OD1cIn0iLDc1M10sWyJwZXJtLmluZnJhLnVjcyIsIntcInZlclwiOjEuMCxcImxlblwiOjQwLFwiYml0c1wiOlwiLy8vLy8vOD1cIn0iLDgwOV0sWyJwZXJtLmluZnJhLnRlc3QuYmFkMjc5ZTktODFkYi00Zjk0LWJlNTMtNDAxMjJkZDc3NzJkIiwie1widmVyXCI6MS4wLFwibGVuXCI6MixcImJpdHNcIjpcIkF3PT1cIn0iLDY3MF0sWyJwZXJtLmluZnJhLnRlc3QuZGFhYjQ1YTQtZjU5OC00NTdlLWE2NzYtZDgwNjI3MmM0NDE1Iiwie1widmVyXCI6MS4wLFwibGVuXCI6MyxcImJpdHNcIjpcIkJ3PT1cIn0iLDY3Nl0sWyJwZXJtLnBheW1lbnRzIiwie1widmVyXCI6MS4wLFwibGVuXCI6NCxcImJpdHNcIjpcIkR3PT1cIn0iLDgzMV1dLCJuYmYiOjE1NDAzODU2NzYsImV4cCI6MTU3MTkyMTY3NiwiaXNzIjoidWF0LXNzby1iYWNrb2ZmaWNlLmhwLmNvbnN1bCJ9.VtKzTTtWjjXAVeJegNAYlKMe4jtJFQPFUthyJReWslt0O49Ez35F0UnoxCmWVadpgqhAqvCVlwIeH7oV1HTqStgBJ4ZJEEZwosZkEyn3Rn9R1QJbWb7UgA5zD9BNK2_LZy4rphhiPwRihwJ27FKmn2rVaF7PuwOJwC4BMrVR09nRUOGUHhkNkrkfdyP828vG-SF-Nrq1_L9sJ7LIlyp8-u_u7rUByyoSrt2Ruht79H7Ompr087Kvhb1jwX9CeCQwENWRhyj-CjVUZI8rNSJvl_BLfxZ_pwjVEnDf2REIlw-qH03v8ZUne7bbZUvKYs0-E8uws-oARpCEChUmzbkiIw");

    var response = http.GetStringAsync("http://settlement-monitor-service.hp.consul/alerts/event/BM_15160266").Result;
    var RootObject = JsonConvert.DeserializeObject<RootObject[]>(response);
	var join = (from list in RootObject
				//from hasNewOutcomeResult in list.alerts
				
	select new 
                { 
				list.selectionKey,
				list.alerts
				})
				.ToList().Dump();
                            
}



public class SettlementState
{
    public int totalBetItems { get; set; }
    public int unsettledBetItems { get; set; }
    public string settlement { get; set; }
}

public class Alerts
{
    public bool hasNewOutcomeResult { get; set; }
    public bool hasUnsettledBets { get; set; }
    public bool hasManuallySettledBets { get; set; }
    public bool hasOutdatedBets { get; set; }
    public SettlementState settlementState { get; set; }
}

public class RootObject
{
    public string lineItemId { get; set; }
    public string selectionKey { get; set; }
    public Alerts alerts { get; set; }
}