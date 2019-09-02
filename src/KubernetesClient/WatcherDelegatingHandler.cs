using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;

namespace k8s
{
    /// <summary>
    /// This HttpDelegatingHandler is to rewrite the response and return first line to autorest client
    /// then use WatchExt to create a watch object which interact with the replaced http response to get watch works.
    /// </summary>
    internal class WatcherDelegatingHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var originResponse = await base.SendAsync(request, cancellationToken);

            if (originResponse.IsSuccessStatusCode)
            {
                var query = QueryHelpers.ParseQuery(request.RequestUri.Query);

                if (query.TryGetValue("watch", out var values) && values.Any(v => v == "true"))
                {
                    originResponse.Content = new LineSeparatedHttpContent(originResponse.Content);
                }
            }
            return originResponse;
        }

        internal class LineSeparatedHttpContent : HttpContent
        {
            private readonly HttpContent _originContent;

            public LineSeparatedHttpContent(HttpContent originContent)
            {
                _originContent = originContent;
            }

            internal StreamReader StreamReader { get; private set; }

            protected override async Task SerializeToStreamAsync(Stream stream, TransportContext context)
            {
                // attach a new StreamReader instance to allow 
                // the watcher to read each line incrementally from the response stream
                StreamReader = new StreamReader(await _originContent.ReadAsStreamAsync());

                // note: do not insert anything into the stream
                // this will cause the initial API call to return
                // an empty object.  All change notifications will
                // be handled by the watcher itself.
            }

            protected override bool TryComputeLength(out long length)
            {
                length = 0;
                return false;
            }
        }
    }
}
