using OrlandoCodeCampApi.Models.Requests;
using OrlandoCodeCampApi.Models.Responses;
using Refit;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace OrlandoCodeCampApi
{
    public class CodeCampApi
    {
        #region Enums

        #endregion

        #region Fields

        private readonly ICodeCampApi _api;
        private string _apiSpeakerImageUrlFormat = "/api/speakers/{speakerId}/image";
        private string _apiSponsorImageUrlFormat = "/api/sponsors/{sponsorId}/image";

        #endregion

        #region Constructors

        public CodeCampApi(string baseUrl)
        {
            try
            {
                BasePath = baseUrl;
                BaseUrl = new Uri(BasePath);

                // TODO Add HTTP logger

                _api = RestService.For<ICodeCampApi>(BasePath);
            }
            catch (Exception exception)
            {
                SaveExceptionLocation(exception);

                throw;
            }
        }

        #endregion

        #region Properties

        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public string BasePath { get; }

        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public Uri BaseUrl { get; }

        #endregion

        #region Announcements

        public async Task<IList<Announcement>> GetAnnouncementsList(int? eventId = null)
        {
            try
            {
                var queryParameter = new EventIdParameter
                {
                    EventId = eventId
                };
                var announcementsList = await _api.GetAnnouncementsList(queryParameter);

                return announcementsList;
            }
            catch (Exception exception)
            {
                SaveExceptionLocation(exception);

                throw;
            }
        }

        #endregion

        #region Events

        public async Task<IList<Event>> GetEventsList()
        {
            try
            {
                var eventsList = await _api.GetEventsList();

                return eventsList;
            }
            catch (Exception exception)
            {
                SaveExceptionLocation(exception);

                throw;
            }
        }

        public async Task<Event> GetActiveEvent()
        {
            try
            {
                var @event = await _api.GetActiveEvent();

                return @event;
            }
            catch (Exception exception)
            {
                SaveExceptionLocation(exception);

                throw;
            }
        }

        public async Task<Event> GetEventByYear(int year)
        {
            try
            {
                var @event = await _api.GetEventByYear(year);

                return @event;
            }
            catch (Exception exception)
            {
                SaveExceptionLocation(exception);

                throw;
            }
        }

        #endregion

        #region Sessions

        public async Task<IList<Session>> GetSessionsList(int? eventId = null,
            int? trackId = null, int? timeslotId = null, bool? includeDescriptions = null)
        {
            try
            {
                var queryParameters = new GetSessionsListParameters
                {
                    EventId = eventId,
                    TrackId = trackId,
                    TimeslotId = timeslotId,
                    IncludeDescriptions = includeDescriptions
                };

                var allSessionsList = await _api.GetSessionsList(queryParameters);
                // TEMP Web API is not blocking unapproved sessions anymore
                var sessionsList =
                    allSessionsList.Where(session => session.IsApproved).ToList();

                return sessionsList;
            }
            catch (Exception exception)
            {
                SaveExceptionLocation(exception);

                throw;
            }
        }

        public async Task<Session> GetSession(int sessionId,
            bool? includeDescription = null)
        {
            try
            {
                var queryParameter = new IncludeDescriptionParameter
                {
                    IncludeDescription = includeDescription
                };

                var session = await _api.GetSession(sessionId, queryParameter);

                return session;
            }
            catch (Exception exception)
            {
                SaveExceptionLocation(exception);

                throw;
            }
        }

        #endregion

        #region Speakers

        public async Task<IList<Speaker>> GetSpeakersList(int? eventId = null,
            bool? includeDetails = null)
        {
            try
            {
                var queryParameters = new GetSpeakersListParameters
                {
                    EventId = eventId,
                    IncludeDetails = includeDetails
                };

                // TEMP Web API is not blocking unapproved sessions anymore
                var approvedSessionsTask = GetSessionsList();
                var allSpeakersTask = _api.GetSpeakersList(queryParameters);
                await Task.WhenAll(approvedSessionsTask, allSpeakersTask);

                var approvedSessions = await approvedSessionsTask;
                var approvedSpeakerIdsList =
                    approvedSessions.Select(session => session.SpeakerId).Distinct();

                var allSpeakers = await allSpeakersTask;
                var approvedSpeakers =
                    allSpeakers.Where(
                            speaker => approvedSpeakerIdsList.Contains(speaker.Id))
                        .ToList();

                return approvedSpeakers;
            }
            catch (Exception exception)
            {
                SaveExceptionLocation(exception);

                throw;
            }
        }

        public async Task<Speaker> GetSpeaker(int speakerId, bool? includeDetails = null)
        {
            try
            {
                var queryParameter = new IncludeDetailsParameter
                {
                    IncludeDetails = includeDetails
                };
                var speaker = await _api.GetSpeaker(speakerId, queryParameter);

                return speaker;
            }
            catch (Exception exception)
            {
                SaveExceptionLocation(exception);

                throw;
            }
        }

        public Uri GetSpeakerImageUrl(int speakerId)
        {
            try
            {
                // TODO Use attribute from Refit interface
                var speakerImageRelativeUrl =
                    _apiSpeakerImageUrlFormat
                        .Replace("{speakerId}", speakerId.ToString());
                var speakerImageUrl = new Uri(BaseUrl, speakerImageRelativeUrl);

                return speakerImageUrl;
            }
            catch (Exception exception)
            {
                SaveExceptionLocation(exception);

                throw;
            }
        }

        #endregion

        #region Sponsors

        public async Task<IList<Sponsor>> GetSponsorsList(int? eventId = null)
        {
            try
            {
                var queryParameter = new EventIdParameter
                {
                    EventId = eventId
                };
                var sponsorsList = await _api.GetSponsorsList(queryParameter);

                return sponsorsList;
            }
            catch (Exception exception)
            {
                SaveExceptionLocation(exception);

                throw;
            }
        }

        public async Task<IList<SponsorLevel>> GetSponsorLevels(int? eventId = null)
        {
            try
            {
                var queryParameter = new EventIdParameter
                {
                    EventId = eventId
                };
                var sponsorLevels = await _api.GetSponsorLevels(queryParameter);

                return sponsorLevels;
            }
            catch (Exception exception)
            {
                SaveExceptionLocation(exception);

                throw;
            }
        }

        public Uri GetSponsorImageUrl(int sponsorId)
        {
            try
            {
                // TODO Use attribute from Refit interface
                var sponsorImageRelativeUrl =
                    _apiSponsorImageUrlFormat
                        .Replace("{sponsorId}", sponsorId.ToString());
                var sponsorImageUrl = new Uri(BaseUrl, sponsorImageRelativeUrl);

                return sponsorImageUrl;
            }
            catch (Exception exception)
            {
                SaveExceptionLocation(exception);

                throw;
            }
        }

        #endregion

        #region Timeslots

        public async Task<IList<Timeslot>> GetTimeslotsList(int? eventId = null)
        {
            try
            {
                var queryParameter = new EventIdParameter
                {
                    EventId = eventId
                };
                var timeslotsList = await _api.GetTimeslotsList(queryParameter);

                return timeslotsList;
            }
            catch (Exception exception)
            {
                SaveExceptionLocation(exception);

                throw;
            }
        }

        #endregion

        #region Tracks

        public async Task<IList<Track>> GetTracksList(int? eventId = null)
        {
            try
            {
                var queryParameter = new EventIdParameter
                {
                    EventId = eventId
                };
                var tracksList = await _api.GetTracksList(queryParameter);

                return tracksList;
            }
            catch (Exception exception)
            {
                SaveExceptionLocation(exception);

                throw;
            }
        }

        #endregion

        #region Private

        #region Exceptions

        private void SaveExceptionLocation(Exception exception,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            exception.Data.Add("Base URL", BasePath);
            exception.Data.Add("Member Name", memberName);
            exception.Data.Add("Source File Path", sourceFilePath);
            exception.Data.Add("Source Line Number", sourceLineNumber);
        }

        #endregion

        #endregion

        #region Nested Types

        #endregion
    }
}