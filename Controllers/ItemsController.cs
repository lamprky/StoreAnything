using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StoreAnything.Models;

namespace StoreAnything.Controller
{
    [Route ("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase {
        private readonly ApplicationContext _context;

        public ItemsController (ApplicationContext context) {
            _context = context;
        }

        // GET: api/Items
        [HttpGet]
        public async Task<ActionResult<object>> GetItem () {
            
            return await _context.Items.Select (x =>  JsonConvert.DeserializeObject(x.Data)).FirstOrDefaultAsync ();
        }

        // POST: api/Items
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem ([FromBody] object input) {

            Item dbItem = _context.Items.FirstOrDefault ();
            if (dbItem != null) {
                dbItem.Data = input.ToString();
                _context.Entry (dbItem).State = EntityState.Modified;
            } else {
                dbItem = new Item {
                    Data = input.ToString()
                };
                _context.Items.Add (dbItem);
            }
            await _context.SaveChangesAsync ();

            return NoContent ();
        }
    }
}