using System;
using System.ComponentModel.DataAnnotations;

namespace PacmanWeb.Models.GameModels
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
