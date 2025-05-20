using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Cinema.Entity;
using Cinema.Interfaces.Services;
using System.Security.Claims;

namespace Cinema.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly ISessionService _sessionService;
        private readonly ISeatService _seatService;

        public ReportController(ITicketService ticketService,
                                ISessionService sessionService,
                                ISeatService seatService)
        {
            _ticketService = ticketService;
            _sessionService = sessionService;
            _seatService = seatService;
        }

        // Количество проданных и свободных мест на сеанс
        [HttpGet("session-seats/{sessionId}")]
        [AllowAnonymous]
        public IActionResult GetSessionSeats(int sessionId)
        {
            var session = _sessionService.GetById(sessionId);
            if (session == null)
                return NotFound("Сеанс не найден.");

            var hallSeats = _seatService.GetAll().Where(seat => seat.HallId == session.HallId).ToList();

            var soldTickets = _ticketService.GetAll().Where(t => t.SessionId == sessionId).ToList();
            var soldSeatIds = soldTickets.Select(t => t.SeatId).Distinct().ToList();

            var soldSeats = hallSeats.Where(s => soldSeatIds.Contains(s.Id)).ToList();
            var freeSeats = hallSeats.Where(s => !soldSeatIds.Contains(s.Id)).ToList();

            return Ok(new
            {
                SessionId = sessionId,
                SoldSeatsCount = soldSeats.Count,
                FreeSeatsCount = freeSeats.Count,
                SoldSeats = soldSeats,
                FreeSeats = freeSeats
            });
        }


        //Сеанс с наибольшим количеством проданных билетов.
        [HttpGet("top-session-by-tickets")]
        [AllowAnonymous]
        public IActionResult GetTopSessionByTickets()
        {
            var sessions = _sessionService.GetAll();
            var sessionTicketCounts = sessions.Select(s => new
            {
                Session = s,
                SoldTicketsCount = _ticketService.GetAll().Count(t => t.SessionId == s.Id)
            }).ToList();

            var topSession = sessionTicketCounts.OrderByDescending(st => st.SoldTicketsCount).FirstOrDefault();
            if (topSession == null)
                return NotFound("Сеансы не найдены.");

            return Ok(topSession);
        }


        // Сеансы сегодня.
        [HttpGet("today-sessions")]
        [AllowAnonymous]
        public IActionResult GetTodaySessions()
        {
            var today = DateTime.Today;
            var sessions = _sessionService.GetAll().Where(s => s.StartTime.Date == today);
            return Ok(sessions);
        }

        // Просмотр следующего сеанса 
        [HttpGet("next-session")]
        [AllowAnonymous]
        public IActionResult GetNextSession()
        {
            var now = DateTime.Now;
            var nextSession = _sessionService.GetAll()
                                    .Where(s => s.StartTime > now)
                                    .OrderBy(s => s.StartTime)
                                    .FirstOrDefault();
            if (nextSession == null)
                return NotFound("Нет предстоящих сеансов.");

            return Ok(nextSession);
        }

        // Все билеты пользователя
        [HttpGet("user-sessions")]
        [Authorize]
        public ActionResult<IEnumerable<Session>> GetUserSessions()
        {
            int currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var userTickets = _ticketService.GetAll().Where(t => t.UserId == currentUserId).ToList();
            var userSessionIds = userTickets.Select(t => t.SessionId).Distinct().ToList();

            var userSessions = _sessionService.GetAll().Where(s => userSessionIds.Contains(s.Id)).ToList();

            return Ok(userSessions);
        }

        // Прошедшие сессии пользователя
        [HttpGet("past-user-sessions")]
        [Authorize]
        public ActionResult<IEnumerable<Session>> GetPastUserSessions()
        {
            int currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var now = DateTime.Now;

            var userTickets = _ticketService.GetAll().Where(t => t.UserId == currentUserId).ToList();
            var userSessionIds = userTickets.Select(t => t.SessionId).Distinct().ToList();

            var pastSessions = _sessionService.GetAll()
                .Where(s => userSessionIds.Contains(s.Id) && s.EndTime < now)
                .ToList();

            return Ok(pastSessions);
        }

        // Получение списка сеансов на определённую дату
        [HttpGet("sessions-by-date/{date}")]
        [AllowAnonymous]
        public IActionResult GetSessionsByDate(DateTime date)
        {
            var sessions = _sessionService.GetAll()
                .Where(s => s.StartTime.Date == date.Date)
                .ToList();

            if (!sessions.Any())
                return NotFound($"Нет сеансов на дату {date:yyyy-MM-dd}");

            return Ok(sessions);
        }

        //Получение списка сеансов по фильму
        [HttpGet("sessions-by-movie/{movieId}")]
        [AllowAnonymous]
        public IActionResult GetSessionsByMovie(int movieId)
        {
            var sessions = _sessionService.GetAll()
                .Where(s => s.MovieId == movieId)
                .ToList();

            if (!sessions.Any())
                return NotFound($"Нет сеансов для фильма с ID {movieId}");

            return Ok(sessions);
        }

    }
}
