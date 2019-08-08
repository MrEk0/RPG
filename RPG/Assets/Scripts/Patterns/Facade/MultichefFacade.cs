using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.Facade
{
    class MultichefFacade
    {
        Merging merging;
        Evaporation evaporation;
        Heating heating;

        public MultichefFacade(Merging merg, Evaporation vap, Heating heat)
        {
            merging = merg;
            evaporation = vap;
            heating = heat;
        }

        public void Start()
        {
            merging.Mix();
            evaporation.OpenValve();
            heating.IncreaseTemperature();
        }

        public void Finish()
        {
            heating.DeacreaseTemperature();
            evaporation.CloseValve();
        }
    }
}
