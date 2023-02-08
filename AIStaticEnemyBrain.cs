using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Atooi.AI
{
    public class AIStaticEnemyBrain : AIEnemy
    {
        public AIBehaviour AttackBehavior;



        private void Update()
        {
            AttackBehavior.PerformAction(this);
        }
    }
}