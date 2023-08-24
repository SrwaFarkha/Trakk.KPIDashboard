using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Trakk.WebApi.DatabaseModels.Models
{
    public partial class Trakker
    {
        [NotMapped]
        public ICollection<ActiveAlert> ActiveAlerts => TrakkerEvents
            .Where(x => x.ActiveAlert != null)
            .Select(x => x.ActiveAlert).ToList();
    }
}
