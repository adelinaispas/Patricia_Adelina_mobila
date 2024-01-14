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
public class Cinematograf
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }

    [SQLite.MaxLength(250), SQLite.NotNull]
    public string NumeCinematograf { get; set; }

    [SQLite.MaxLength(250), SQLite.NotNull]
    public string Adresa { get; set; }

    public string DetaliiCinematograf
    {
        get
        {
            return NumeCinematograf + " " + Adresa;
        }
    }

    [OneToMany]
    public List<ProgramareFilm> Programari { get; set; }
}

}
