using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExemploHangfire.Worker.Services
{
    public class ExemploService : IExemploService
    {
        public void ProcessarDisable()
        {
            Console.WriteLine($"ProcessarDisable: {DateTime.Now}");
            Thread.Sleep(120000);
        }

        public void ProcessarMaximum()
        {
            Console.WriteLine($"ProcessarMaximum: {DateTime.Now}");
            Thread.Sleep(120000);
        }
    }
}
