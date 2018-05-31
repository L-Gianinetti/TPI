﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_de_planification_de_vols_aériens
{
    class MySQLException : Exception
    {
        /// <summary>
        /// Exceptions when inserting or updating data in DB
        /// </summary>
        /// <param name="message"></param>
        public MySQLException(string message) : base(message)
        {
           
        }
    }
}
