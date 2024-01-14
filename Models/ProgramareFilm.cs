using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patricia_Adelina_mobila.Models;

namespace Patricia_Adelina_mobila.Models
{
    public class ProgramareFilm
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [SQLite.MaxLength(250), SQLite.NotNull, Unique]
        public string Descriere { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataProgramare { get; set; }

        [SQLiteNetExtensions.Attributes.ForeignKey(typeof(Cinematograf))]
        public int CinematografID { get; set; }
    }
}
