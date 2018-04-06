using CaliburnExample.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnExample.EventAggregator.Messages
{
    public class DisplayCarDetailMessage
    {
        private Car _car;
        public Car Car
        {
            get { return _car; }
        }


        public DisplayCarDetailMessage(Car car)
        {
            _car = car;
        }

    }
}
