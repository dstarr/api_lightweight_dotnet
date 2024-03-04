using System.Xml.Linq;
using AutoApi.Models;

namespace AutoApi.Dtos
{
    public class AutoDto
    {
        public AutoDto(AutoModel autoItem)
        {
            (Id, Make, Model, Year) = (autoItem.Id, autoItem.Make, autoItem.Model, autoItem.Year);
        }

        public int Id { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; }
        public string? Make { get; set; }

    }
}
