﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetMentor.DemoEF.CodeFirst.Data.Context;
using NetMentor.DemoEF.CodeFirst.Entities.Models;
using NetMentor.DemoEF.CodeFirst.Entities.ResponseBD;

namespace NetMentor.DemoEF.CodeFirst.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuerySqlController : ControllerBase
    {
        private readonly NorthwindContext context;

        public QuerySqlController(NorthwindContext context)
        {
            this.context = context;
        }

        [HttpGet("raw-sq/{userId}")]
        public async Task<UserResponse?> GetById(int userId)
        {
            var result = await context
                     .UsersResponseSP
                     .FromSqlInterpolated($"CALL usp_ObtenerUsuarios({userId})")
                     .ToListAsync();

            return result.FirstOrDefault();
        }         

    }
}
