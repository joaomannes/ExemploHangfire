using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExemploHangfire.Worker.Services
{
    public class ExemploService : IExemploService
    {
        public void Processar()
        {
            Thread.Sleep(2000);
        }
    }
}
