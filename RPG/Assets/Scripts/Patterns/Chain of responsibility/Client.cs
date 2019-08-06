using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.Chain_of_responsibility
{
    class Client
    {
        public string Disease { get; set; }

        public Client(string disease)
        {
            Disease = disease;
        }
    }
}
