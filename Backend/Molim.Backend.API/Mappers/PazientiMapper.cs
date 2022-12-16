using Molim.Backend.API.BusinessLayer.Services.Authentication.Models;
using Molim.Backend.API.BusinessLayer.Services.Pazienti.Models;
using Molim.Backend.API.DTO;
using Molim.Backend.API.DTO.Accounts;
using Molim.Backend.API.DTO.Pazienti;
using Molim.Backend.API.DTO.Pazienti.Diagnosi;
using Molim.Backend.API.DTO.Pazienti.Esami;
using Molim.Backend.API.DTO.Pazienti.Predizioni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Molim.Backend.API.Mappers
{
    public static class PazientiMapper
    {
        public static PazienteDTO Map(PazienteProxy proxy)
        {
            if (proxy == null)
                return null;

            return new PazienteDTO()
            {
                AnnoNascita = proxy.AnnoNascita,
                City = proxy.City,
                CodiceFiscale = proxy.CodiceFiscale,
                CognomePaziente = proxy.CognomePaziente,
                Education = proxy.Education,
                IdPaziente = proxy.IdPaziente,
                Indirizzo = proxy.Indirizzo,
                IndirizzoMail = proxy.IndirizzoMail,
                NomePaziente = proxy.NomePaziente,
                NumeroCellulare = proxy.NumeroCellulare,
                Sesso = proxy.Sesso
            };

        }

        public static PazienteProxy Map(PazienteDTO dto)
        {
            if (dto == null)
                return null;

            return new PazienteProxy()
            {
                AnnoNascita = dto.AnnoNascita,
                City = dto.City,
                CodiceFiscale = dto.CodiceFiscale,
                CognomePaziente = dto.CognomePaziente,
                Education = dto.Education,
                IdPaziente = dto.IdPaziente,
                Indirizzo = dto.Indirizzo,
                IndirizzoMail = dto.IndirizzoMail,
                NomePaziente = dto.NomePaziente,
                NumeroCellulare = dto.NumeroCellulare,
                Sesso = dto.Sesso
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
                RegioniDiInteresse = proxy.RegioniDiInteresse?.Select(x => Map(x))
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
                Nome = dto.Nome,
                RegioniDiInteresse = dto.RegioniDiInteresse?.Select(x => Map(x))
            };
        }

        public static RegionOfInterestDTO Map(RegionOfInterestProxy proxy)
        {
            if (proxy == null)
                return null;

            return new RegionOfInterestDTO()
            {
                Dimensione = proxy.Dimensione,
                ID = proxy.ID,
                IdImmagine = proxy.IdImmagine,
                NomeFile = proxy.NomeFile,
                NomeFileImmagine = proxy.NomeFileImmagine
            };
        }

        public static RegionOfInterestProxy Map(RegionOfInterestDTO dto)
        {
            if (dto == null)
                return null;

            return new RegionOfInterestProxy()
            {
                Dimensione = dto.Dimensione,
                ID = dto.ID,
                IdImmagine = dto.IdImmagine,
                NomeFile = dto.NomeFile,
                NomeFileImmagine = dto.NomeFileImmagine
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

        public static DiagnosiDTO Map(DiagnosiProxy proxy)
        {
            if (proxy == null)
                return null;

            return new DiagnosiDTO()
            {
                ID = proxy.ID,
                Data = proxy.Data,
                DescrizionePatologia = proxy.DescrizionePatologia,
                DescrizionePaziente = proxy.DescrizionePaziente,
                Esito = proxy.Esito,
                IdPatologia = proxy.IdPatologia,
                IdPaziente = proxy.IdPaziente
            };
        }

        public static DiagnosiProxy Map(DiagnosiDTO dto)
        {
            if (dto == null)
                return null;

            return new DiagnosiProxy()
            {
                ID = dto.ID,
                Data = dto.Data,
                DescrizionePatologia = dto.DescrizionePatologia,
                DescrizionePaziente = dto.DescrizionePaziente,
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
                RichiedeImmagini = proxy.RichiedeImmagini,
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
                RichiedeImmagini = dto.RichiedeImmagini,
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
