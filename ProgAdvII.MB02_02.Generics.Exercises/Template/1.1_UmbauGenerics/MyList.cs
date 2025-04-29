using System;
using System.Collections;
using System.Collections.Generic;

namespace _1._1_UmbauGenerics {
    public class MyList<T> : IEnumerable {
        protected Node<T> head;
        protected Node<T> current = null;

        protected class Node<T> {
            public Node<T> next;
            private T data;

            public Node(T t) {
                next = null;
                data = t;
            }

            public Node<T> Next {
                get { return next; }
                set { next = value; }
            }

            public T Data {
                get { return data; }
                set { data = value; }
            }
        }

        public MyList() {
            head = null;
        }

        public void Add(T t) {
            Node<T> n = new Node<T>(t);
            n.Next = head;
            head = n;
        }

        public IEnumerator GetEnumerator() {
            Node<T> curr = head;
            while (curr != null) {
                yield return curr.Data;
                curr = curr.Next;
            }
        }
    }
}