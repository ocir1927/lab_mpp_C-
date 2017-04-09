using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services
{
    public class FirmaTransportException:Exception
    {
        public FirmaTransportException()
        {
        }

        public FirmaTransportException(string message) : base(message)
        {
        }

        public FirmaTransportException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
