using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mega.API.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Mega.API.Controllers
{
    
    [ApiController]
    public class BaseController : ControllerBase
    {
        //public readonly AppSettings _appSettings;

        //public BaseController(IOptions<AppSettings> appSettings)
        //{
        //    _appSettings = appSettings.Value;
        //}

    }
}