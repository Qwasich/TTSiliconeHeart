using UnityEngine;

namespace TTSH.SaveSystem
{
    public class SaveableBuilding : MonoBehaviour, ISaveableBuilding
    {
        [SerializeField] private int m_BuildingID;
        public int BuildingID => m_BuildingID;

        /// <summary>
        /// Данные, которые будем сохранять - ИД (согласно списку), позицию х и у
        /// </summary>
        /// <returns>Возвращает данные</returns>
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
