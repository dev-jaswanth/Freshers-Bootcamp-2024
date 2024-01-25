using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorProject
{
    public interface IPagerNotification
    {
        void SendNotification(string message);
    }

}
