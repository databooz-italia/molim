using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Interfaces.Entities
{
    public interface IConcurrencyObject
    {
        long Version { get; set; }
    }
}
