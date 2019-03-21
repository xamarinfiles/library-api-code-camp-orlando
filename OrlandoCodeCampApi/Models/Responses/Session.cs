using System.Diagnostics;

namespace OrlandoCodeCampApi.Models.Responses
{
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public class Session
    {

        public int Id { get; set; }

        #region Summary

        public int? EventId { get; set; }

        public string Name { get; set; }

        // TODO Multiple speakers
        public int? SpeakerId { get; set; }

        public bool IsApproved { get; set; }

        public int? TrackId { get; set; }

        public int? TimeslotId { get; set; }

        public int SkillLevel { get; set; }

        public string Keywords { get; set; }

        #endregion

        #region Details

        public string Description { get; set; }

        #endregion

        private string DebuggerDisplay => $"Session {Id}" + DebugSpeakerId + $" - {Name}";

        private string DebugSpeakerId =>
            SpeakerId == null ? "" : $" - Speaker {SpeakerId}";
    }
}
