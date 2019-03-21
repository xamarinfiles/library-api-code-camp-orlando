using Refit;

namespace OrlandoCodeCampApi.Models.Requests
{
    public class GetSessionsListParameters
    {
        [AliasAs("eventId")]
        public int? EventId { get; set; }

        [AliasAs("trackId")]
        public int? TrackId { get; set; }

        [AliasAs("timeslotId")]
        public int? TimeslotId { get; set; }

        [AliasAs("includeDescriptions")]
        public bool? IncludeDescriptions { get; set; }
    }
}
