using OrlandoCodeCampApi.Models.Requests;
using OrlandoCodeCampApi.Models.Responses;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrlandoCodeCampApi
{
    public interface ICodeCampApiRefit : ICodeCampApi
    {
        #region Announcements

        [Get("/api/announcements")]
        new Task<IList<Announcement>> GetAnnouncements(EventIdRequest request);

        #endregion

        #region Events

        //[Get("/api/events")]
        //new Task<IList<Event>> GetEvents();

        //[Get("/api/events/active")]
        //new Task<Event> GetActiveEvent();

        //[Get("/api/events/{year}")]
        //new Task<Event> GetEventByYear(int year);

        #endregion

        #region Sessions

        //new Task<IList<Session>> GetSessions([Body] GetSessionsParameters parameters);

        //new Task<Session> GetSession(int sessionId,
        //    [Body] IncludeDescriptionParameter parameters);

        #endregion

        #region Speakers

        //new Task<IList<Speaker>> GetSpeakers([Body] GetSpeakersParameters parameters);

        //new Task<Speaker> GetSpeaker(int speakerId,
        //    [Body] IncludeDetailsParameters parameters);

        //// TODO What is correct response type?
        //new Task<FileWebResponse> GetSpeakerImage(int speakerId);

        #endregion

        #region Sponsors

        //new Task<IList<Sponsor>> GetSponsors([Body] EventParameters parameter);

        //// TODO Need eventId?
        //new Task<IList<SponsorLevel>> GetSponsorLevels();

        //// TODO What is correct response type?
        //new Task<FileWebResponse> GetSponsorImage(int sponsorId);

        #endregion

        #region Timeslots

        //new Task<IList<Timeslot>> GetTimeslots([Body] EventParameters parameter);

        #endregion

        #region Tracks

        //new Task<IList<Track>> GetTracks([Body] EventParameters parameter);

        #endregion
    }
}