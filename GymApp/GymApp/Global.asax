using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymAppService;

namespace GymApp
{
    class Global : Dependencies
    {
    }

    protected override IKernel CreateKernel()
    {
        return new StandardKernel(new WCFNinjectModule());
    }
}
