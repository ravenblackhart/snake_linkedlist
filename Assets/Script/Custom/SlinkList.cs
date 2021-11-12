using UnityEngine;
using Object = System.Object;

namespace Script.Custom
{
    public class SlinkList<T>
    {
        private SlinkNode head; 
        public class SlinkNode
        {
            public Component objectData;
            public SlinkNode next;

            public SlinkNode(Component d)
            {
                objectData = d;
                next = null;
            }
        }
      
        
        public void AddFirst(Component new_objectData)
        {
            SlinkNode new_slinkNode = new SlinkNode(new_objectData);
            new_slinkNode.next = head;
            head = new_slinkNode;
        }

        public void AddLast(SlinkNode prev_slinkNode, Component new_objectData)
        {
            SlinkNode new_slinkNode = new SlinkNode(new_objectData);

            if (head == null)
            {
                head = new SlinkNode(new_objectData);
                return;
            }
            new_slinkNode.next = null;

            SlinkNode last = head;
            while (last.next != null) last = last.next;

            last.next = new_slinkNode;
            return;
        }

        public void InsertBefore(SlinkNode next_slinkNode, Component new_objectData)
        {
            if (next_slinkNode == null) return;

            SlinkNode new_slinkNode = new SlinkNode(new_objectData);
            new_slinkNode.next = next_slinkNode;
        }

        public void InsertAfter(SlinkNode prev_slinkNode, Component new_objectData)
        {
            if (prev_slinkNode == null) return;

            SlinkNode new_slinkNode = new SlinkNode(new_objectData);
            new_slinkNode.next = prev_slinkNode.next;
            prev_slinkNode.next = new_slinkNode;
        }

        public void RemoveFirst(SlinkNode deleteNode)
        {
            if (head == null) return;
            
            
        }
        public void RemoveLast(){}

        public void RemoveAt()
        {
        }
        
        
        
        
        
    }
}