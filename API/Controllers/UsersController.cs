using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
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

        [HttpDelete("Delete/{{id}}")]
        public async Task<ActionResult<AppUser>> DeleteUser (int id){

            var user = _context.Users.SingleOrDefault(x => x.Id == id);
            if(user != null){
                _context.Users.Remove(user);
                _context.SaveChangesAsync();
            }else{
                return BadRequest("User does not exist !");
            }
           return user;
        }
        [HttpPut("Update/{{id}}")]
        public async Task<ActionResult<AppUser>> UpdateUser(UpdateUserDto UserUpdate, int id){
            var user = _context.Users.SingleOrDefault(x => x.Id == id);
            using var hmac = new HMACSHA512(); 
            if(user != null){
                user.UserName = UserUpdate.userName;
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(UserUpdate.Password));
                user.PasswordSalt = hmac.Key;
            }
            // }else {
            //     return BadRequest("User does not exist !");
            // }
            _context.SaveChangesAsync();
                return user;
            
        }

        [HttpPost("login")]
        public async Task<ActionResult<AppUser>> Login(LoginDto loginDto){

            var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.userName);
            if(user == null) return Unauthorized("Invalid User Name !");

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for(int i=0 ;i<computedHash.Length;i++){
                if(computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid Password !");
            }
            return user;
        }
    }
}
