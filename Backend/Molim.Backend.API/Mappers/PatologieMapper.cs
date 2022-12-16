using Molim.Backend.API.BusinessLayer.Services.Authentication.Models;
using Molim.Backend.API.BusinessLayer.Services.Patologie.Models;
using Molim.Backend.API.BusinessLayer.Services.Pazienti.Models;
using Molim.Backend.API.DTO;
using Molim.Backend.API.DTO.Accounts;
using Molim.Backend.API.DTO.Patologie;
using Molim.Backend.API.DTO.Pazienti;
using Molim.Backend.API.DTO.Pazienti.Esami;
using Molim.Backend.API.DTO.Pazienti.Predizioni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Molim.Backend.API.Mappers
{
    public static class PatologieMapper
    {
        public static PatologiaDTO Map(PatologiaProxy proxy)
        {
            if (proxy == null)
                return null;

            return new PatologiaDTO()
            {
                ID = proxy.ID,
                Descrizione = proxy.Descrizione,
                TipiEsami = proxy.TipiEsami?.Select(x => Map(x))
            };

        }

        public static PatologiaProxy Map(PatologiaDTO dto)
        {
            if (dto == null)
                return null;

            return new PatologiaProxy()
            {
                ID = dto.ID,
                Descrizione = dto.Descrizione,
                TipiEsami = dto.TipiEsami?.Select(x => Map(x))
            };
        }

        public static TipologiaEsameDTO Map(TipologiaEsameProxy proxy)
        {
            if (proxy == null)
                return null;

            return new TipologiaEsameDTO()
            {
                Descrizione = proxy.Descrizione,
                Features = proxy.Features?.Select(x => Map(x)),
                IdPatologia = proxy.IdPatologia,
                IdTipologiaEsame = proxy.IdTipologiaEsame,
                RichiedeImmagini = proxy.RichiedeImmagini
            };

        }

        public static TipologiaEsameProxy Map(TipologiaEsameDTO dto)
        {
            if (dto == null)
                return null;

            return new TipologiaEsameProxy()
            {
                Descrizione = dto.Descrizione,
                Features = dto.Features?.Select(x => Map(x)),
                IdPatologia = dto.IdPatologia,
                IdTipologiaEsame = dto.IdTipologiaEsame,
                RichiedeImmagini = dto.RichiedeImmagini
            };
        }

        public static FeatureDTO Map(FeatureProxy proxy)
        {
            if (proxy == null)
                return null;

            return new FeatureDTO()
            {
               Id = proxy.Id,
               IdTipologiaEsame = proxy.IdTipologiaEsame,
               IdPatologia = proxy.IdPatologia,
               DescrizionePatologia = proxy.DescrizionePatologia,
               DescrizioneTipologiaEsame = proxy.DescrizioneTipologiaEsame,
               IdFeature = proxy.IdFeature,
               TipoValore = proxy.TipoValore,
               ValoreMassimo = proxy.ValoreMassimo,
               ValoreMinimo = proxy.ValoreMinimo,
               ValoriAmmessi = proxy.ValoriAmmessi
            };

        }

        public static FeatureProxy Map(FeatureDTO dto)
        {
            if (dto == null)
                return null;

            return new FeatureProxy()
            {
                Id = dto.Id,
                IdTipologiaEsame = dto.IdTipologiaEsame,
                IdPatologia = dto.IdPatologia,
                DescrizionePatologia = dto.DescrizionePatologia,
                DescrizioneTipologiaEsame = dto.DescrizioneTipologiaEsame,
                IdFeature = dto.IdFeature,
                TipoValore = dto.TipoValore,
                ValoreMassimo = dto.ValoreMassimo,
                ValoreMinimo = dto.ValoreMinimo,
                ValoriAmmessi = dto.ValoriAmmessi
            };
        }

        public static FeatureEsameDTO Map(FeatureEsameProxy proxy)
        {
            if (proxy == null)
                return null;

            return new FeatureEsameDTO()
            {
                IdFeature = proxy.IdFeature,
                DataFineValidita = proxy.DataFineValidita,
                DataInizioValidita = proxy.DataInizioValidita,
                Descrizione = proxy.Descrizione,
                TipoValore = proxy.TipoValore,
                Valore = proxy.Valore
            };
        }

        public static FeatureEsameProxy Map(FeatureEsameDTO dto)
        {
            if (dto == null)
                return null;

            return new FeatureEsameProxy()
            {
                IdFeature = dto.IdFeature,
                DataFineValidita = dto.DataFineValidita,
                DataInizioValidita = dto.DataInizioValidita,
                Descrizione = dto.Descrizione,
                TipoValore = dto.TipoValore,
                Valore = dto.Valore
            };
        }

        public static ImmagineDTO Map(ImmagineProxy proxy)
        {
            if (proxy == null)
                return null;

            return new ImmagineDTO()
            {
                DataCaricamento = proxy.DataCaricamento,
                Dimensione = proxy.Dimensione,
                ID = proxy.ID,
                IdEsame = proxy.IdEsame,
                Nome = proxy.Nome,
                Features = proxy.Features?.Select(x => Map(x)),
                //RegioniDiInteresse = 
            };
        }

        public static ImmagineProxy Map(ImmagineDTO dto)
        {
            if (dto == null)
                return null;

            return new ImmagineProxy()
            {
                DataCaricamento = dto.DataCaricamento,
                Dimensione = dto.Dimensione,
                Features = dto.Features?.Select(x => Map(x)),
                ID = dto.ID,
                IdEsame = dto.IdEsame,
                Nome = dto.Nome
            };
        }

        public static PredizioneDTO Map(PredizioneProxy proxy)
        {
            if (proxy == null)
                return null;

            return new PredizioneDTO()
            {
                ID = proxy.ID,
                DataRichiesta = proxy.DataRichiesta,
                DescrizioneAlgoritmo = proxy.DescrizioneAlgoritmo,
                DescrizionePatologia = proxy.DescrizionePatologia,
                DescrizionePaziente = proxy.DescrizionePaziente,
                Esito = proxy.Esito,
                IdAlgoritmo = proxy.IdAlgoritmo,
                IdPatologia = proxy.IdPatologia,
                IdPaziente = proxy.IdPaziente,
                EsitoPredizione = proxy.EsitoPredizione
            };
        }

        public static PredizioneProxy Map(PredizioneDTO dto)
        {
            if (dto == null)
                return null;

            return new PredizioneProxy()
            {
                ID = dto.ID,
                DataRichiesta = dto.DataRichiesta,
                DescrizioneAlgoritmo = dto.DescrizioneAlgoritmo,
                DescrizionePatologia = dto.DescrizionePatologia,
                DescrizionePaziente = dto.DescrizionePaziente,
                EsitoPredizione = dto.EsitoPredizione,
                IdAlgoritmo = dto.IdAlgoritmo,
                IdPatologia = dto.IdPatologia,
                IdPaziente = dto.IdPaziente,
                Esito = dto.Esito
            };
        }

        public static EsamePazienteDTO Map(EsamePazienteProxy proxy)
        {
            if (proxy == null)
                return null;

            return new EsamePazienteDTO()
            {
                Data = proxy.Data,
                DescrizionePaziente = proxy.DescrizionePaziente,
                DescrizionePatologia = proxy.DescrizionePatologia,
                DescrizioneTipoEsame = proxy.DescrizioneTipoEsame,
                IdEsame = proxy.IdEsame,
                IdPaziente = proxy.IdPaziente,
                IdPatologia = proxy.IdPatologia,
                IdTipoEsame = proxy.IdTipoEsame,
                Features = proxy.Features?.Select(f => Map(f)),
                Immagini = proxy.Immagini?.Select(i => Map(i))
            };
        }

        public static EsamePazienteProxy Map(EsamePazienteDTO dto)
        {
            if (dto == null)
                return null;

            return new EsamePazienteProxy()
            {
                Data = dto.Data,
                DescrizionePaziente = dto.DescrizionePaziente,
                DescrizionePatologia = dto.DescrizionePatologia,
                DescrizioneTipoEsame = dto.DescrizioneTipoEsame,
                IdEsame = dto.IdEsame,
                IdPaziente = dto.IdPaziente,
                IdPatologia = dto.IdPatologia,
                IdTipoEsame = dto.IdTipoEsame,
                Features = dto.Features?.Select(f => Map(f)),
                Immagini = dto.Immagini?.Select(i => Map(i))
            };
        }


    }
}
