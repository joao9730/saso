using Microsoft.IdentityModel.Tokens;
using SistemaAmigoSecretoOnline.Models;
using SistemaAmigoSecretoOnline.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Net;
using System.IdentityModel.Tokens.Jwt;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace SistemaAmigoSecretoOnline.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [System.Web.Http.RoutePrefix("api/token")]
    public class TokenController : ApiController
    {


        /*[System.Web.Http.HttpPost]
        [System.Web.Http.Route("token")]
        public IHttpActionResult Token()
        {
            // string tokenString = "test";

           var header = Request.Headers["Authorization"];
           // if (header.ToString().StartsWith("Basic"))
            {
                var credValue = header.ToString().Substring("Basic ".Length).Trim();
                var usernameAndPassenc = Encoding.UTF8.GetString(Convert.FromBase64String(credValue));
                var usernameAndPass = usernameAndPassenc.Split();
                if(usernameAndPass[0]=="Admin" && usernameAndPass[1]=="pass")
                { 
                var claimsdata = new[] { new Claim(ClaimTypes.Name, usernameAndPass[0]) };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("aspdfiojsioasopdifjasgijspodfijvbnsdciopnmskviojvas"));
                var signInCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
                var token = new JwtSecurityToken(
                    issuer: "mysite.com",
                    audience: "mysite.com",
                    expires: DateTime.Now.AddMinutes(1),
                    claims: claimsdata,
                    signingCredentials: signInCred
                    );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(tokenString);
                }
            }
            return BadRequest("Erro");

            // return View();
        }*/

    }
    
}