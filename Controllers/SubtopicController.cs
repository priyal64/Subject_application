//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using v_try.Data;
//using v_try.Models;
//using System.Threading.Tasks;

//namespace v_try.Controllers
//{
//    public class SubtopicController : Controller
//    {
//        private readonly ApplicationDbContext _context;

//        public SubtopicController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        // POST: Subtopic/Create
//        [HttpPost]
//        public async Task<IActionResult> Create([FromBody] Subtopic subtopic)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Subtopics.Add(subtopic);
//                await _context.SaveChangesAsync();
//                return Ok(); // Return success status
//            }
//            return BadRequest(ModelState); // Return error status with validation errors
//        }

//        // POST: Subtopic/Delete/5
//        [HttpPost]
//        public async Task<IActionResult> Delete(int id)
//        {
//            var subtopic = await _context.Subtopics.FindAsync(id);
//            if (subtopic == null)
//            {
//                return NotFound();
//            }

//            _context.Subtopics.Remove(subtopic);
//            await _context.SaveChangesAsync();
//            return Ok(); // Return success status
//        }
//    }
//}