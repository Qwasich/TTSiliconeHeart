using System;
using UnityEngine;

namespace TTSH.SaveSystem
{
    /// <summary>
    /// Данные, которые будем сохранять
    /// </summary>
    [Serializable]
    public struct BuildingSaveData
    {
        public int m_Id;
        public float x;
        public float y;
    }

    /// <summary>
    /// Интерфейс, реализуемый зданиями, которые необходимо сохранить
    /// </summary>
    public interface ISaveableBuilding
    {
        public BuildingSaveData Save();
    }
}