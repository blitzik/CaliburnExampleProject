using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnExample.EventAggregator.Messages
{
    public class ChangeViewMessage
    {
        private string _viewModelName;
        public string ViewModelName
        {
            get { return _viewModelName; }
        }


        public ChangeViewMessage(string viewName)
        {
            _viewModelName = viewName;
        }
    }
}
