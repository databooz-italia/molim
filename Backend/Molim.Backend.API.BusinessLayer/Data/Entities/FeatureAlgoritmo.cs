using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Data.Entities
{
    public class FeatureAlgoritmo
    {
        public int IdAlgoritmo { get; set; }
        public int IdFeature { get; set; }
        public bool Obbligatorio { get; set; }

        public virtual Algoritmo Algoritmo { get; set; }
        public virtual Feature Feature { get; set; }
    }
}
