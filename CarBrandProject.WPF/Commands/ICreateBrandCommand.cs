﻿using CarBrandProject.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.Commands
{
    public interface ICreateBrandCommand
    {
        Task Execute(BrandModel brandModel);
    }
}
