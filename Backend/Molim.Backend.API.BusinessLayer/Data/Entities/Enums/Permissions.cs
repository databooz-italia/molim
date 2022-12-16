using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Data.Entities.Enums
{
    public enum Permissions
    {
        Administrator,

        //Accounts CRUD
        ReadAccounts,
        CreateAccounts,
        UpdateAccounts,
        DeleteAccounts,

        //PAZIENTI CRUD
        ReadPazienti,
        CreatePazienti,
        UpdatePazienti,
        DeletePazienti,

        //ESAMI PAZIENTI
        ReadEsamiPazienti,

        //PATOLOGIE
        ReadPatologie,
        UploadImmagineEsame
    }
}
