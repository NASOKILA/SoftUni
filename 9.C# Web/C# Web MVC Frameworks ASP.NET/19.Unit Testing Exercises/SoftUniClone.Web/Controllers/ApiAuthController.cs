using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SoftUniClone.Models;
using SoftUniClone.Web.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SoftUniClone.Web.Controllers
{

    [Route("api/token")]
    [ApiController]
    [IgnoreAntiforgeryToken]
    public class ApiAuthController : Controller
    {

        //TOVA PRAVI CQLATA RABOTA S USERI 
        private readonly UserManager<User> userManager;

        public ApiAuthController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        
        // POST api/<controller>
        [AllowAnonymous] //POZVOLQVAME NA NELOGNATI USERI DA DOSTUPVAT DO TUKA
        [HttpPost("")]
        public async Task<IActionResult> GenerateToken([FromBody]LoginModel loginModel)
        {
            //Ako e validen potrebitelq mu pravim nov token

            //VZIMAME POTREBITELQ OT IMETO MU 
            var user = await this.userManager.FindByNameAsync(loginModel.Username);

            //MOJEM DA PROVERIM NA USERA PAROLATA DALI SUVPADA
            bool passwordMatches = await this.userManager.CheckPasswordAsync(user, loginModel.Password);

            if (!passwordMatches) {
                return Unauthorized();  //Usera ne e authoriziran
            }




            //VAJNOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!

            //key for signin credentials      
            string keyword = "supersecret";   //izmislqme si kluchova duma
            var keywordInBytes = Encoding.UTF8.GetBytes(keyword); //iska bitove
            var key = new SymmetricSecurityKey(keywordInBytes);  //Iska go v bitove

            //we have to pass an object of type Sign in credentials, it accepts a key and an algorithum
            string algorithumString = "SH256";
            var signinCredentialsCreated = new SigningCredentials( key, algorithumString);

            //Generate token
            var tokenInitializer = new JwtSecurityToken(
                issuer: "localhost",
                audience: "localhost",
                expires: DateTime.Now + TimeSpan.FromHours(24),
                signingCredentials  : signinCredentialsCreated  
                );


            //GET THE ACTUAL TOKEN TO USE
            string actualJwtToken = new JwtSecurityTokenHandler().WriteToken(tokenInitializer);

            return Ok(actualJwtToken);
        }

        /*
        // GET: api/<controller>
        [HttpGet("")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }



        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        */
    }
}
