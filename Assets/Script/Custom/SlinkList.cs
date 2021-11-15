using System;
using System.Collections.Generic;
using Object = System.Object;
using UnityEngine;

namespace Script.Custom
{
    public class SlinkList<T>
    {
        public SlinkNode First;
        public SlinkNode Last;

        public class SlinkNode
        {
            public T objectData;
            public SlinkNode next;

            public SlinkNode(T data)
            {
                objectData = data;
                next = null;
            }
        }

        public int getCount()
        {
            SlinkNode temp = First;
            int count = 0;
            while (temp != null)
            {
                count++;
                temp = temp.next;
            }

            return count;
        }


        public void AddFirst(T new_objectData)
        {
            SlinkNode new_slinkNode = new SlinkNode(new_objectData);
            new_slinkNode.next = First;
            First = new_slinkNode;
        }

        public void AddLast(SlinkNode prev_slinkNode, T new_objectData)
        {
            SlinkNode new_slinkNode = new SlinkNode(new_objectData);

            if (First == null)
            {
                First = new SlinkNode(new_objectData);
                return;
            }

            new_slinkNode.next = null;

            SlinkNode last = First;
            while (last.next != null) last = last.next;

            last.next = new_slinkNode;
            return;
        }

        public void InsertBefore(SlinkNode prev_slinkNode, T new_objectData)
        {
            if (prev_slinkNode.next == null) return;

            SlinkNode new_slinkNode = new SlinkNode(new_objectData);
            new_slinkNode.next = prev_slinkNode;
            prev_slinkNode = new_slinkNode;
        }

        public void InsertAfter(SlinkNode prev_slinkNode, T new_objectData)
        {
            if (prev_slinkNode == null) return;

            SlinkNode new_slinkNode = new SlinkNode(new_objectData);
            new_slinkNode.next = prev_slinkNode.next;
            prev_slinkNode.next = new_slinkNode;
        }

        public void RemoveFirst(T key)
        {
            SlinkNode temp = First, prev = null;

            // if (temp != null && temp.objectData == key)
            // {
            //     First = temp.next;
            //     return;
            // }
            //
            // while (temp != null && temp.objectData != key)
            // {
            //     prev = temp;
            //     temp = temp.next;
            // }
        }

        public void RemoveLast()
        {
        }

        public void RemoveAt()
        {
        }
    }
}