using Agro.Scoring.Logic.FinAnalysis;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Agro.Scoring.Api.BackgroundServices
{
    public class FinAnalysisHostedService : IHostedService, IDisposable
    {
        private readonly IQueueScheduler _logic;
        private Timer _timer;
        public FinAnalysisHostedService(IQueueScheduler logic)
        {
            _logic = logic;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        private void DoWork(object state)
        {
            _logic.FindTask().GetAwaiter().GetResult();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(60));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
    }
}
