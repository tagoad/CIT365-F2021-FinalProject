using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;
using SacramentPlanner.Models;
using SacramentPlanner.Services;
using System.Collections.Generic;

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
            var meetings = _meetingService.Get();
            var populatedMeetings = new List<Tuple<SacramentMeeting, PopulatedMembers>>();
            foreach(var meeting in meetings)
            {
                var populatedMembers = new PopulatedMembers();
                populatedMembers.Conductor = _memberService.Get(meeting.Conductor);
                populatedMembers.OpeningPrayer = _memberService.Get(meeting.OpeningPrayer);
                populatedMembers.ClosingPrayer = _memberService.Get(meeting.ClosingPrayer);
                var temp = new Tuple<SacramentMeeting, PopulatedMembers>(meeting, populatedMembers);
                populatedMeetings.Add(temp);
            }

            return View(populatedMeetings);
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

            var populatedMembers = new PopulatedMembers();
            populatedMembers.Conductor = _memberService.Get(sacramentMeeting.Conductor);
            populatedMembers.OpeningPrayer = _memberService.Get(sacramentMeeting.OpeningPrayer);
            populatedMembers.ClosingPrayer = _memberService.Get(sacramentMeeting.ClosingPrayer);
            if(sacramentMeeting.Speakers != null)
            {
                foreach (var speaker in sacramentMeeting.Speakers)
                {
                    var temp = new Tuple<Member, string>(_memberService.Get(speaker.Item1), speaker.Item2);
                    populatedMembers.Speakers.Add(temp);
                }
            }

            ViewData["populatedMembers"] = populatedMembers;

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
        public async Task<IActionResult> Create([Bind("Id,MeetingDate,Conductor,OpeningPrayer,ClosingPrayer,OpeningHymn,SacramentHymn,IntermediateHymn,ClosingHymn,Notes")] SacramentMeeting sacramentMeeting)
        {
            if (ModelState.IsValid)
            {
                _meetingService.Create(sacramentMeeting);
                return RedirectToAction(nameof(Index));
            }
            ViewData["members"] = _memberService.Get();
            return View(sacramentMeeting);
        }

        /**
        // POST: SacramentMeetings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MeetingDate,Conductor,OpeningPrayer,ClosingPrayer,OpeningHymn,SacramentHymn,IntermediateHymn,ClosingHymn,Notes,SpeakerString")] MeetingViewModel meetingModel)
        {
            var sacramentMeeting = meetingModel.Meeting;
            var tempList = new List<Tuple<string, string>>();
            var speakers = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(meetingModel.SpeakerString);
            Console.WriteLine(speakers);
            foreach (var speaker in speakers)
            {
                var temp = new Tuple<string, string>(speaker["memberId"], speaker["topic"]);
                tempList.Add(temp);
            }

            sacramentMeeting.Speakers = tempList;

            if (ModelState.IsValid)
            {
                _meetingService.Create(sacramentMeeting);
                return RedirectToAction(nameof(Index));
            }
            ViewData["members"] = _memberService.Get();
            return View(sacramentMeeting);
        }**/


        // GET: SacramentMeetings/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewData["members"] = _memberService.Get();

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
        public async Task<IActionResult> Edit(string id, [Bind("Id,MeetingDate,Conductor,OpeningPrayer,ClosingPrayer,OpeningHymn,SacramentHymn,IntermediateHymn,ClosingHymn,Notes")] SacramentMeeting sacramentMeeting)
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
            ViewData["members"] = _memberService.Get();
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

            var populatedMembers = new PopulatedMembers();
            populatedMembers.Conductor = _memberService.Get(sacramentMeeting.Conductor);
            populatedMembers.OpeningPrayer = _memberService.Get(sacramentMeeting.OpeningPrayer);
            populatedMembers.ClosingPrayer = _memberService.Get(sacramentMeeting.ClosingPrayer);

            ViewData["populatedMembers"] = populatedMembers;

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
