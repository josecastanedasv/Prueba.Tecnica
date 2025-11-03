using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creativa.Data
{
    public interface ITrackerRepository
    {
        void Log(string url, string ip);
    }
}
