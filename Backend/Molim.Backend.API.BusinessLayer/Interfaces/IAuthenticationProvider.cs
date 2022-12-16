using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Interfaces
{
    public interface IAuthenticationProvider
    {
        int? GetLoggedAccountId();
        string GetLoggedAccountUsername();        
        string GetMachineID();
    }
}
