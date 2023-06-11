using cb2wled.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cb2wled
{
    public interface IEventHandler
    {
        Task Handle(Event evt, CancellationToken stoppingToken);
    }
}
