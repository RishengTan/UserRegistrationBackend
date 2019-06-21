using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserRegistration.Models.Client;

namespace UserRegistration.Controllers.Client
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientContext ClientContext;
        public ClientController(ClientContext clientContext)
        {
            ClientContext = clientContext;
        }
        [EnableCors]
        [HttpGet]

        public async Task<Object> Get()
        {
            var Client = from a in ClientContext.table1
                         join b in ClientContext.table2 on a.FirstName equals b.FirstName

                         select new { a.FirstName, a.LastName, a.DOB, b.LicenseNumber, a.Address };

            return await Client.ToListAsync();
        }

        [EnableCors]
        [HttpPut("{FirstName}")]

        public async Task<Object> puttable1(string FirstName, table1 table1)
        {
            if (FirstName != table1.FirstName)
            {
                return BadRequest();
            }

            ClientContext.Entry(table1).State = EntityState.Modified;

            try
            {
                await ClientContext.SaveChangesAsync();
            }
            catch
            {

            }
            return Ok();
        }

       
    }
}