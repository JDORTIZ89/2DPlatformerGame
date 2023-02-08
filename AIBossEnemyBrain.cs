using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Atooi.AI
{
    public class AIBossEnemyBrain : AIEnemy
    {
        [SerializeField]
        private AIDataBoard aiBoard;
        [SerializeField]
        private AIPlayerEnterAreaDetector playerDetector;
        [SerializeField]
        private AIMeleeAttackDetector meleeRangeDetector;
        [SerializeField]
        private AIEndPlatformDetector endPlatformDetector;

        [SerializeField]
        private AIBehaviour IdleBehaviour, ChargeBehaviour, MeleeAttackBehaviour, WaitBehaviour;



        private void Update()
        {
            aiBoard.SetBoard(AIDataType.PlayerDetected, playerDetector.PlayerInArea);
            aiBoard.SetBoard(AIDataType.InMeleeRange, meleeRangeDetector.PlayerDetected);
            aiBoard.SetBoard(AIDataType.PathBlocked, endPlatformDetector.PathBlocked);



            if(aiBoard.CheckBoard(AIDataType.PlayerDetected))
            {
                if(aiBoard.CheckBoard(AIDataType.Waiting))
                {
                    WaitBehaviour.PerformAction(this);
                }
                else
                {
                    if(aiBoard.CheckBoard(AIDataType.InMeleeRange))
                    {
                        MeleeAttackBehaviour.PerformAction(this);
                    }
                    else
                    {
                        ChargeBehaviour.PerformAction(this);
                    }
                }
            }
            else
            {
                IdleBehaviour.PerformAction(this);
            }
        }
    }
}