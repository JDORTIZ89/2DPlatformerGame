using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Atooi.AI
{
    public class AIBehaviourBossIdle : AIBehaviour
    {
        public override void PerformAction(AIEnemy enemyAI)
        {
            enemyAI.MovementVector = Vector2.zero;

            enemyAI.CallOnMovement(Vector2.zero);
        }
    }
}