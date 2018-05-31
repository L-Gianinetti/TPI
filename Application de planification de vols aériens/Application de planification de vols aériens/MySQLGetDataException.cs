using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_de_planification_de_vols_aériens
{
    class MySQLGetDataException : Exception
    {
        /// <summary>
        /// Exceptions when selecting data in DB
        /// </summary>
        /// <param name="message"></param>
        public MySQLGetDataException(string message) : base(message)
        {
            message = "Erreur lors de la récupération d'informations dans la base de données";
        }
    }
}
