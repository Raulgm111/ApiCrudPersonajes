using ApiCrudPersonajes.Models;
using ApiCrudPersonajes.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrudPersonajes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private RepositoryPersonajes repo;

        public PersonajesController(RepositoryPersonajes repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Personaje>>> GetPersonajes()
        {
            return await this.repo.GetPersonajesAsync();
        }

        [HttpGet("{idperso}")]
        public async Task<ActionResult<Personaje>> FindPersonaje(int idperso)
        {
            return await this.repo.FindPersonajesAsync(idperso);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePersonaje(Personaje personaje)
        {
            await this.repo.InsertarHospitalAsync(personaje.NombrePersonaje, personaje.Imagen, personaje.IdSerie);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePersonaje(Personaje personaje)
        {
            await this.repo.UpdatePersonajesAsync(personaje);
            return Ok();
        }

        [HttpDelete("{idperso}")]
        public async Task<ActionResult>DeletePersonajes(int idperso)
        {
            await this.repo.DeletePersonajeASync(idperso);
            return Ok();
        }
    }
}
