using System.Collections.Generic;
using UnityEngine;

namespace TTSH.Core
{
    [CreateAssetMenu]
    public class BuildingList : ScriptableObject
    {
        /// <summary>
        /// Здесь хранятся все здания, которые будем вызывать
        /// </summary>
        public List<GameObject> m_BuildingList;
    }
}

