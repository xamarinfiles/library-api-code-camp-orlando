using System;
using System.Diagnostics;

namespace OrlandoCodeCampApi.Models.Responses
{
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public class Sponsor
    {
        public int Id { get; set; }

        #region Summary

        public int? EventId { get; set; }

        public string CompanyName { get; set; }

        public Uri ImageUrl { get; set; }

        public int SponsorLevel { get; set; }

        #endregion

        #region Details

        public string Bio { get; set; }

        public string WebsiteUrl { get; set; }

        public string TwitterHandle { get; set; }

        public string EmailAddress { get; set; }

        #endregion

        private string DebuggerDisplay =>
            $"{Id} - Event {EventId} - Level {SponsorLevel} - {CompanyName}";
    }
}
