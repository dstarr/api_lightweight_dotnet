using AutoApi.Data;
using AutoApi.Dtos;
using AutoApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AutoApi
{
    public class AutoApiApplication
    {
        public async Task<IResult> GetAllAutos(AutoDb db)
        {
            var autos = await db.Autos.Select(x => new AutoDto(x)).ToArrayAsync();

            return TypedResults.Ok(autos);
        }

        public async Task<IResult> CreateAuto(AutoDto autoDto, AutoDb db)
        {
            var autoModel = new AutoModel
            {
                Make = autoDto.Make,
                Model = autoDto.Model,
                Year = autoDto.Year
            };

            var model = db.Autos.Add(autoModel);
            await db.SaveChangesAsync();

            Console.WriteLine();

            var newAutoDto = new AutoDto(model.Entity);

            return TypedResults.Created($"/{newAutoDto.Id}", newAutoDto);
        }

    }
}
