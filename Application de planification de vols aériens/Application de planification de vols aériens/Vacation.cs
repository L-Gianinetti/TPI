using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_de_planification_de_vols_aériens
{
    public class Vacation
    {
        private DateTime startDate;
        private DateTime endDate;
        private Pilot pilot;

        public Vacation(DateTime startDate, DateTime endDate, Pilot pilot)
        {
            this.startDate = startDate;
            this.endDate = endDate;
            this.pilot = pilot;
        }
    }
}
