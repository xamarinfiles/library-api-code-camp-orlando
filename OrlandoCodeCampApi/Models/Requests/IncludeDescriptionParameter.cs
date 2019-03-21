using Refit;

namespace OrlandoCodeCampApi.Models.Requests
{
    public class IncludeDescriptionParameter
    {
        [AliasAs("includeDescription")]
        public bool? IncludeDescription { get; set; }
    }
}
