using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patricia_Adelina_mobila.Models;
using System.Collections;

namespace Patricia_Adelina_mobila.Data
{
    public class ProgramareDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public ProgramareDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ProgramareFilm>().Wait();
            _database.CreateTableAsync<ServiuciuCinematograf>().Wait();
            _database.CreateTableAsync<ListaServiciuCinematograf>().Wait();
            _database.CreateTableAsync<Cinematograf>().Wait();
        }

        public Task<List<ProgramareFilm>> GetProgramariFilmAsync()
        {
            return _database.Table<ProgramareFilm>().ToListAsync();
        }

        public Task<ProgramareFilm> GetProgramareFilmAsync(int id)
        {
            return _database.Table<ProgramareFilm>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveProgramareFilmAsync(ProgramareFilm programareFilm)
        {
            if (programareFilm.ID != 0)
            {
                return _database.UpdateAsync(programareFilm);
            }
            else
            {
                return _database.InsertAsync(programareFilm);
            }
        }

        public Task<int> DeleteProgramareFilmAsync(ProgramareFilm programareFilm)
        {
            return _database.DeleteAsync(programareFilm);
        }

        public Task<List<ServiuciuCinematograf>> GetServiciiCinematografAsync()
        {
            return _database.Table<ServiuciuCinematograf>().ToListAsync();
        }

        public Task<int> SaveServiuiuCinematografAsync(ServiuciuCinematograf serviciu)
        {
            if (serviciu.ID != 0)
            {
                return _database.UpdateAsync(serviciu);
            }
            else
            {
                return _database.InsertAsync(serviciu);
            }
        }

        public Task<int> DeleteServiuciuCinematografAsync(ServiuciuCinematograf serviciu)
        {
            return _database.DeleteAsync(serviciu);
        }

        public Task<List<ListaServiciuCinematograf>> GetListaServiciiCinematografAsync()
        {
            return _database.Table<ListaServiciuCinematograf>().ToListAsync();
        }

        public Task<int> SaveListaServiciuCinematografAsync(ListaServiciuCinematograf listaServiciu)
        {
            if (listaServiciu.ID != 0)
            {
                return _database.UpdateAsync(listaServiciu);
            }
            else
            {
                return _database.InsertAsync(listaServiciu);
            }
        }

        public Task<int> DeleteListaServiciuCinematografAsync(ListaServiciuCinematograf listaServiciu)
        {
            return _database.DeleteAsync(listaServiciu);
        }

        public Task<List<Cinematograf>> GetCinematografeAsync()
        {
            return _database.Table<Cinematograf>().ToListAsync();
        }

        public Task<int> SaveCinematografAsync(Cinematograf cinematograf)
        {
            if (cinematograf.ID != 0)
            {
                return _database.UpdateAsync(cinematograf);
            }
            else
            {
                return _database.InsertAsync(cinematograf);
            }
        }

        public Task<int> DeleteCinematografAsync(Cinematograf cinematograf)
        {
            return _database.DeleteAsync(cinematograf);
        }

        public Task<List<ListaServiciuCinematograf>> GetListaServiciiCinematografAsync(int iD)
        {
            return _database.Table<ListaServiciuCinematograf>().Where(item => item.ID == iD).ToListAsync();
        }
    }
}

