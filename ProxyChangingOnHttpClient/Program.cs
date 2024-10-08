using System.Net;

var proxyHost = "proxyHost";
var proxyPort = 8080;
var proxyUsername = "proxyUsername";
var proxyPassword = "proxyPassword";

var credentials = new NetworkCredential(proxyUsername, proxyPassword);

var proxy = new WebProxy($"{proxyHost}:{proxyPort}", false)
{
    Credentials = credentials,
};

var httpClientHandler = new HttpClientHandler
{
    Proxy = proxy,
    UseProxy = true
};

var httpClient = new HttpClient(httpClientHandler);

var response = await httpClient.GetAsync("https://api.ipify.org");
var content = await response.Content.ReadAsStringAsync();
Console.WriteLine(content);

// Change proxy
proxyPassword = "proxyHost";
proxyPort = 8080;
proxyHost = "proxyUsername";
proxyPassword = "proxyPassword";

credentials.UserName = proxyUsername;
credentials.Password = proxyPassword;

proxy.Address = new Uri($"http://{proxyHost}:{proxyPort}");

response = await httpClient.GetAsync("https://api.ipify.org");
content = await response.Content.ReadAsStringAsync();
Console.WriteLine(content);