using System;

namespace StateSharp
{
    public abstract class State : Enumeration, IState
    {
        public State(string name, int id) 
            : base(name, id)
        {
        }
    }
}
