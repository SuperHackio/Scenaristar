using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Scenaristar;

public static class ControlEx
{
    [DebuggerStepThrough]
    public static void SetDoubleBuffered(this Control control)
    {
        // set instance non-public property with name "DoubleBuffered" to true
        typeof(Control).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, control, new object[] { true });
    }
}