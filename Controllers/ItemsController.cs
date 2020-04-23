using System;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StoreAnything.Models;

namespace StoreAnything.Controller {
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
            try {
                return await _context.Items.Select (x => JsonConvert.DeserializeObject (x.Data)).FirstOrDefaultAsync ();
            } catch (DbException ex) {
                return StatusCode (500, new { message = "A database issue occured" });
            } catch (Exception ex) {
                return StatusCode (500, new { message = "An issue occured" });
            }
        }

        // POST: api/Items
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem ([FromBody] object input) {

            try {
                Item dbItem = _context.Items.FirstOrDefault ();
                if (dbItem != null) {
                    dbItem.Data = input.ToString ();
                    _context.Entry (dbItem).State = EntityState.Modified;
                } else {
                    dbItem = new Item {
                        Data = input.ToString ()
                    };
                    _context.Items.Add (dbItem);
                }
                await _context.SaveChangesAsync ();
            } catch (DbException ex) {
                return StatusCode (500, new { message = "A database issue occured" });
            } catch (Exception ex) {
                return StatusCode (500, new { message = "An issue occured" });
            }

            return Ok ();
        }
    }
}