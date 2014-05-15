using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace com.traitify.net.TraitifyLibrary
{
    public class AuthHandler : DelegatingHandler
    {
        public AuthHandler(string secretKey)
            : base(new HttpClientHandler())
        {
            _secretKey = secretKey;
        }

        private readonly string _secretKey;

        protected override System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            request.Headers.Add("Authorization", "Basic " + this._secretKey + ":x");
            return base.SendAsync(request, cancellationToken);
        }
    }
}
