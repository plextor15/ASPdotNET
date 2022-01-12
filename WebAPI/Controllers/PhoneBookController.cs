using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneBookController : ControllerBase
    {
        static List<PhoneBookEntry> phoneBook = null;

        public PhoneBookController()
        {
            if (phoneBook == null)
            {
                phoneBook = new List<PhoneBookEntry>();
                phoneBook.Add(new PhoneBookEntry(1, "Ala", "48", "726 166 831"));
                phoneBook.Add(new PhoneBookEntry(2, "Alan", "48", "626 166 831"));
                phoneBook.Add(new PhoneBookEntry(3, "Teo", "55", "726 166 831"));
                phoneBook.Add(new PhoneBookEntry(4, "Cleo", "55", "111 166 831"));
            }
        }

        // GET: api/<PhoneBookController>
        [HttpGet]
        public IEnumerable<PhoneBookEntry> Get()
        {
            return phoneBook;
        }

        // GET api/<PhoneBookController>/5
        [HttpGet("{id}")]
        public PhoneBookEntry Get(int id)
        {
            return phoneBook.Where(el => el.ID == id).FirstOrDefault();
        }

        // POST api/<PhoneBookController>
        [HttpPost]
        public PhoneBookEntry Post([FromBody] PhoneBookEntry entry)
        {
            int nextId = phoneBook.Max(el => el.ID) + 1;
            Debug.WriteLine(nextId);
            PhoneBookEntry en = new PhoneBookEntry(nextId);
            en.CopyFrom(entry);
            Debug.WriteLine(entry);
            Debug.WriteLine(en);
            phoneBook.Add(en);
            return en;
        }

        // PUT api/<PhoneBookController>/5
        [HttpPut("{id}")]
        public PhoneBookEntry Put(int id, [FromBody] PhoneBookEntry entry)
        {
            PhoneBookEntry en = phoneBook.Where(el => el.ID == id).FirstOrDefault();
            if (en != null)
                en.CopyFrom(entry);
            return en;
        }

        // DELETE api/<PhoneBookController>/5
        [HttpDelete("{id}")]
        public PhoneBookEntry Delete(int id)
        {
            PhoneBookEntry en = phoneBook.Where(el => el.ID == id).FirstOrDefault();
            if (en != null)
                phoneBook.Remove(en);
            return en;
        }
    }
}
