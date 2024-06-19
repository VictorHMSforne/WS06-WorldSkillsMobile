using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace WS.Models
{
    [Table("PressaoArterial")]
    public class Pressao
    {
        [PrimaryKey,AutoIncrement,NotNull]
        public int Id { get; set; } 
        [NotNull]
        public int Sistole { get; set; }
        [NotNull]
        public int Diastole { get; set; }
        [NotNull]
        public string Data { get; set; }
        [NotNull]
        public string Hora { get; set; }

        public Pressao()
        {
            this.Id = 0;
            this.Sistole = 0;
            this.Diastole = 0;
            this.Data = "";
            this.Hora = "";
        }
    }
}
