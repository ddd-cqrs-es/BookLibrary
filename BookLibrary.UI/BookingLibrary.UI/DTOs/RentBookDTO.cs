﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingLibrary.UI.DTOs
{
    public class RentBookDTO
    {
        public Guid BookId { get; set; }

        public Guid CustomerId { get; set; }
    }
}