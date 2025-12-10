using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchAsynch
{
    public class CommunicationService
    {
        // Simulates CPU + I/O work
        private async Task<string> SimulatedRemoteCallAsync(int id)
        {
            await Task.Delay(300);     // Simulated network latency
            double result = Math.Sqrt(id) * Math.PI;
            return $"Processed {id}: {result:F2}";
        }

        private string SimulatedRemoteCallSync(int id)
        {
            Task.Delay(300).Wait();    // Blocking
            double result = Math.Sqrt(id) * Math.PI;
            return $"Processed {id}: {result:F2}";
        }

        // Public synchronous API
        public string HandleRequestSync(int id)
        {
            return SimulatedRemoteCallSync(id);
        }

        // Public asynchronous API
        public async Task<string> HandleRequestAsync(int id)
        {
            return await SimulatedRemoteCallAsync(id);
        }
    }

}
