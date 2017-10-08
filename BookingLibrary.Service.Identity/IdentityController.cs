﻿using System;
using Microsoft.AspNetCore.Mvc;

namespace BookingLibrary.Service.Identity
{
    [Route("api/[controller]")]
    public class IdentityController : Controller
    {
        [HttpGet]
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}