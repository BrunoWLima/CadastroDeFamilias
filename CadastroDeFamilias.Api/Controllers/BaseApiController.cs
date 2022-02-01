﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CadastroDeFamilias.Api.Controllers
{
    public abstract class BaseApiController : Controller
    {
        [NonAction]
        public override OkObjectResult Ok([ActionResultObjectValue] object value)
        {
            return new OkObjectResult(new { StatusCode = StatusCodes.Status200OK, Result = value });
        }

        [NonAction]
        public new OkObjectResult Ok()
        {
            return new OkObjectResult(new { StatusCode = StatusCodes.Status200OK });
        }

        [NonAction]
        public override ConflictObjectResult Conflict(object error)
        {
            return new ConflictObjectResult(new { StatusCode = StatusCodes.Status409Conflict, Result = error });
        }

        [NonAction]
        public override BadRequestObjectResult BadRequest(object error)
        {
            return new BadRequestObjectResult(new { StatusCode = StatusCodes.Status400BadRequest, Result = error });
        }

        [NonAction]
        public new NotFoundObjectResult NotFound()
        {
            return new NotFoundObjectResult(new { StatusCode = StatusCodes.Status404NotFound });
        }
    }
}
