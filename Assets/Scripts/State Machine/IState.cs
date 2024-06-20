using StatePattern.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern.StateMachine
{
    public interface IState
    {
        public EnemyController Owner { get; set; }
        public void OnStateEnter();
        public void Update();
        public void OnStateExit();
    }
}

