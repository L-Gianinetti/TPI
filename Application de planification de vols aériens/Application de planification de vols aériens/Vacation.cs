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

        #region accessors
        public DateTime StartDate
        {
            get
            {
                return startDate;
            }

            set
            {
                startDate = value;
            }
        }

        public DateTime EndDate
        {
            get
            {
                return endDate;
            }

            set
            {
                endDate = value;
            }
        }

        public Pilot Pilot
        {
            get
            {
                return pilot;
            }

            set
            {
                pilot = value;
            }
        }
        #endregion

        public Pilot Pilot1
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public Vacation(DateTime startDate, DateTime endDate, Pilot pilot)
        {
            this.startDate = startDate;
            this.endDate = endDate;
            this.pilot = pilot;
        }
    }
}
