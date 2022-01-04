using System;

namespace StateSharp
{
    public interface ICommand : IComparable
    {
        string Name { get; }

        int Value { get; }
    }
}
