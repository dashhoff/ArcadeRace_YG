
namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // Тестовые сохранения для демо сцены
        // Можно удалить этот код, но тогда удалите и демо (папка Example)
        //public int money = 1;                       // Можно задать полям значения по умолчанию
        //public string newPlayerName = "Hello!";
        //public bool[] openLevels = new bool[3];

        // Ваши сохранения

        // ...

        public int Money = 1000;

        public int[] OpenTracks = {1, 0, 0 ,0 ,0};
        public int[] OpenCars = {1, 0, 0 ,0 ,0};
        
        public float GeneralVolume = 1;
        public float EnviromentVolume = 1;
        public float CarVolume = 1;
        public float UIVolume = 1;
        public float MusicVolume = 1;
        
        public int GraphicsPreset = 3;

        // Поля (сохранения) можно удалять и создавать новые. При обновлении игры сохранения ломаться не должны
        
        // Вы можете выполнить какие то действия при загрузке сохранений
        public SavesYG()
        {
            // Допустим, задать значения по умолчанию для отдельных элементов массива

            //openLevels[1] = true;
        }
    }
}
