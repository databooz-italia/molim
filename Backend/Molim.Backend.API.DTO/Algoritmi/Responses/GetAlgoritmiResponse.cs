using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.DTO.Algoritmi.Responses
{
    public class GetAlgoritmiResponse
    {
        public IEnumerable<AlgoritmoDTO> Algoritmi { get; set; }
    }
}
