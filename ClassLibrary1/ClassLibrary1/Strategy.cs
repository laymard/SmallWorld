using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public interface MovementStrategy
    {

        ClassLibrary1.Position suggestMovevement(string Unit);
    }
}
