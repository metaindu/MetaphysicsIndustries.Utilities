using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MetaphysicsIndustries.Utilities
{
    public class ThreadShunt
    {
        [STAThread]
        public static void Shunt(ThreadStart target)
        {
            Thread x = new Thread(target);
            x.SetApartmentState(ApartmentState.STA);
            x.Start();
            x.Join();
        }

        [STAThread]
        public static void Shunt(ParameterizedThreadStart target, object parameter)
        {
            Thread x = new Thread(target);
            x.SetApartmentState(ApartmentState.STA);
            x.Start(parameter);
            x.Join();
        }
    }
}
