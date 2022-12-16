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

namespace Molim.Backend.API.BusinessLayer.Services.Patologie
{
    public class PatologieService : BaseService
    {

        public PatologieService(MolimDb db, Configuration conf, IAuthenticationProvider auth, ILogger logger) : base(db, conf, auth, logger)
        {

        }

        public PatologieService(BaseService b) : base(b)
        {

        }

        public IEnumerable<PatologiaProxy> GetPatologie()
        {
            _logger.LogInformation("Requesting patologie");

            if (!CheckPermissionBase(Permissions.ReadPatologie))
                throw new BusinessManagedException(ErrorCodes.Unauthorized.ToString());

            var tipiEsami = Database.TipiEsami.AsNoTracking().ToList();
            var features = Database.Features.AsNoTracking().ToList();

            IEnumerable<PatologiaProxy> patologie = Database
                .GetPatologie()
                .Select(x => new PatologiaProxy()
                {
                    ID = x.IdPatologia,
                    Descrizione = x.Descrizione,
                    /*TipiEsami = //tipiEsami.Where(te => te.IdPatologia == x.IdPatologia)
                                x.TipiEsami
                                         .Select(tipoEsame => new TipologiaEsameProxy()
                    {
                        Descrizione = tipoEsame.Descrizione,
                        IdPatologia = tipoEsame.IdPatologia,
                        IdTipologiaEsame = tipoEsame.IdTipoEsame,
                        RichiedeImmagini = tipoEsame.RichiedeImmagini,
                        Features = tipoEsame.Features//features.Where(f => f.IdPatologia == x.IdPatologia && f.IdTipoEsame == tipoEsame.IdTipoEsame)
                                           .Select(feature => new FeatureProxy()
                        {
                            DescrizionePatologia = x.Descrizione,//feature.Patologia.Descrizione,
                            DescrizioneTipologiaEsame = tipoEsame.Descrizione,
                            IdFeature = feature.IdFeature,
                            IdPatologia = feature.IdPatologia,
                            IdTipologiaEsame = tipoEsame.IdTipoEsame,
                            TipoValore = ((TipiValoreTest)feature.TipoValore).ToString(), // NUMERICO || TESTUALE
                            ValoreMassimo = feature.ValoreMax,
                            ValoreMinimo = feature.ValoreMin,
                            Regex = feature.Regex,                            
                        })
                    })*/
                })
                .ToList();

            // FILL DEI VALORI AMMESSI PER LE FEATURE

            if (patologie != null)
                foreach (var patologia in patologie)
                {
                    patologia.TipiEsami = tipiEsami.Where(te => te.IdPatologia == patologia.ID)
                                         .Select(tipoEsame => new TipologiaEsameProxy()
                                         {
                                             Descrizione = tipoEsame.Descrizione,
                                             IdPatologia = tipoEsame.IdPatologia,
                                             IdTipologiaEsame = tipoEsame.IdTipoEsame,
                                             RichiedeImmagini = tipoEsame.RichiedeImmagini,
                                             Features = features.Where(f => f.IdPatologia == patologia.ID && f.IdTipoEsame == tipoEsame.IdTipoEsame)
                                           .Select(feature => new FeatureProxy()
                                           {
                                               DescrizionePatologia = patologia.Descrizione,//feature.Patologia.Descrizione,
                                               DescrizioneTipologiaEsame = tipoEsame.Descrizione,
                                               IdFeature = feature.IdFeature,
                                               IdPatologia = feature.IdPatologia,
                                               IdTipologiaEsame = tipoEsame.IdTipoEsame,
                                               TipoValore = ((TipiValoreTest)feature.TipoValore).ToString(), // NUMERICO || TESTUALE
                                               ValoreMassimo = feature.ValoreMax,
                                               ValoreMinimo = feature.ValoreMin,
                                               Regex = feature.Regex,
                                           })
                                         });

                    if (patologia.TipiEsami != null)
                        foreach (var tipoEsame in patologia.TipiEsami)
                            if (tipoEsame.Features != null)
                                foreach (var feature in tipoEsame.Features)
                                    if (feature.Regex != null)
                                        feature.ValoriAmmessi = feature.Regex?.Split(';')?.ToDictionary(k => k.Split('|')[0], v => v.Split('|')[1]);
                }
            

            return patologie;
        }
    }
}
