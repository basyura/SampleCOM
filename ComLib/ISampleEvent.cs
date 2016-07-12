using System;
using System.Runtime.InteropServices;

namespace ComLib
{
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    [ComVisible(true)]
    public interface ISampleEvent
    {
        /// <summary></summary>
        void StateChanged();
        /// <summary></summary>
        void DateTimeChanged(DateTime date);
    }
}
