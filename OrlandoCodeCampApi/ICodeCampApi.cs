using OrlandoCodeCampApi.Models.Requests;
using OrlandoCodeCampApi.Models.Responses;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrlandoCodeCampApi
{
    public interface ICodeCampApi
    {
        #region Announcements

        [Get("/api/announcements")]
        Task<IList<Announcement>> GetAnnouncementsList(EventIdParameter queryParameter);

        #endregion

        #region Events

        [Get("/api/events")]
        Task<IList<Event>> GetEventsList();

        [Get("/api/events/active")]
        Task<Event> GetActiveEvent();

        [Get("/api/events/{year}")]
        Task<Event> GetEventByYear(int year);

        #endregion

        #region Sessions

        [Get("/api/sessions")]
        Task<IList<Session>> GetSessionsList(GetSessionsListParameters queryParameters);

        [Get("/api/sessions/{sessionId}")]
        Task<Session> GetSession(int sessionId,
            IncludeDescriptionParameter queryParameter);

        #endregion

        #region Speakers

        [Get("/api/speakers")]
        Task<IList<Speaker>> GetSpeakersList(GetSpeakersListParameters queryParameters);

        [Get("/api/speakers/{speakerId}")]
        Task<Speaker> GetSpeaker(int speakerId, IncludeDetailsParameter queryParameter);

        //// TODO What is correct response type?
        //[Get("/api/speakers/{speakerId}/image")]
        //Task<FileWebResponse> GetSpeakerImage(int speakerId);

        #endregion

        #region Sponsors

        [Get("/api/sponsors")]
        Task<IList<Sponsor>> GetSponsorsList(EventIdParameter queryParameter);

        [Get("/api/sponsors/levels")]
        Task<IList<SponsorLevel>> GetSponsorLevels(EventIdParameter queryParameter);

        //// TODO What is correct response type?
        //[Get("/api/sponsors/{sponsorId}/image")]
        //Task<FileWebResponse> GetSponsorImage(int sponsorId);

        #endregion

        #region Timeslots

        [Get("/api/timeslots")]
        Task<IList<Timeslot>> GetTimeslotsList(EventIdParameter queryParameter);

        #endregion

        #region Tracks

        [Get("/api/tracks")]
        Task<IList<Track>> GetTracksList(EventIdParameter queryParameter);

        #endregion
    }
}