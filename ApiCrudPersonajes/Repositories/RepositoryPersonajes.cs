using ApiCrudPersonajes.Data;
using ApiCrudPersonajes.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCrudPersonajes.Repositories
{
    public class RepositoryPersonajes
    {
        private PersonajesContext context;

        public RepositoryPersonajes(PersonajesContext context)
        {
            this.context = context;
        }

        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            return await this.context.Personajes.ToListAsync();
        }

        public async Task<Personaje> FindPersonajesAsync(int idperso)
        {
            return await this.context.Personajes.FirstOrDefaultAsync(x => x.IdPersonaje == idperso);
        }

        private int GetMaxIdHospitalesAsync()
        {
            if (this.context.Personajes.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this.context.Personajes.Max(z => z.IdPersonaje) + 1;
            }
        }

        public async Task InsertarHospitalAsync(string nombre, string imagen, int idserie)
        {
            int idperso = GetMaxIdHospitalesAsync();
            Personaje newpersonaje = new Personaje();
            newpersonaje.IdPersonaje = idperso;
            newpersonaje.NombrePersonaje = nombre;
            newpersonaje.Imagen = imagen;
            newpersonaje.IdSerie = idserie;
            this.context.Personajes.Add(newpersonaje);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdatePersonajesAsync(Personaje personaje)
        {
            Personaje newpersoanaje = await this.FindPersonajesAsync(personaje.IdPersonaje);
            newpersoanaje.NombrePersonaje = personaje.NombrePersonaje;
            newpersoanaje.Imagen = personaje.Imagen;
            newpersoanaje.IdSerie = personaje.IdSerie;
            await this.context.SaveChangesAsync();
        }

        public async Task DeletePersonajeASync(int id)
        {
            Personaje personaje = await this.FindPersonajesAsync(id);
            this.context.Personajes.Remove(personaje);
            await this.context.SaveChangesAsync();
        }
    }
}
