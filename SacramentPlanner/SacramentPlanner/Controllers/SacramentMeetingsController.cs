using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SacramentPlanner.Models;
using SacramentPlanner.Services;

namespace SacramentPlanner.Controllers
{
    public class SacramentMeetingsController : Controller
    {
        private readonly MeetingService _meetingService;
        private readonly MemberService _memberService;

        public SacramentMeetingsController(MeetingService meetingService, MemberService memberService)
        {
            _meetingService = meetingService;
            _memberService = memberService;
        }

        // GET: SacramentMeetings
        public async Task<IActionResult> Index()
        {
            return View(_meetingService.Get());
        }

        // GET: SacramentMeetings/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sacramentMeeting = _meetingService.Get(id);

            if (sacramentMeeting == null)
            {
                return NotFound();
            }

            return View(sacramentMeeting);
        }

        // GET: SacramentMeetings/Create
        public IActionResult Create()
        {
            ViewData["members"] = _memberService.Get();
            return View();
        }

        // POST: SacramentMeetings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MeetingDate,ConductorId,OpeningPrayerId,ClosingPrayerId,OpeningHymn,SacramentHymn,IntermediateHymn,ClosingHymn,Notes")] SacramentMeeting sacramentMeeting)
        {
            if (ModelState.IsValid)
            {
                _meetingService.Create(sacramentMeeting);
                return RedirectToAction(nameof(Index));
            }
            ViewData["members"] = _memberService.Get();
            return View(sacramentMeeting);
        }

        // GET: SacramentMeetings/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sacramentMeeting = _meetingService.Get(id);
            if (sacramentMeeting == null)
            {
                return NotFound();
            }
            return View(sacramentMeeting);
        }

        // POST: SacramentMeetings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,MeetingDate,OpeningHymn,SacramentHymn,IntermediateHymn,ClosingHymn,Notes")] SacramentMeeting sacramentMeeting)
        {
            if (id != sacramentMeeting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _meetingService.Update(id, sacramentMeeting);
                return RedirectToAction(nameof(Index));
            }
            return View(sacramentMeeting);
        }

        // GET: SacramentMeetings/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sacramentMeeting = _meetingService.Get(id);
            if (sacramentMeeting == null)
            {
                return NotFound();
            }

            return View(sacramentMeeting);
        }

        // POST: SacramentMeetings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            _meetingService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        private bool SacramentMeetingExists(string id)
        {
            if (_meetingService.Get(id) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
