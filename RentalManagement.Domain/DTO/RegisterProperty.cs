﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagement.Domain.DTO
{
    public record RegisterProperty(
        string Name,
        string Description
    );
}
