using System;

namespace Script.Support
{
    public class Slinky<T> where T : ISlinkList<T>
    {
        private int _count;
        
        public int Count
        {
            get
            {
                return _count;
            }
        }

        public void GetRange()
        {
            
        }

        public void RemoveRange()
        {
            
        }
    }
}