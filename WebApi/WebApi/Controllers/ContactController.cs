using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class ContactController : ApiController
    {
        static List<Contact> _contacts = new List<Contact>();
        string _invalidParameters => "Parâmetros inválidos";        
        public IHttpActionResult Get() => Ok(_contacts);
        public IHttpActionResult Get(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest(_invalidParameters);

            var contact = _contacts.FirstOrDefault(w => w.Id == id);
            if (contact == null)
                return NotFound();

            return Ok(contact);
        }
        public IHttpActionResult Post([FromBody] ContactPostRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(_invalidParameters);

            var contact = new Contact
            {
                LastName = request.LastName,
                Name = request.Name
            };

            _contacts.Add(contact);

            return Ok();
        }
        public IHttpActionResult Put([FromBody] ContactPutRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(_invalidParameters);

            var exists = _contacts.FirstOrDefault(w => w.Id == request.Id);

            if (exists == null)
                return NotFound();

            exists.Name = request.Name;
            exists.LastName = request.LastName;

            return Ok();
        }
        public IHttpActionResult Delete(string id)
        {
            if (!ModelState.IsValid)
                return BadRequest(_invalidParameters);

            var exists = _contacts.FirstOrDefault(w => w.Id == id);

            if (exists == null)
                return NotFound();

            _contacts.Remove(exists);

            return Ok();
        }
    }
}
