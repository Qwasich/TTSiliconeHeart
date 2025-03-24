using System.Linq;
using UnityEngine;
using TTSH.Core;
using System.Collections.Generic;

namespace TTSH.SaveSystem
{
    [RequireComponent(typeof(SaveSystem))]
    public class Singleton_SaveLoad : SingletonMono<Singleton_SaveLoad>
    {
        [SerializeField] private BuildingList m_Buildings;
        private SaveSystem m_Savesystem;

        protected override void Awake()
        {
            base.Awake();
            m_Savesystem = GetComponent<SaveSystem>();
        }

        /// <summary>
        /// Ищем и сохраняем все постройки на сцене. Да, можно было сделать какой-нибудь менеджер который хранит все постройки вместо опроса каждого объекта.
        /// </summary>
        public void SaveAll()
        {
            Savefile svf = new ()
            {
                m_BuildingSavedata = new List<BuildingSaveData>()
            };
            svf.m_BuildingSavedata.Clear();
            ISaveableBuilding[] isb = FindObjectsOfType<MonoBehaviour>().OfType<ISaveableBuilding>().ToArray();
            for (int i = 0; i < isb.Length; i++)
            {
                svf.m_BuildingSavedata.Add(isb[i].Save());
                
            }
            m_Savesystem.WriteSavefile(svf);
        }

        /// <summary>
        /// Выгрузка и установка каждой постройки
        /// </summary>
        /// <param name="svf">Файл, откуда берем данные</param>
        public void LoadAll(Savefile svf)
        {
            foreach (BuildingSaveData bsd in svf.m_BuildingSavedata)
            {
                Instantiate(m_Buildings.m_BuildingList[bsd.m_Id], new(bsd.x,bsd.y, 0),Quaternion.identity);
            }
        }

        

    }
}
