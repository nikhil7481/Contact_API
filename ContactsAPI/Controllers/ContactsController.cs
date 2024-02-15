using ContactsAPI.Data;
using ContactsAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ContactsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly ContectsAPIDbContext dbContext;

        public ContactsController(ContectsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
              public async Task<IActionResult>  GetContacts()
        {
            return Ok(dbContext.Contects.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> AddContact(AddContactsRequest addContactsRequest)
        {
            var contact = new Contect()
            {
                Id = Guid.NewGuid(),
                Address = addContactsRequest.Address,
                Email = addContactsRequest.Email,
                Name = addContactsRequest.Name,
                Phone = addContactsRequest.Phone

            };
            await dbContext.Contects.AddAsync(contact);
            await dbContext.SaveChangesAsync();
            return Ok(contact);

        }
        [HttpGet]
        [Route("{id:guid}")]

        public async Task<IActionResult> GetContect([FromRoute] Guid id)
        {
             var contect = await dbContext.Contects.FindAsync(id);

            if (contect==null)
            {
                return NotFound();   
            }
            return Ok(contect);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateContact([FromRoute] Guid id, UpdateContactRequest updateContactRequest)
        {
        var contact= await dbContext.Contects.FindAsync(id);

            if(contact!=null)
            {
                contact.Name = updateContactRequest.Name;
                contact.Address=updateContactRequest.Address;
                contact.Email=updateContactRequest.Email;
                contact.Phone=updateContactRequest.Phone;
                await dbContext.SaveChangesAsync();
              
            return Ok(contact);
            }
            return NotFound();    
        }
        [HttpDelete]
        [Route("{id:guid}")]

        public async Task<IActionResult> DeleteContact([FromRoute] Guid id ) {
            var contect=await dbContext.Contects.FindAsync( id);

            if (contect!=null)
            {
                dbContext.Remove(contect);
                await dbContext.SaveChangesAsync();
                return Ok(contect);
            }
            return NotFound();
        }

    }
}
