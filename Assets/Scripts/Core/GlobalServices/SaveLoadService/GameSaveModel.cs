

using System;
using System.Collections.Generic;

namespace Core.GlobalServices.SaveLoadService
{
    [Serializable]
    public class GameSaveModel
    {
        public List<int> scoreList = new List<int>();
    }
}