using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal_aukcyjny.View
{
    public interface ILoginView
    {
        string path { get; set; }
        string failureText { get; set; }
        bool errorMessage { get; set; }
    }
}
