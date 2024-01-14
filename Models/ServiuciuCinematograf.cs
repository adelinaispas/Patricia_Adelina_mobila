using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patricia_Adelina_mobila.Models;

namespace Patricia_Adelina_mobila.Models
{
    public class ServiuciuCinematograf
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [SQLite.MaxLength(250), SQLite.NotNull]
        public string Descriere { get; set; }

        [OneToMany]
        public List<ListaServiciuCinematograf> ListaServicii { get; set; }
    }
}
