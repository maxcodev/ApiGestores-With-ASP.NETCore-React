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
        // GET: api/<GestoresController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.GestoresDB.ToList());
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
                var gestor = context.GestoresDB.FirstOrDefault(g=>g.id == id);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return null;
        }

        // POST api/<GestoresController>
        [HttpPost]
        public ActionResult Post([FromBody]GestoresBD gestor)
        {
            try
            {
                context.GestoresDB.Add(gestor); // Insertamos el registro dentro de la BDD, el cual es el que nos pasaron como parametro "gestor"
                context.SaveChanges();  //Guardamos los cambios
                return CreatedAtRoute("GetGestor", new {id= gestor.id}, gestor); //Retornamos al usuario lo que se insertól, incluyendo el id autoincrementable que se generó
                //Utilizamos "GetGestor" que es el "Get id" lo reciba el metodo Get
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<GestoresController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] GestoresBD gestor)
        {
            try
            {
                if(gestor.id == id)
                {
                    context.Entry(gestor).State = EntityState.Modified; 
                    context.SaveChanges();  //Guardamos los cambios
                    return CreatedAtRoute("GetGestor", new { id = gestor.id }, gestor);
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
                var gestor=context.GestoresDB.FirstOrDefault(g => g.id == id);
                if (gestor != null)
                {
                    context.GestoresDB.Remove(gestor);
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
