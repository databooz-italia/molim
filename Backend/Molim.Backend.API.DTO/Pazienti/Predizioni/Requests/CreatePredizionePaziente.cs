using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.DTO.Pazienti.Predizioni.Requests
{
    public class CreatePredizionePaziente
    {
        // idAlgoritmo, idPaziente, idImmagine, idRegioneDiInteresse, null, IdPatologia

        public int IdAlgoritmo { get; set; }
        public string IdPaziente { get; set; }
        public int? IdImmagine { get; set; }
        public int? IdRegioneDiInteresse { get; set; }
        public string IdPatologia { get; set; }
    }
}
