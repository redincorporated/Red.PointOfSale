﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red.PointOfSale.Commands
{
    public abstract class AbstractCommand : ICommand
    {
        public abstract void Run();
    }

    public interface ICommand
    {
        void Run();
    }
}
