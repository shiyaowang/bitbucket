using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NameAPI.Models;
using Newtonsoft.Json.Linq;
using System.IO;
using Microsoft.AspNetCore.Hosting;


namespace NameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NameDetailController : ControllerBase
    {
        private readonly NameDatailContext _context;
        private readonly IWebHostEnvironment WebHostEnvironment;

        public NameDetailController(NameDatailContext context,
            IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            WebHostEnvironment = webHostEnvironment;
        }

        // GET: api/NameDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NameDetail>>> GetNameDetails()
        {
            return await _context.NameDetails.ToListAsync();
        }

        // GET: api/NameDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NameDetail>> GetNameDetail(int id)
        {
            var nameDetail = await _context.NameDetails.FindAsync(id);

            if (nameDetail == null)
            {
                return NotFound();
            }

            return nameDetail;
        }

        // PUT: api/NameDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNameDetail(int id, NameDetail nameDetail)
        {
            if (id != nameDetail.NameDatailId)
            {
                return BadRequest();
            }

            _context.Entry(nameDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NameDetailExists(id))
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

        // POST: api/NameDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NameDetail>> PostNameDetail(NameDetail nameDetail)
        {
            JObject obj = (JObject)JToken.FromObject(nameDetail);

            string uploadDir = Path.Combine(WebHostEnvironment.WebRootPath, "JSON");
            var fileName = Guid.NewGuid().ToString() + ".json";
            string filePath = Path.Combine(uploadDir, fileName);
            System.IO.File.WriteAllText(filePath, obj.ToString());

            _context.NameDetails.Add(nameDetail);
            //await _context.SaveChangesAsync();

            return CreatedAtAction("GetNameDetail", new { id = nameDetail.NameDatailId }, nameDetail);
        }

        // DELETE: api/NameDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNameDetail(int id)
        {
            var nameDetail = await _context.NameDetails.FindAsync(id);
            if (nameDetail == null)
            {
                return NotFound();
            }

            _context.NameDetails.Remove(nameDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NameDetailExists(int id)
        {
            return _context.NameDetails.Any(e => e.NameDatailId == id);
        }

        //public IActionResult ConvertFile()
        //{
        //    return NoContent();
        //}

        //[HttpPost]
        //public IActionResult ConvertFile (NameDetail name)
        //{
        //    JObject obj = (JObject)JToken.FromObject(name);
        //    CreateFile(obj);
        //    return NoContent();
        //}

        //public void CreateFile(JObject obj)
        //{
        //    string uploadDir = Path.Combine(WebHostEnvironment.WebRootPath, "JSON");
        //    var fileName = Guid.NewGuid().ToString() + ".json";
        //    string filePath = Path.Combine(uploadDir, fileName);
        //    System.IO.File.WriteAllText(filePath, obj.ToString());
        //}
    }
}
