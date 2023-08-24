using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class JobEmailAddress : IEntity
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }

        public int JobId { get; set; }
        public virtual Job Job { get; set; }
    }
}
