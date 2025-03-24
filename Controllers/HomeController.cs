//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using v_try.Data;
//using v_try.Models;
//using System.Threading.Tasks;

//namespace v_try.Controllers
//{
//    public class HomeController : Controller
//    {
//        private readonly ApplicationDbContext _context;

//        public HomeController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public IActionResult Index()
//        {
//            var subjects = _context.Subjects.ToList();
//            var topics = _context.Topics.Include(t => t.Subject).ToList();
//            var subtopics = _context.Subtopics.Include(s => s.Topic).ToList();

//            var model = (subjects, topics, subtopics);
//            return View(model);
//        }
//    }
//}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using v_try.Data;
using v_try.Models;

namespace v_try.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Main page - Loads all data
        public IActionResult Index()
        {
            var subjects = _context.Subjects.ToList();
            var topics = _context.Topics.Include(t => t.Subject).ToList();
            var subtopics = _context.Subtopics.Include(s => s.Topic).ToList();

            return View((subjects, topics, subtopics));
        }

        // Add Subject (POST)
        [HttpPost]
        public IActionResult AddSubject([FromBody] Subject subject)
        {
            if (string.IsNullOrEmpty(subject.SubjectName))
                return BadRequest("Subject name is required");

            _context.Subjects.Add(subject);
            _context.SaveChanges();
            return Ok();
        }

        // Add Topic (POST)
        [HttpPost]
        public IActionResult AddTopic([FromBody] Topic topic)
        {
            if (string.IsNullOrEmpty(topic.TopicName) || topic.SubjectId == 0)
                return BadRequest("Topic name and subject selection are required");

            _context.Topics.Add(topic);
            _context.SaveChanges();
            return Ok();
        }

        // Add Subtopic (POST)
        [HttpPost]
        public IActionResult AddSubtopic([FromBody] Subtopic subtopic)
        {
            if (string.IsNullOrEmpty(subtopic.SubtopicName) || subtopic.TopicId == 0)
                return BadRequest("Subtopic name and topic selection are required");

            _context.Subtopics.Add(subtopic);
            _context.SaveChanges();
            return Ok();
        }

        // Delete Subject (POST)
        [HttpPost]
        public IActionResult DeleteSubject(int id)
        {
            var subject = _context.Subjects
                .Include(s => s.Topics)
                .ThenInclude(t => t.Subtopics)
                .FirstOrDefault(s => s.Id == id);

            if (subject == null)
                return NotFound();

            // Cascade delete topics and subtopics
            _context.Subjects.Remove(subject);
            _context.SaveChanges();
            return Ok();
        }

        // Delete Topic (POST)
        [HttpPost]
        public IActionResult DeleteTopic(int id)
        {
            var topic = _context.Topics
                .Include(t => t.Subtopics)
                .FirstOrDefault(t => t.Id == id);

            if (topic == null)
                return NotFound();

            _context.Topics.Remove(topic);
            _context.SaveChanges();
            return Ok();
        }

        // Delete Subtopic (POST)
        [HttpPost]
        public IActionResult DeleteSubtopic(int id)
        {
            var subtopic = _context.Subtopics.Find(id);
            if (subtopic == null)
                return NotFound();

            _context.Subtopics.Remove(subtopic);
            _context.SaveChanges();
            return Ok();
        }
    }
}