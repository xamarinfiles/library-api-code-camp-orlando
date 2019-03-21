using System;
using System.Diagnostics;

namespace OrlandoCodeCampApi.Models.Responses
{
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public class Speaker
    {

        public int Id { get; set; }

        #region Summary

        public int? EventId { get; set; }

        public string Name => User?.FullNameOrEmailAddress;

        public User User { get; set; }

        public Uri ImageUrl { get; set; }

        public bool IsMvp { get; set; }

        public bool IsApproved { get; set; }

        #endregion

        #region Details

        public string CompanyName { get; set; }

        public string Bio { get; set; }

        public string WebsiteUrl { get; set; }

        public string BlogUrl { get; set; }

        public string LinkedIn { get; set; }

        #endregion

        private string DebuggerDisplay => $"{Id} - {Name}";
    }
}
