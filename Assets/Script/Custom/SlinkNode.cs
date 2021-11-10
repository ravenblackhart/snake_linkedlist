using System;

namespace Script.Custom
{
    public class SlinkNode<T>
    {
        public SlinkNode<T> Next;

        public void SetNext(SlinkNode<T> nextNode)
        {
            Next = nextNode;
        }
        
        
    }
}