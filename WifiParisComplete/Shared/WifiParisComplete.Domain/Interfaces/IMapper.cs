﻿namespace WifiParisComplete.Domain
{
    public interface IMapper<T1, T2>
    {
        T2 Map (T1 source);
    }
}
