using System;

namespace CSharptrainingAssignments
{
    public class HeartRateVitalSensor
    {
        public event Action<int> HeartBeatChange;

        internal void GenerateReading()
        {
            Random randomNumber = new Random();
            for (int i = 01; i < 20; i++)
            {
                if (HeartBeatChange is not null)
                {
                    System.Threading.Thread.Sleep(1000);
                    HeartBeatChange.Invoke(randomNumber.Next(30, 150));
                }
            }
        }
    }

    public class HBVitalMngApp
    {
        public event Action VitalCritical;
        HeartRateVitalSensor VitalSensor = new HeartRateVitalSensor();
        Display _display = new Display();

        public HBVitalMngApp()
        {
            VitalSensor.HeartBeatChange += VitalSensor_HeartBeatChange;
        }

        public void monitor()
        {
            VitalSensor.GenerateReading();
        }

        private void VitalSensor_HeartBeatChange(int reading)
        {
            Console.WriteLine($"Data Received {reading }");
            _display.show();
            if (reading < 50 || reading > 130)
            {
                this.NotifyObserver();
            }
        }

        private void NotifyObserver()
        {
            if (VitalCritical is not null)
            {
                VitalCritical.Invoke();
            }
        }
    }

    public class Display
    {
        public void show()
        {
            Console.WriteLine("Data displayed");
        }
    }

    public class Vibrate
    {
        public void DeviceVibrate()
        {
            Console.WriteLine("Device is vibrated");
        }
    }

    public class Beep
    {
        public void DeviceBeep()
        {
            Console.WriteLine("Device is Beeped");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            HBVitalMngApp hBVitalMngApp = new HBVitalMngApp();

            Vibrate vibrate = new Vibrate();
            hBVitalMngApp.VitalCritical += vibrate.DeviceVibrate;

            Beep beep = new Beep();
            hBVitalMngApp.VitalCritical += beep.DeviceBeep;
            hBVitalMngApp.monitor();
        }
    }
}
