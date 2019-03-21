using System;
using System.Diagnostics;

namespace OrlandoCodeCampApi.Models.Responses
{
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public class Announcement
    {
        public int Id { get; set; }

        #region Summary

        public int? EventId { get; set; }

        public int Rank { get; set; }

        public DateTime PublishOn { get; set; }

        public DateTime? ExpiresOn { get; set; }

        #endregion

        #region Details

        public string Message { get; set; }

        #endregion

        private string DebuggerDisplay =>
            $"{Id} - Event {EventId} - Rank {Rank}" +
            $" - Start {PublishOn:g} - End {ExpiresOn:g} - {Message,-20}";
    }
}
