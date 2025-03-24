using System;
using UnityEngine;

namespace TTSH.SaveSystem
{
    /// <summary>
    /// ������, ������� ����� ���������
    /// </summary>
    [Serializable]
    public struct BuildingSaveData
    {
        public int m_Id;
        public float x;
        public float y;
    }

    /// <summary>
    /// ���������, ����������� ��������, ������� ���������� ���������
    /// </summary>
    public interface ISaveableBuilding
    {
        public BuildingSaveData Save();
    }
}