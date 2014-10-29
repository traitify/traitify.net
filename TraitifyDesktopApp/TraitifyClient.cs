using com.traitify.net.TraitifyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraitifyDesktopApp
{
    public class TraitifyClient
    {
        // These settings are available through the developer portal @ developer.traitify.com
        private string _host = "add_api_host";
        private string _publicKey = "your_public_key_here";
        private string _secretKey = "your_secret_key_here";

        private Traitify _traitify;
        public Traitify traitify
        {
            get { return _traitify; }
        }

        public TraitifyClient()
        {
            if(_host == "add_api_host")
            {
                throw new Exception("Please add the API host and your API keys to TraitifyClient class that you created at developer.traitify.com");
            }
            else
            {
                _traitify = new Traitify(_host, _publicKey, _secretKey, "v1");
            }
        }
    }
}
