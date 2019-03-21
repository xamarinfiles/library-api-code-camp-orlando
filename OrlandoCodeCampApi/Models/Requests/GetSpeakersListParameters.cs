using Refit;

namespace OrlandoCodeCampApi.Models.Requests
{
    public class GetSpeakersListParameters
    {
        [AliasAs("eventId")]
        public int? EventId { get; set; }

        [AliasAs("includeDetails")]
        public bool? IncludeDetails { get; set; }
    }
}
