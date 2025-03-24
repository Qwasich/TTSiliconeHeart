using System.Collections.Generic;
using UnityEngine;

namespace TTSH.Core
{
    [CreateAssetMenu]
    public class BuildingList : ScriptableObject
    {
        /// <summary>
        /// ����� �������� ��� ������, ������� ����� ��������
        /// </summary>
        public List<GameObject> m_BuildingList;
    }
}

