using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Atooi.Levels
{
    public interface ISaveData
    {
        void SaveData();
        void LoadData();
    }
}