using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLMessage
{
    public class CLMessage
    {
        public string GetMessage { get; private set; }

        public void SetMessage(string message)
        {
            if (message.Length > 0 && !string.IsNullOrEmpty(message))
            {
                GetMessage = message;


                Console.WriteLine(GetMessage);
            }
        }
    }
}
