using Molim.Backend.API.BusinessLayer.Data;
using Molim.Backend.API.BusinessLayer.Data.Entities;
using Molim.Backend.API.BusinessLayer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Molim.Backend.API.BusinessLayer.Data.Entities.Enums;
using Molim.Backend.API.BusinessLayer.Services.Authentication.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Molim.Backend.API.Utils.Cryptography;
using Molim.Backend.API.BusinessLayer.Interfaces;
using Molim.Backend.API.BusinessLayer.Data.Queries.Accounts;
using Molim.Backend.API.BusinessLayer.Services.Pazienti.Models;
using Molim.Backend.API.BusinessLayer.Services.Patologie.Models;
using Molim.Backend.API.BusinessLayer.Data.Queries.Patologie;
using Molim.Backend.API.BusinessLayer.Services.Algoritmi.Models;

namespace Molim.Backend.API.BusinessLayer.Services.Patologie
{
    public class AlgoritmiService : BaseService
    {

        public AlgoritmiService(MolimDb db, Configuration conf, IAuthenticationProvider auth, ILogger logger) : base(db, conf, auth, logger)
        {

        }

        public AlgoritmiService(BaseService b) : base(b)
        {

        }

        public IEnumerable<AlgoritmoProxy> GetAlgoritmi()
        {
            _logger.LogInformation("Requesting algoritmi");

            if (!CheckPermissionBase(Permissions.ReadPatologie))
                throw new BusinessManagedException(ErrorCodes.Unauthorized.ToString());

            IEnumerable<AlgoritmoProxy> algoritmi = Database
                .GetAlgoritmi()
                .Select(x => new AlgoritmoProxy()
                {
                    Id = x.Id,
                    Descrizione = x.Descrizione,
                    EndpointRest = x.EndpointRest,
                    IdPatologia = x.IdPatologia,
                    IdTipoEsame = x.IdTipoEsame,
                    OggettoDiPredizione = x.OggettoDiPredizione,
                    Tipo = x.Tipo,
                    Features = x.Features.Select(f => new FeatureAlgoritmoProxy()
                    {
                        IdAlgoritmo = f.IdAlgoritmo,
                        IdFeature = f.IdFeature,
                        Obbligatorio = f.Obbligatorio
                    })
                })
                .ToList();

            return algoritmi;
        }
    }
}
