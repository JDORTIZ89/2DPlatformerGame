using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Atooi.AI
{
    public class AIBehaviourBossCharge : AIBehaviour
    {

        [SerializeField]
        private AIDataBoard aiBoard;

        [SerializeField]
        private AIPlayerEnterAreaDetector playerDetector;

        [SerializeField]
        private Agent agent;

        private Vector3 tempPosition;
        private Vector2 direction;

        private bool initialized = false;


        public override void PerformAction(AIEnemy enemyAI)
        {
            if (aiBoard.CheckBoard(AIDataType.Arrived))
                initialized = false;

            SetChargeDestination();

            ChargeAtThePlayer(enemyAI);

            if(aiBoard.CheckBoard(AIDataType.PathBlocked))
            {
                enemyAI.CallOnMovement(Vector2.zero);
                enemyAI.MovementVector = Vector2.zero;
                aiBoard.SetBoard(AIDataType.Waiting, true);
                aiBoard.SetBoard(AIDataType.Arrived, true);
            }
        }

        private void ChargeAtThePlayer(AIEnemy enemyAI)
        {
            enemyAI.CallOnMovement(direction.normalized);
            enemyAI.MovementVector = direction.normalized;
        }

        private void SetChargeDestination()
        {
            if (initialized)
                return;

            tempPosition = new Vector2(playerDetector.Player.position.x, agent.transform.position.y);
            direction = tempPosition - agent.transform.position;
            aiBoard.SetBoard(AIDataType.Arrived, false);
            initialized = true;
        }
    }
}