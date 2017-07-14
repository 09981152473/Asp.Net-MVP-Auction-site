using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Resources;

namespace Portal_aukcyjny.Repositories
{
    public class ResManModels
    {
       public  ResourceManager switch_language(bool Language)
        {
            if (Language == true)
                return new ResourceManager(typeof(Portal_aukcyjny.Resource.en));
            else
                return new ResourceManager(typeof(Portal_aukcyjny.Resource.pl));
        }

    }
}