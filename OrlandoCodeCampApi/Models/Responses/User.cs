using System.Diagnostics;

namespace OrlandoCodeCampApi.Models.Responses
{
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public class User
    {
        public string Id { get; set; }

        #region Summary

        public string FirstName { get; set; }

        public string LastName { get; set; }

        // TODO Future
        //public int? EventId { get; set; }

        public string FullNameOrEmailAddress
        {
            get
            {
                if (string.IsNullOrEmpty(FirstName) && string.IsNullOrEmpty(LastName))
                    return EmailAddress;

                return FirstName + (FirstName.Length > 0 ? " " : "") + LastName;
            }
        }

        #endregion

        #region Details

        public string EmailAddress { get; set; }

        #endregion

        private int? SpeakerId { get; set; }

        private string DebuggerDisplay =>
            $"{Id}" +  DebugSpeakerId + $" - {FullNameOrEmailAddress}";

        private string DebugSpeakerId =>
            SpeakerId != null ? $" - Speaker {SpeakerId}" : "";
    }
}
