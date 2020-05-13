using CoAP.Server.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAp_Server
{
    class HelloWorldResource : Resource
    {
        
        // use "helloworld" as the path of this resource
        public HelloWorldResource() : base("helloworld")
        {
            // set a friendly title
            Attributes.Title = "GET a friendly greeting!";
        }

        // override this method to handle GET requests
        protected override void DoGet(CoapExchange exchange)
        {
            // now we get a request, respond it
            exchange.Respond("Get_Hello World!   "+DateTime.Now.ToString());
        }

        // override this method to handle POST requests
        protected override void DoPost(CoapExchange exchange)
        {
            // now we get a request, respond it
            exchange.Respond("Post_Hello World!");
        }

        // override this method to handle PUT requests
        protected override void DoPut(CoapExchange exchange)
        {
            // now we get a request, respond it
            exchange.Respond("Put_Hello World!");
        }

        // override this method to handle DELETE requests
        protected override void DoDelete(CoapExchange exchange)
        {
            // now we get a request, respond it
            exchange.Respond("Delete_Hello World!");
        }
    }
}
