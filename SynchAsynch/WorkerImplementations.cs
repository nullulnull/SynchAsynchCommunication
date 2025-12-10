using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchAsynch
{
    public class SyncWorker
    {
        private readonly CommunicationService _service = new();
        private readonly BlockingCollection<int> _queue;

        public SyncWorker(BlockingCollection<int> queue)
        {
            _queue = queue;
        }

        public void Run()
        {
            foreach (var id in _queue.GetConsumingEnumerable())
            {
                _ = _service.HandleRequestSync(id);
            }
        }
    }

    public class AsyncWorker
    {
        private readonly CommunicationService _service = new();
        private readonly BlockingCollection<int> _queue;

        public AsyncWorker(BlockingCollection<int> queue)
        {
            _queue = queue;
        }

        public async Task RunAsync()
        {
            List<Task> activeTasks = new();

            foreach (var id in _queue.GetConsumingEnumerable())
            {
                activeTasks.Add(_service.HandleRequestAsync(id));
            }

            await Task.WhenAll(activeTasks);
        }
    }

}
