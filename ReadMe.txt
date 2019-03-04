This is just a little REST api for pots and potters. It came out of an idea to build a website for selling second hand pots, distinct from ebay and other on-line stores.

What it has turned into is a small project to learn some ASP.NET and up-to-date software practices.  So using Controllers for the rest bit, interfacing with MySQL, using NUnit for testing and Moq for mock objects.  It isn't perfect but it's the first I've done since 2008 (and probably longer since the later work at Active/Booking.com wasn't really tested that much.)

A note:  To make the Post part work, you have to use a string in double quotes, with its own double quotes escaped.  Like this one:

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(@"https://localhost:44376/potters/potters");
            client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "potters");
            string x = "\"{\\\"Id\\\":0,\\\"Name\\\":\\\"Robin Welch\\\",\\\"Country\\\":\\\"England\\\"}\"";
            var stringcontent = new StringContent(x);
            Console.WriteLine(x);
            stringcontent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            request.Content = stringcontent;
            var response = client.SendAsync(request);

In fact, that's a whole request right there, with the content type set to application/json and the accepted type set the same, with a fully escaped and quoted string.

I'm sure there must be a way of setting these for each controller - what if you didn't want to use json?  But out of the box, this is the only way I could see of getting it to pass all the way through to my controller class.

Also, a shout out to SOAP-UI - https://www.soapui.org/ - a nice graphical tool for testing HTTP methods.
