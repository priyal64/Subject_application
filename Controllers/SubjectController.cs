
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using v_try.Data;
//using v_try.Models;
//using System.Threading.Tasks;

//namespace v_try.Controllers
//{
//    public class SubjectController : Controller
//    {
//        private readonly ApplicationDbContext _context;

//        public SubjectController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        // POST: Subject/Create
//        [HttpPost]
//        public async Task<IActionResult> Create([FromBody] Subject subject)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Subjects.Add(subject);
//                await _context.SaveChangesAsync();
//                return Ok(); // Return success status
//            }
//            return BadRequest(ModelState); // Return error status with validation errors
//        }

//        // POST: Subject/Delete/5
//        [HttpPost]
//        public async Task<IActionResult> Delete(int id)
//        {
//            var subject = await _context.Subjects.FindAsync(id);
//            if (subject == null)
//            {
//                return NotFound();
//            }

//            _context.Subjects.Remove(subject);
//            await _context.SaveChangesAsync();
//            return Ok(); // Return success status
//        }
//    }
//}