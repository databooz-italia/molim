using Molim.Backend.API.BusinessLayer.Services.Algoritmi.Models;
using Molim.Backend.API.BusinessLayer.Services.Authentication.Models;
using Molim.Backend.API.BusinessLayer.Services.Patologie.Models;
using Molim.Backend.API.BusinessLayer.Services.Pazienti.Models;
using Molim.Backend.API.DTO;
using Molim.Backend.API.DTO.Accounts;
using Molim.Backend.API.DTO.Algoritmi;
using Molim.Backend.API.DTO.Patologie;
using Molim.Backend.API.DTO.Pazienti;
using Molim.Backend.API.DTO.Pazienti.Esami;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Molim.Backend.API.Mappers
{
    public static class AlgoritmiMapper
    {
        public static AlgoritmoDTO Map(AlgoritmoProxy proxy)
        {
            if (proxy == null)
                return null;

            return new AlgoritmoDTO()
            {
                Id = proxy.Id,
                EndpointRest = proxy.EndpointRest,
                IdPatologia = proxy.IdPatologia,
                IdTipoEsame = proxy.IdTipoEsame,
                OggettoDiPredizione = proxy.OggettoDiPredizione,
                Tipo = proxy.Tipo,
                Descrizione = proxy.Descrizione,
                Features = proxy.Features?.Select(y => Map(y))
            };
        }

        public static AlgoritmoProxy Map(AlgoritmoDTO dto)
        {
            if (dto == null)
                return null;

            return new AlgoritmoProxy()
            {
                Id = dto.Id,
                EndpointRest = dto.EndpointRest,
                IdPatologia = dto.IdPatologia,
                IdTipoEsame = dto.IdTipoEsame,
                OggettoDiPredizione = dto.OggettoDiPredizione,
                Tipo = dto.Tipo,
                Descrizione = dto.Descrizione,
                Features = dto.Features?.Select(y => Map(y))
            };
        }

        public static FeatureAlgoritmoDTO Map(FeatureAlgoritmoProxy proxy)
        {
            if (proxy == null)
                return null;

            return new FeatureAlgoritmoDTO()
            {
                IdFeature = proxy.IdFeature,
                IdAlgoritmo = proxy.IdAlgoritmo,
                Obbligatorio = proxy.Obbligatorio
            };
        }

        public static FeatureAlgoritmoProxy Map(FeatureAlgoritmoDTO dto)
        {
            if (dto == null)
                return null;

            return new FeatureAlgoritmoProxy()
            {
                IdFeature = dto.IdFeature,
                IdAlgoritmo = dto.IdAlgoritmo,
                Obbligatorio = dto.Obbligatorio
            };
        }
    }
}
