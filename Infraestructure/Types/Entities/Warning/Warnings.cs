using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedDataProjectAPI.Infraestructure.Types.Entities.Warning
{
    public class Warnings
    {
        public Main main { get; set; }

        public Warnings()
        {
            this.main = new Main();
        }
    }
}
