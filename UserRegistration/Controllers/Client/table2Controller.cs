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
    public class table2Controller : ControllerBase
    {
        private readonly ClientContext ClientContext;
        public table2Controller(ClientContext clientContext)
        {
            ClientContext = clientContext;
        }
        [EnableCors]
        [HttpPut("{FirstName}")]

        public async Task<Object> puttable2(string FirstName, table2 table2)
        {
            if (FirstName != table2.FirstName)
            {
                return BadRequest();
            }

            ClientContext.Entry(table2).State = EntityState.Modified;

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