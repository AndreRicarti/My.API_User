using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_User.Models;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using System.IO;

namespace Api_User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirebaseUserTokensController : ControllerBase
    {
        private readonly UserDbContext _context;

        public FirebaseUserTokensController(UserDbContext context)
        {
            _context = context;
        }

        // GET: api/FirebaseUserTokens
        [HttpGet]
        public FirebaseUserToken GetFirebaseUserTokens()
        {
            var firebaseUserToken = _context.FirebaseUserTokens.OrderByDescending(p => p.Id).FirstOrDefault();
            return firebaseUserToken;
        }

        // GET: api/FirebaseUserTokens/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFirebaseUserToken([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var firebaseUserToken = await _context.FirebaseUserTokens.FindAsync(id);

            if (firebaseUserToken == null)
            {
                return NotFound();
            }

            return Ok(firebaseUserToken);
        }

        // PUT: api/FirebaseUserTokens/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFirebaseUserToken([FromRoute] int id, [FromBody] FirebaseUserToken firebaseUserToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != firebaseUserToken.Id)
            {
                return BadRequest();
            }

            _context.Entry(firebaseUserToken).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FirebaseUserTokenExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FirebaseUserTokens
        [HttpPost]
        public async Task<IActionResult> PostFirebaseUserToken([FromBody] FirebaseUserToken firebaseUserToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (firebaseUserToken.UserId != 0)
            {
                firebaseUserToken.User = null;
            }

            _context.FirebaseUserTokens.Add(firebaseUserToken);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFirebaseUserToken", new { id = firebaseUserToken.Id }, firebaseUserToken);
        }

        // DELETE: api/FirebaseUserTokens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFirebaseUserToken([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var firebaseUserToken = await _context.FirebaseUserTokens.FindAsync(id);
            if (firebaseUserToken == null)
            {
                return NotFound();
            }

            _context.FirebaseUserTokens.Remove(firebaseUserToken);
            await _context.SaveChangesAsync();

            return Ok(firebaseUserToken);
        }

        private bool FirebaseUserTokenExists(int id)
        {
            return _context.FirebaseUserTokens.Any(e => e.Id == id);
        }

        [HttpPost("/api/Firebase/CloudMessaging", Name = "CloudMessaging")]
        public void CloudMessaging([FromBody] FirebaseUserToken firebaseUserToken)
        {
            WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            tRequest.Method = "post";
            //serverKey - Key from Firebase cloud messaging server  
            tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAE3Ut1pc:APA91bH8cPa0kCh8HF5fjHj8ufMefhQCkXzoF5VYPwPMsbIhXEOAcp17FMczEt5kQY3fARkT8buaKW3bVqnl4frGsrIYLK_RGWTqU8zB4HsySYv8n_SivJ7KEpaZ-keDP0XNPNGKg9JV"));
            //Sender Id - From firebase project setting  
            tRequest.Headers.Add(string.Format("Sender: id={0}", "83570316951"));
            tRequest.ContentType = "application/json";
            var payload = new
            {
                to = firebaseUserToken.Token,
                priority = "high",
                content_available = true,
                notification = new
                {
                    body = "MyDancer",
                    title = "Vamos dançar seu lindo!",
                    badge = 1
                },
            };

            string postbody = JsonConvert.SerializeObject(payload).ToString();
            Byte[] byteArray = Encoding.UTF8.GetBytes(postbody);
            tRequest.ContentLength = byteArray.Length;
            using (Stream dataStream = tRequest.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
                using (WebResponse tResponse = tRequest.GetResponse())
                {
                    using (Stream dataStreamResponse = tResponse.GetResponseStream())
                    {
                        if (dataStreamResponse != null) using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                //result.Response = sResponseFromServer;
                            }
                    }
                }
            }
        }
    }
}