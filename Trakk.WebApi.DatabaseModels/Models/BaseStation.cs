

namespace Trakk.WebApi.DatabaseModels.Models
{
    public class BaseStation : IEntity
    {
        public int BaseStationId { get; set; } // BaseStationId (Primary key)
        public string IdetityCode { get; set; } // IdetityCode (length: 30)
        public int PositionId { get; set; } // PositionId

        // Foreign keys

        /// <summary>
        /// Parent Position pointed by [BaseStation].([PositionId]) (FK_BaseStation_Position)
        /// </summary>
        public virtual Position Position { get; set; } // FK_BaseStation_Position

        public BaseStation()
        {
            IdetityCode = "MCC + MNC + LAC + CELLID";
        }
    }
}