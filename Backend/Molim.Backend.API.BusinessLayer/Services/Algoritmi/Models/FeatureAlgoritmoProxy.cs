using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Services.Algoritmi.Models
{
    public class FeatureAlgoritmoProxy
    {
        public int IdAlgoritmo { get; set; }
        public int IdFeature { get; set; }
        public bool Obbligatorio { get; set; }
    }
}
