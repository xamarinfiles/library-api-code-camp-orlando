using Refit;

namespace OrlandoCodeCampApi.Models.Requests
{
    public class IncludeDetailsParameter
    {
        [AliasAs("includeDetails")]
        public bool? IncludeDetails { get; set; }
    }
}
