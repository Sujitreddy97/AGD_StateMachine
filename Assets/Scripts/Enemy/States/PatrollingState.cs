using StatePattern.StateMachine;
using UnityEngine;

namespace StatePattern.Enemy
{
    public class PatrollingState : IState
    {
        public EnemyController Owner { get; set; }
        private IStateMachine stateMachine;
        private int currenrPatrolingIndex = -1;
        private Vector3 destination;

        public PatrollingState(IStateMachine stateMachine) => this.stateMachine = stateMachine;

        public void OnStateEnter()
        {
            SetNextWayPointIndex();
            destination = GetDestination();
            MoveTowardsDestination();
        }

        public void Update()
        {
            if(ReachedDestination())
                stateMachine.ChangeState(States.IDLE);
        }

        public void OnStateExit(){ }

        private void SetNextWayPointIndex()
        {
            if (currenrPatrolingIndex == Owner.Data.PatrollingPoints.Count - 1)
                currenrPatrolingIndex = 0;
            else
                currenrPatrolingIndex++;
        }

        private Vector3 GetDestination() => Owner.Data.PatrollingPoints[currenrPatrolingIndex];

        private void MoveTowardsDestination()
        {
            Owner.Agent.isStopped = false;
            Owner.Agent.SetDestination(destination);
        }

        private bool ReachedDestination() => Owner.Agent.remainingDistance <= Owner.Agent.stoppingDistance;
    }
}