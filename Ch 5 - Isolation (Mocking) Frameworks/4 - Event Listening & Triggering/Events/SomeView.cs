using System;

namespace Events
{
    public class SomeView 
    {
        public event Action Loaded;

        public SomeView()
        {
            Loaded += SetLoadFired;
        }

        public void DoSomethingThatEventuallyFiresThisEvent()
        {
            Loaded.Invoke();
        }

        private void SetLoadFired()
        {

        }
    }
}