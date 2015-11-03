using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public interface Command
    {
        /// <summary>
        /// execute le mouvement
        /// </summary>
        void @do();
        void redo();
        void undo();
        void canDo();
        void done();
    }
}