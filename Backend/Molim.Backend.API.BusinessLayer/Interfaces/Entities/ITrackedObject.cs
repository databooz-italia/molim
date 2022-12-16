using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Interfaces.Entities
{
    public interface ITrackedObject
    {
        int? CreatorAccount_ID { get; set; }
        int? UpdaterAccount_ID { get; set; }
        DateTime CreationDate { get; set; }
        DateTime LastUpdateDate { get; set; }
    }
}
