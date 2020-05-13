using System;
using System.Threading;
using CoAP.Server.Resources;

namespace CoAP.Examples.Resources
{
    class TimeOfDayResource : Resource
    {
        private Timer _timer;
        private DateTime _now;

        public TimeOfDayResource(String name)
            : base(name)
        {
            Attributes.Title = "GET the TimeOfDay";
            Attributes.AddResourceType("TimeOfDay");
            Observable = true;

            _timer = new Timer(Timed, null, 0, 1000);

        }

        private void Timed(Object o)
        {
            _now = DateTime.Now;
            Changed();
        }

        protected override void DoGet(CoapExchange exchange)
        {
            exchange.Respond(StatusCode.Content, _now.TimeOfDay.ToString(), MediaType.TextPlain);
        }
    }
}