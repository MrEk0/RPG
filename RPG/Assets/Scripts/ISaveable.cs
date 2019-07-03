using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


interface ISaveable
{
    object CaptureState();
    void RestoreState(object state);
}

