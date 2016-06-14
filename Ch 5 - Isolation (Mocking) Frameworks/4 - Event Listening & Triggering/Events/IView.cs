using System;

namespace Events
{
    public interface IView
    {
        event Action Loaded;
        event Action<string> ErrorOccurred;
        void Render(string text);
    }
}
