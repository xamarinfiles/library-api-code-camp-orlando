using System.Diagnostics;

namespace OrlandoCodeCampApi.Models.Responses
{
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public class Track
    {
        public int Id { get; set; }

        #region Summary

        public int? EventId { get; set; }

        public string Name { get; set; }

        #endregion

        #region Details

        public string RoomNumber { get; set; }

        #endregion

        private string DebuggerDisplay =>
            $"{Id} - Event {EventId} - {Name} - {RoomNumber}";
    }
}
