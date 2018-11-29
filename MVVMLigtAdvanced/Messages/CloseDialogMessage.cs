using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMLigtAdvanced.Messages
{
    class CloseDialogMessage
    {
        public string WindowName;

        public CloseDialogMessage(string v)
        {
            this.WindowName = v;
        }
    }
}
