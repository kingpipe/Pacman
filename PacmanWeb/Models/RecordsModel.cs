using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PacmanWeb.Models
{
    public class RecordsModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Score { get; set; }

        public int Level { get; set; }

        public DateTime Time { get; set; }

        public string Map { get; set; }
    }
}
