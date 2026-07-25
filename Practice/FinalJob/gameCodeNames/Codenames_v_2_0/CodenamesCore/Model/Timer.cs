using System;
using System.Collections.Generic;
using System.Text;

namespace CodenamesCore.Model
{
    public class Timer
    {
        public int CapStepOne;
        public int CaptainThinks;
        public int ComandsThinls;

    public Timer(int capStepOne = 120, int captainThinks = 60, int comandsThinls = 60)
        {
            CapStepOne = capStepOne;
            CaptainThinks = captainThinks;
            ComandsThinls = comandsThinls;
        }
    }
}
