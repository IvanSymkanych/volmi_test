using UnityEngine;

namespace Core.GlobalServices.SaveLoadService
{
    public class SaveLoadService : ISaveLoadService
    {
        public GameSaveModel GameSaveModel { get; private set; }

        private const string SavePrefsKey = "GameSave";
        
        public SaveLoadService() => Load();

        public void Save() => PlayerPrefs.SetString(SavePrefsKey, JsonUtility.ToJson(GameSaveModel));

        private void Load()
        {
           var loadModel = JsonUtility.FromJson<GameSaveModel>(PlayerPrefs.GetString(SavePrefsKey));
           
           if (loadModel == null)
           {
               GameSaveModel = new GameSaveModel();
               Save();
               return;
           }
           
           GameSaveModel = loadModel;
        }
    }
}