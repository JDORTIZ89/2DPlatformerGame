using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Atooi.Levels
{
    public class SaveSystemManager : MonoBehaviour
    {
        public void ResetSavedData()
        {
            SaveSystem.ResetSaveData();
        }
    }
}