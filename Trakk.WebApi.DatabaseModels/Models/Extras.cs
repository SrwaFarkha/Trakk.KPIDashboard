using System;

namespace Trakk.WebApi.DatabaseModels.Models
{
    public class Extras
    {
        public int Id { get; set; }
        public int TrakkerEventId { get; set; }
        public string TargetType { get; set; }
        public string Value { get; set; }

        public Type GetTargetType() => Type.GetType(TargetType);

    }


}