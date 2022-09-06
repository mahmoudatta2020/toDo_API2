using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo_API2.Models;

namespace ToDo_API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Todoitems : ControllerBase
    {
        List<Item> Items = new List<Item>();
        private IEnumerable<object> items;

        public Todoitems()
        {
            Items.Add(new Item
            {
                id = 1,
                name = "mahmoud",
                Iscomplete = true

            });
            Items.Add(new Item
            {
                id = 2,
                name = "reda",
                Iscomplete = false

            });
        }
        [HttpGet]
        public List<Item> Get()
        {
            return Items;
        }
        // api/items/1   or    api/items/1
        [HttpGet("{ip}")]
        public ActionResult<Item> GetById(int id)
        {
            var itm = Items.FirstOrDefault(a => a.id == id);
            if (itm == null)
                return NotFound();
            else
                return itm;
        }
        [HttpPost]
        public ActionResult Post([FromBody] Item item)
        {
            Items.Add(item);
            return CreatedAtAction("GetById", new { id = item.id }, item);
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, Item item)
        {
            foreach (var x in items)
            {
                if (item.id == id)
                {
                    item.name = item.name;
                }
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteToDoItem(int id)
        {
            var xitem = Items.Find(a => a.id == id);
            if (xitem == null)
            {
                return NotFound();

            }
            Items.Remove(xitem);
            return NoContent();

        }
    

    }
}
