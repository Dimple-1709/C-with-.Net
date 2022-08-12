using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitalWatch
{
    public class HeartRateVitalManagementApp
    {
        public event Action Alarm;
        public int HR { get; set; }

        public void HeartRateVitalSensor()
        {
            Random num = new Random();
            HR = num.Next(30, 160);
        }

        public void Display()
        {
            Console.WriteLine($"Heart Rate : {HR}");
            if (HR<40 || HR > 130)
            {
                this.NotifyObserver();
            }
        }

        private void NotifyObserver()
        {
            if (Alarm != null)
            {
                Alarm.Invoke(); 
            }

        }

    }

    public class Vibrator
    {
        public void Vibrate()
        {
            Console.WriteLine("Vibrate");
        }
    }

    public class Beeper
    {
        public void BeepSound()
        {
            Console.WriteLine("Beep");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            HeartRateVitalManagementApp _app = new HeartRateVitalManagementApp();

            Vibrator _vibrator = new Vibrator();
            Beeper _beep = new Beeper();
           

            _app.Alarm += _vibrator.Vibrate;
            _app.Alarm += _beep.BeepSound;

            while (true)
            {
                _app.HeartRateVitalSensor();
                _app.Display();
                System.Threading.Thread.Sleep(2000);
            }
        }
    }
}
