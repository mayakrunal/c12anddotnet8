HttpClient client = new();

HttpResponseMessage response = await client.GetAsync("https://google.com");

WriteLine("Google's home page has {0:N0} bytes.", response.Content.Headers.ContentLength);