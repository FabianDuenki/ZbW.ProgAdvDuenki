using System;
using System.Collections;
using System.Collections.Generic;

namespace _3_RecursiveList {
    public class RecursiveList<T> {
        public class Node {
            public Node Next { get; set; }
            public T Value { get; private set; }

            public Node(T val) {
                Value = val;
            }
        }

        private Node root;
        private Node tail;

        public IEnumerable Traverse
        {
            get { return Traverse(); }
        }
        public IEnumerable Inverse
        {
            get { return Inverse(); }
        }

        public RecursiveList() {
            root = new Node(default(T));
            tail = root;
        }

        private IEnumerable<T> Traverse()
        {
            
        }

        private IEnumerable<T> Inverse()
        {

        }

        public void Append(T val) {
            tail.Next = new Node(val);
            tail = tail.Next;
        }
    }
}