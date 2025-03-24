using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace TTSH.SaveSystem
{
    public class SaveSystem : MonoBehaviour
    {
        private Savefile m_CurrentSave;
        public Savefile CurrentSave => m_CurrentSave;

        private void Awake()
        {
            LoadSavefile();
            if (m_CurrentSave == null) CreateNewSave();
        }

        private void Start()
        {
            if (m_CurrentSave.m_BuildingSavedata != null) Singleton_SaveLoad.Instance.LoadAll(m_CurrentSave);
        }

        /// <summary>
        /// Зпаись потока на диск
        /// </summary>
        /// <param name="sf">Файл сохранения</param>
        public void WriteSavefile(Savefile sf)
        {
            BinaryFormatter bf = new BinaryFormatter();
            if (!Directory.Exists(Application.persistentDataPath + "/Saves")) Directory.CreateDirectory(Application.persistentDataPath + "/Saves");
            FileStream file = File.Create(Application.persistentDataPath + "/Saves/SAV.E");
            bf.Serialize(file, sf);
            file.Close();
            m_CurrentSave = sf;
        }

        /// <summary>
        /// Чтения потока с диска
        /// </summary>
        public void LoadSavefile()
        {
            if (File.Exists(Application.persistentDataPath + "/Saves/SAV.E"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/Saves/SAV.E", FileMode.Open);
                m_CurrentSave = (Savefile)bf.Deserialize(file);
                file.Close();
            }
        }

        private void CreateNewSave()
        {
            m_CurrentSave = new Savefile
            {
                m_BuildingSavedata = new List<BuildingSaveData>()
            };
            m_CurrentSave.m_BuildingSavedata.Clear();
        }
    }
}
