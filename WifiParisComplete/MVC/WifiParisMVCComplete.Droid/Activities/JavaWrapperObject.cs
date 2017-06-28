using System;
namespace WifiParisMVCComplete.Droid
{
    public class JavaWrapperObject<T> : Java.Lang.Object
    {
        public T Object { get; set; }
    }
}
