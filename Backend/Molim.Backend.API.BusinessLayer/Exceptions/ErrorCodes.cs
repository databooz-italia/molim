using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Exceptions
{
    public enum ErrorCodes
    {
        BadRequest,
        DuplicateUsername,
        NotFound,
        Unauthorized,
        NoBookingsLeft,
        AuthFail,
        DuplicateAccountType,
        CannotDeleteRelated,
        HorseBusy,
        DuplicateHorse,
        DuplicatePaziente
    }
}
