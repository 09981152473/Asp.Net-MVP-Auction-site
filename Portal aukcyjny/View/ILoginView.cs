using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal_aukcyjny.View
{
    public interface ILoginView
    {
        string Loginpath { get; set; }
        string FailureMassage { get; set; }
        bool ErrorMessage { get; set; }
    }
}
