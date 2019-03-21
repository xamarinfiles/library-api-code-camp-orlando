using System;
using System.Diagnostics;

namespace OrlandoCodeCampApi.Models.Responses
{
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public class Event
    {
        public int Id { get; set; }

        #region Summary

        public string Name { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public bool IsActive { get; set; }

        public bool IsAttendeeRegistrationOpen { get; set; }

        public bool IsSpeakerRegistrationOpen { get; set; }

        #endregion

        #region Details

        public string SocialMediaHashtag { get; set; }

        public string LocationAddress { get; set; }

        #endregion

        private string DebuggerDisplay =>
            $"{Id} - {Name} - {StartDateTime:g} to {EndDateTime:g}";
    }
}
