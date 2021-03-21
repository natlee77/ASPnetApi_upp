using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CaseManager.Data;
using CaseManager.Entities;
using Microsoft.AspNetCore.Authorization;
using CaseManager.Filters;

namespace CaseManager.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    //use ApiKeyAuthAttribute
    [ApiKeyAuth]


    public class IssuesController : ControllerBase
    {
        private readonly SqlDbContext _context;

        public IssuesController(SqlDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]       // GET: api/Issues
        public async Task<ActionResult<IEnumerable<Issue>>> GetIssues()
        {
            return await _context.Issues.Include(i => i.Customer).Include(i => i.Manager).ToListAsync();
            //return await _context.Issues.ToListAsync();
        }

      
        [HttpGet("{id}")]           // GET: api/Issues/5
        public async Task<ActionResult<Issue>> GetIssue(int id)
        {
            var issue = await _context.Issues.FindAsync(id);

            if (issue == null)
            {
                return NotFound();
            }

            return issue;
        }
     


        [HttpGet("{orderby}")]
        public async Task<ActionResult<IEnumerable<Issue>>> GetIssueByData(string orderby)
        {
            if (DateTime.TryParse(orderby, out var datetime))
            {
                return await _context.Issues.Where(x => x.IssueDate >= datetime).ToListAsync();//hämta
            }
            else
            {
                return await _context.Issues.ToListAsync();
            }
        }
        [HttpGet("{customer lastname}")]
        public async Task<ActionResult<IEnumerable<Issue>>> GetIssueByCustomer(string customer)
        {

            var issue = await _context.Issues.OrderBy(x => x.Customer.LastName).ToListAsync();

            if (customer == null)
            {
                return NotFound();
            }

            return issue;

            //return await _context.Issues.OrderBy(x => x.Customer.LastName).ToListAsync();
        }






        [HttpPut("{id}")]                 // PUT: api/Issues/5
        public async Task<IActionResult> PutIssue(int id, Issue issue)
        {
            if (id != issue.Id)
            {
                return BadRequest();
            }

            _context.Entry(issue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IssueExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

       
       
        [HttpPost]    // POST: api/Issues
        public async Task<ActionResult<Issue>> PostIssue(Issue issue)
        {
            _context.Issues.Add(issue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIssue", new { id = issue.Id }, issue);
        }

       

        private bool IssueExists(int id)
        {
            return _context.Issues.Any(e => e.Id == id);
        }

        //[HttpGet("{status}")]           // GET: api/Issues/active
        //public async Task<ActionResult<IEnumerable<Issue>>> GetIssueByStatus( )
        //{          

        //        return await _context.Issues.Where(x => x.IssueStatus.Any()  ).ToListAsync();


        //}
    }
}
