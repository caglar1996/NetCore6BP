namespace BP.API.BackgroundServices
{
    public class DateTimeLogWriter : IHostedService, IDisposable
    {
        private Timer timer;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            //Console.WriteLine($"{nameof(DateTimeLogWriter)} Service Started..");

            //while (!cancellationToken.IsCancellationRequested)
            //{
            //    WriteDateTimeonLog();

            //    await Task.Delay(1000);
            //}

            // timer = new Timer(WriteDateTimeonLog, new { Id = 1 }, TimeSpan.Zero, TimeSpan.FromSeconds(1));

            return Task.CompletedTask;

        }

        private void WriteDateTimeonLog(object state)
        {
            Console.WriteLine($"DateTime is {DateTime.Now.ToLongDateString()} value: {state.GetType().GetProperty("Id").GetValue(state)}");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            timer.Change(Timeout.Infinite, 0);


            Console.WriteLine($"{nameof(DateTimeLogWriter)} Service Stopped..");

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            timer.Dispose();
            timer = null;
        }
    }

    public class DateTimeLogWriter2 : BackgroundService
    {
        private Timer timer;
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            timer = new Timer(WriteDateTimeonLog, new { Id = 1 }, TimeSpan.Zero, TimeSpan.FromSeconds(1));

            return Task.CompletedTask;
        }

        private void WriteDateTimeonLog(object state)
        {
            Console.WriteLine($"DateTime is {DateTime.Now.ToLongDateString()} value: {state.GetType().GetProperty("Id").GetValue(state)}");
        }

        public override void Dispose()
        {
            Console.WriteLine(timer);
            timer.Dispose();
            timer = null;
            Console.WriteLine(timer);
            base.Dispose();
        }
    }
}
