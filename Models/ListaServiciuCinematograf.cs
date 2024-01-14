using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patricia_Adelina_mobila.Models;


namespace Patricia_Adelina_mobila.Models
{
    public class ListaServiciuCinematograf
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [SQLiteNetExtensions.Attributes.ForeignKey(typeof(ProgramareFilm))]
        public int ProgramareFilmID { get; set; }

        public int ServiuciuCinematografID { get; set; }
    }
}
