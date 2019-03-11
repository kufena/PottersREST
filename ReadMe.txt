This is just a little REST api for pots and potters. It came out of an idea to build a website for selling second hand pots, distinct from ebay and other on-line stores.

What it has turned into is a small project to learn some ASP.NET and up-to-date software practices.  So using Controllers for the rest bit, interfacing with MySQL, using NUnit for testing and Moq for mock objects.  It isn't perfect but it's the first I've done since 2008 (and probably longer since the later work at Active/Booking.com wasn't really tested that much.)

I have reduced the number of controllers to one.  Previously there were two - one for pots and one for potters, but the more I thought about the hypermedia view, it made more sense to do everything under the guise of potters.  So now, the /potters/potters URL will give a list of potters, which contains links to individual potters of the for /potters/potters/{id}.  Now, you probably won't want to see all pots, but you can see pots for individual potters using /potters/potters/{id}/pots and this gives a list of pots.  You can then use /potters/potters/{id}/pots/{potid} to see an individual pot.

To create a new potter, you POST to /potters/potters and to create a new pot for a particular potter, POST to /potters/potters/{id}/pots.  What about shared pots?  Well, how does that work anyway?  Then we're back to individual controllers, i guess.

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

In fact, that's a whole request right there, with the content type set to application/json and the accepted type set the same, with a fully escaped and quoted string.  You can also use application/vnd.collection+json if you want to use the collections pattern.  I've toyed with this idea but at the moment, it's fairly simple stuff to allow the use of a JSON library.  I haven't worked out how to set the content-type for a particular controller - I'm sure it isn't hard.

Also, a shout out to SOAP-UI - https://www.soapui.org/ - a nice graphical tool for testing HTTP methods.
