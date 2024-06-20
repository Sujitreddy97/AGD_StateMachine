using System.Collections;
using UnityEngine;

namespace StatePattern.StateMachine
{
    public interface IStateMachine
    {
        public void ChangeState(States newState);
    }
}