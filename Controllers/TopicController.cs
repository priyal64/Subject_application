//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using v_try.Data;
//using v_try.Models;
//using System.Threading.Tasks;

//namespace v_try.Controllers
//{
//    public class TopicController : Controller
//    {
//        private readonly ApplicationDbContext _context;

//        public TopicController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        // POST: Topic/Create
//        [HttpPost]
//        public async Task<IActionResult> Create([FromBody] Topic topic)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Topics.Add(topic);
//                await _context.SaveChangesAsync();
//                return Ok(); // Return success status
//            }
//            return BadRequest(ModelState); // Return error status with validation errors
//        }

//        // POST: Topic/Delete/5
//        [HttpPost]
//        public async Task<IActionResult> Delete(int id)
//        {
//            var topic = await _context.Topics.FindAsync(id);
//            if (topic == null)
//            {
//                return NotFound();
//            }

//            _context.Topics.Remove(topic);
//            await _context.SaveChangesAsync();
//            return Ok(); // Return success status
//        }
//    }
//}