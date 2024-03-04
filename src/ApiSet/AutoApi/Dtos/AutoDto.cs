using System.Xml.Linq;
using AutoApi.Models;

namespace AutoApi.Dtos
{
    public class AutoDto()
    {
        public AutoDto(AutoModel autoItem) : this()
        {
            Id = autoItem.Id;
            Model = autoItem.Model;
            Year = autoItem.Year;
            Make = autoItem.Make;
        }
        
        public int Id { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; }
        public string? Make { get; set; }
    }
}
