using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace OrlandoCodeCampApi.Console
{
    [SuppressMessage("ReSharper", "UnusedVariable")]
    internal static class Program
    {
        #region Enums

        #endregion

        #region Fields

        // TODO Support multiple environments
        // TODO Move to config
        private const string ApiUrl = "https://www.orlandocodecamp.com";

        #endregion

        #region Service

        private static CodeCampApi Api { get; set; }

        public static void Main(string[] args)
        {
            Api = new CodeCampApi(ApiUrl);

            // Announcements

            PrintAnnouncementsList();

            // Events

            PrintEventsList();
            PrintActiveEvent();
            PrintEventByYear(2019);

            // Sessions

            PrintSessionsList();
            PrintSession(49, true);
            PrintSession(49, false);
            PrintSession(49);

            // Speakers

            PrintSpeakersList();
            PrintSpeaker(7, true);
            PrintSpeaker(7, false);
            PrintSpeaker(7);
            PrintSpeakerImage(7);

            // Sponsors

            PrintSponsorsList();
            PrintSponsorLevels();
            PrintSponsorImage(8);

            // Timeslots

            PrintTimeslotsList();

            // Tracks

            PrintTracksList();
        }

        #endregion

        #region Announcements

        private static void PrintAnnouncementsList(int? eventId = null)
        {
            var announcements =
                Task.Run(() => Api.GetAnnouncementsList(eventId)).Result;

            // TODO
        }

        #endregion

        #region Events

        private static void PrintEventsList()
        {
            var events = Task.Run(() => Api.GetEventsList()).Result;

            // TODO
        }

        private static void PrintActiveEvent()
        {
            var activeEvent = Task.Run(() => Api.GetActiveEvent()).Result;

            // TODO
        }

        private static void PrintEventByYear(int year)
        {
            var eventForYear = Task.Run(() => Api.GetEventByYear(year)).Result;

            // TODO
        }

        #endregion

        #region Sessions

        // TODO Add filtering parameters
        private static void PrintSessionsList()
        {
            var sessions = Task.Run(() => Api.GetSessionsList()).Result;

            // TODO
        }

        private static void PrintSession(int sessionId, bool? includeDescription = null)
        {
            var session = Task.Run(
                    () => Api.GetSession(sessionId, includeDescription))
                .Result;

            // TODO
        }

        #endregion

        #region Speakers

        // TODO Add filtering parameters
        private static void PrintSpeakersList()
        {
            var speakers = Task.Run(() => Api.GetSpeakersList()).Result;

            // TODO
        }

        private static void PrintSpeaker(int speakerId, bool? includeDescription = null)
        {
            var speaker = Task.Run(
                    () => Api.GetSpeaker(speakerId, includeDescription))
                .Result;

            // TODO
        }

        // TODO What to do with image since console program or wait for web version
        private static void PrintSpeakerImage(int speakerId)
        {
            var speakerImage =
                Task.Run(() => Api.GetSpeakerImageUrl(speakerId));

            // TODO
        }

        #endregion

        #region Sponsors

        // TODO Add filtering parameters
        private static void PrintSponsorsList()
        {
            var sponsors = Task.Run(() => Api.GetSponsorsList()).Result;

            // TODO
        }

        private static void PrintSponsorLevels(int? eventId = null)
        {
            var sponsorLevel = Task.Run(
                    () => Api.GetSponsorLevels(eventId))
                .Result;

            // TODO
        }

        // TODO What to do with image since console program or wait for web version
        private static void PrintSponsorImage(int sponsorId)
        {
            var sponsorImage =
                Task.Run(() => Api.GetSponsorImageUrl(sponsorId));

            // TODO
        }

        #endregion

        #region Timeslots

        // TODO Add filtering parameters
        private static void PrintTimeslotsList()
        {
            var timeslots = Task.Run(() => Api.GetTimeslotsList()).Result;

            // TODO
        }

        #endregion

        #region Tracks

        // TODO Add filtering parameters
        private static void PrintTracksList()
        {
            var tracks = Task.Run(() => Api.GetTracksList()).Result;

            // TODO
        }

        #endregion
    }
}
