using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly DataContext _context;
        public UsersController(DataContext context){
            _context = context;
        }   
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers(){
             return await  _context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id){
            var user = _context.Users.FindAsync(id);
            if(await user == null){
                return BadRequest("User does not exist !");
            }
            return await  _context.Users.FindAsync(id);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<AppUser>> DeleteUser (int id){

            var user = _context.Users.SingleOrDefault(x => x.Id == id);
            if(user != null){
                _context.Users.Remove(user);
                _context.SaveChangesAsync();
            }
           return user;
        }
    }
}