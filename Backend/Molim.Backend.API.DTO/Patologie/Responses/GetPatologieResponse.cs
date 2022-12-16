using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.DTO.Patologie.Responses
{
    public class GetPatologieResponse
    {
        public IEnumerable<PatologiaDTO> Patologie { get; set; }
    }
}
