using System.Collections.Generic;
using UnityEngine;
using TTSH.Core;

namespace TTSH.Building
{
    public class UIBuildingSelector : MonoBehaviour
    {
        [SerializeField] private BuildingList m_List;

        private GameObject m_ChosenBuilding;
        public GameObject ChosenBuilding => m_ChosenBuilding;


        /// <summary>
        /// Выбираем здание через ИД, в порядковом номере листа
        /// </summary>
        /// <param name="i">Порядковый номер</param>
        public void ChoseBuilding(int i)
        {
            if (i + 1 > m_List.m_BuildingList.Count)
            {
                Debug.Log("Index was outside of lists' bounds");
                return;
            }
            if (m_List.m_BuildingList[i]) m_ChosenBuilding = m_List.m_BuildingList[i];

        }
    }
}
