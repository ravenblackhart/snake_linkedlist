using System;

namespace Script.Support
{
    public interface ISlinkList <T>
    {
        //Ints
        public int Count { get; }
        public int IndexOf(T item);

        //Bools 
        
        //Functions
        public void Add(T item);

        public void Insert(int index, T item);
        
        public void RemoveAt(int index);
        
        
        
        



    }
}