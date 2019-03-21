using Refit;

namespace OrlandoCodeCampApi.Models.Requests
{
    public class EventIdParameter
    {
        [AliasAs("eventId")]
        public int? EventId { get; set; }
    }
}
