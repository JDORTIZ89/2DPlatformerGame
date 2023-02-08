using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Atooi.AI
{
    public abstract class AIBehaviour : MonoBehaviour
    {
        public abstract void PerformAction(AIEnemy enemyAI);
        
    }
}