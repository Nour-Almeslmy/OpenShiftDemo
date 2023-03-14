using System;

namespace OpenShiftDemo_Utilities
{
    public class Values
    {
        public int GetRand(int start, int end)
        {
            Random rnd = new Random();
            return rnd.Next(start, end);
        }
    }
}
