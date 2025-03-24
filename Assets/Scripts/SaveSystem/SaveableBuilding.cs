using UnityEngine;

namespace TTSH.SaveSystem
{
    public class SaveableBuilding : MonoBehaviour, ISaveableBuilding
    {
        [SerializeField] private int m_BuildingID;
        public int BuildingID => m_BuildingID;

        /// <summary>
        /// ������, ������� ����� ��������� - �� (�������� ������), ������� � � �
        /// </summary>
        /// <returns>���������� ������</returns>
        public BuildingSaveData Save()
        {
            BuildingSaveData sd = new()
            {
                m_Id = m_BuildingID,
                x = transform.position.x,
                y = transform.position.y
            };
            return sd;
        }
    }
}
