﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.DTO.Algoritmi
{
    public class FeatureAlgoritmoDTO
    {
        public int IdAlgoritmo { get; set; }
        public int IdFeature { get; set; }
        public bool Obbligatorio { get; set; }
    }
}
