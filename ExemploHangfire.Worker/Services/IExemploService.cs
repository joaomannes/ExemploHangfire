using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploHangfire.Worker.Services
{
    public interface IExemploService
    {
        [MaximumConcurrentExecutions(1, timeoutInSeconds: 3)]
        void ProcessarMaximum();

        [DisableConcurrentExecution(3)]
        void ProcessarDisable();
    }
}
