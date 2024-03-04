using AutoApi.Data;
using AutoApi.Dtos;
using AutoApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace AutoApi
{
    public class AutoApiApplication
    {
        public async Task<IResult> GetAllAutos(AutoDb db)
        {
            return TypedResults.Ok(await db.Autos.Select(x => new AutoDto(x)).ToArrayAsync());
        }

        public async Task<IResult> CreateAuto(AutoDto autoDto, AutoDb db)
        {
            var autoModel = new AutoModel
            {
                Make = autoDto.Make,
                Model = autoDto.Model,
                Year = autoDto.Year
            };

            db.Autos.Add(autoModel);
            await db.SaveChangesAsync();

            var newAutoDto = new AutoDto(autoModel);

            return TypedResults.Created($"/{newAutoDto.Id}", newAutoDto);
        }

    }
}
