using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.UI.Messages
{
    public class NavigationMessage
    {
        public Type ViewModelType { get; }
        public NavigationMessage(Type viewModelType) => ViewModelType = viewModelType;
    }
}
