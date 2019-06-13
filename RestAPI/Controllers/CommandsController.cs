using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPI.Models;

namespace RestAPI.Controllers
{[ApiController]
[Route("api/commands")]
    public class CommandsController : Controller
    {

        private readonly CommandContext _context;
        public CommandsController(CommandContext context)
        {
            _context = context;
        }


        //GET:           api/commands
        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable<Command>> GetCommands()
        {
            return _context.CommandItems.ToList();
        }


        //GET:          api/commands/n
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Command> GetCommand(int id)
        {
            var item= _context.CommandItems.Find(id);
            if (item == null)
                return NotFound();
            else return item;
        }


        //POST:           api/commands
        public ActionResult<Command> CreateCommand(Command command)
        {
            _context.CommandItems.Add(command);
            _context.SaveChanges();

            return CreatedAtAction("GetCommand", new Command { ID = command.ID },command);

        }


        //PUT:           api/commands/n
        [HttpPut]
        [Route("{id}")]
        public ActionResult UpdateCommand(int id,Command command) {
            if (command.ID != id)
            {
                return BadRequest();
            }
            _context.Entry(command).State = EntityState.Modified;
     
            _context.SaveChanges();
            return NoContent();
        }


        //Delete:           api/commands/n
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var command = _context.CommandItems.Find(id);
            if (command == null)
            {
                return BadRequest();
            }
            _context.Entry(command).State = EntityState.Deleted;

            _context.SaveChanges();
            return NoContent();
        }
    }
}