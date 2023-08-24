using System;
using Trakk.WebApi.DatabaseModels.CongestionTaxContext.Data;

namespace CongestionTaxProcessor.Models;

public class Season
{
    public Season(DateTime startDate, SeasonType type = SeasonType.Excepted)
    {
        StartDate = startDate;
        Type = type;
    }

    public Season(DateTime startDate, DateTime? endDate, SeasonType type)
    {
        StartDate = startDate;
        EndDate = endDate;
        Type = type;
    }

    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public SeasonType Type { get; set; }

    public bool IsActive(DateTime dateTime)
    {
        return EndDate.HasValue
            ? StartDate <= dateTime.Date && EndDate.Value.Date >= dateTime
            : StartDate == dateTime.Date;
    }

}