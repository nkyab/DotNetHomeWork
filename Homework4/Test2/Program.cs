using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
    public delegate void Clock(object sender, ClockTime clockTime);
    public class ClockTime
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
        public ClockTime() { }
        public ClockTime(int hour, int minute, int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }
        public void SetClockTime(int hour, int minute, int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }
    }

    public class ClockOn
    {
        public event Clock Tick;
        public event Clock Alarm;

        public ClockTime AlartClockTime;

        public void ClockTick(ClockTime clockTime)
        {
            if (clockTime.Second < 59)
            {
                clockTime.Second++;
            } else if (clockTime.Second >= 59)
            {
                clockTime.Second = 0;
                clockTime.Minute++;
            }else if (clockTime.Minute >= 59)
            {
                clockTime.Minute = 0;
                clockTime.Hour++;
            }else if (clockTime.Hour >= 23)
            {
                clockTime.Hour = 0;
            }
            Console.WriteLine($"时间：{clockTime.Hour}:{clockTime.Minute}:{clockTime.Second}");
            Tick(this, clockTime);
        }

        public void ClockAlarm(ClockTime clockTime, int hour, int minute, int second)
        {
            if (clockTime.Second == second && clockTime.Minute == minute && clockTime.Hour == hour)
            {
                Console.WriteLine("滴滴滴！！！");
            }
            Alarm(this, clockTime);
        }
    }

    class Form
    {
        public ClockOn Clockon = new ClockOn();
        public Form()
        {
            Clockon.Tick += Clockon_Tick;
            Clockon.Alarm += Clockon_Alarm;
        }

        private void Clockon_Alarm(object sender, ClockTime clockTime)
        {
            //throw new NotImplementedException();
            Console.WriteLine("闹钟未激活......");
        }

        private void Clockon_Tick(object sender, ClockTime clockTime)
        {
            //throw new NotImplementedException();
            Console.WriteLine("时钟在走！");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ClockTime clockTime = new ClockTime(0, 0, 0);
            ClockOn clockOn = new ClockOn();
            Form form1 = new Form();
            
            for(int i = 0; i <= 602; i++)
            {
                form1.Clockon.ClockTick(clockTime);
                form1.Clockon.ClockAlarm(clockTime, 0, 3, 20);
            }

            Console.ReadLine();
        }
    }
}
