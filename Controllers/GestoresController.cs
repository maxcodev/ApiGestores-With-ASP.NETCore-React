using ApiGestores.Context;
using ApiGestores.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiGestores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestoresController : Controller
    {
        private readonly AppDbContext context;

        public GestoresController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<GestoresController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.GestoresDb.ToList());
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<GestoresController>/5
        [HttpGet("{id}", Name ="GetGestor")]
        public ActionResult Get(int id)
        {
            try
            {
                var gestor = context.GestoresDb.FirstOrDefault(g=>g.Id == id);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return null;
        }

        // POST api/<GestoresController>
        [HttpPost]
        public ActionResult Post([FromBody]GestoresBd gestor)
        {
            try
            {
                context.GestoresDb.Add(gestor); // Insertamos el registro dentro de la BDD, el cual es el que nos pasaron como parametro "gestor"
                context.SaveChanges();  //Guardamos los cambios
                return CreatedAtRoute("GetGestor", new {id= gestor.Id}, gestor); //Retornamos al usuario lo que se insertól, incluyendo el id autoincrementable que se generó
                //Utilizamos "GetGestor" que es el "Get id" lo reciba el metodo Get
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<GestoresController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] GestoresBd gestor)
        {
            try
            {
                if(gestor.Id == id)
                {
                    context.Entry(gestor).State = EntityState.Modified; 
                    context.SaveChanges();  //Guardamos los cambios
                    return CreatedAtRoute("GetGestor", new { id = gestor.Id }, gestor);
                }
                else
                {
                    return BadRequest();               }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<GestoresController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var gestor=context.GestoresDb.FirstOrDefault(g => g.Id == id);
                if (gestor != null)
                {
                    context.GestoresDb.Remove(gestor);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);            }
        }
    }
}
