using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Atooi.AI
{
    public class AIDataBoard : MonoBehaviour
    {
        public List<AIDataType> dataTypes;

        Dictionary<AIDataType, bool> aiBoard = new Dictionary<AIDataType, bool>();


        private void Start()
        {
            HashSet<AIDataType> noDuplicates = new HashSet<AIDataType>(dataTypes);
            foreach (var item in noDuplicates)
            {
                aiBoard.Add(item, false);
            }
        }

        public bool CheckBoard(AIDataType aiDataType)
        {
            if (CheckParameter(aiDataType) == false)
                throw new System.Exception("No" + aiDataType.ToString() + "in the AI Board for" + gameObject.name);
            return aiBoard[aiDataType];
        }

        public void SetBoard(AIDataType aiDataType, bool val)
        {
            if(CheckParameter(aiDataType) == false)
                throw new System.Exception("No" + aiDataType.ToString() + "in the AI Board for" + gameObject.name);
            aiBoard[aiDataType] = val;
        }

        private bool CheckParameter(AIDataType aiDataType)
        {
            return aiBoard.ContainsKey(aiDataType);
        }
    }

    public enum AIDataType
    {
        Waiting,
        PlayerDetected,
        Arrived,
        InMeleeRange,
        PathBlocked
    }
}