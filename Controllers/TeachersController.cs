using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TacticWebApp.Data;
using TacticWebApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TacticWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TeachersController(AppDbContext context)
        {
            _context = context;
        }

        // 🔹 GET: api/teachers/students-with-scores
        [HttpGet("students-with-scores")]
        public async Task<ActionResult<IEnumerable<object>>> GetStudentsWithScores()
        {
            var studentsWithScores = await _context.Students
                .Select(s => new
                {
                    s.Id,
                    s.StudentName,
                    Score = _context.Scores
                                    .Where(sc => sc.StudentId == s.Id)
                                    .Select(sc => sc.Score)
                                    .FirstOrDefault()
                })
                .ToListAsync();

            return Ok(studentsWithScores);
        }

        // 🔹 POST: api/teachers/submit-score
        [HttpPost("submit-score")]
        public async Task<IActionResult> SubmitScore([FromBody] Score score)
        {
            if (score == null || score.StudentId == 0)
            {
                return BadRequest(new { message = "Invalid data" });
            }

            var existingScore = await _context.Scores.FirstOrDefaultAsync(s => s.StudentId == score.StudentId);

            if (existingScore == null)
            {
                // If no existing score, add new
                _context.Scores.Add(score);
            }
            else
            {
                // Update the existing score
                existingScore.Score = score.Score;
                _context.Entry(existingScore).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();
            return Ok(new { message = "Score updated successfully!" });
        }
    }
}
