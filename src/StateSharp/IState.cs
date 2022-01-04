using System;

namespace StateSharp
{
    public interface IState : IComparable
    {
        string Name { get; }

        int Value { get; }
    }
}
