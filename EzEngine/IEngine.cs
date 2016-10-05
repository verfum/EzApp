using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzEngine
{
    public delegate void DrawDelegate(int a_millisecs);
    interface IEngine
    {
        
        void drawLine();

        void registerForDraw(DrawDelegate a_drawCallback);
    }
}
