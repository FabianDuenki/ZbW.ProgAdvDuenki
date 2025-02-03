using System;

namespace DelegatesEvents.MulticastDelegate.CompilerOutput {
    public delegate void Notifier(string sender);

    //public sealed class Notifier : System.MulticastDelegate
    //{
    //    // Methods
    //    public Notifier(object obj, int method) { }

    //    public virtual void Invoke(
    //        string sender) 
    //    { }
    //    public virtual System.IAsyncResult BeginInvoke(
    //        string sender, 
    //        System.AsyncCallback callback, 
    //        object obj) 
    //    { }
    //    public virtual void EndInvoke(
    //        System.IAsyncResult result) 
    //    { }
    //}
}
