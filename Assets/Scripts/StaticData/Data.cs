using System;

namespace Scripts.StaticData
{
    [Serializable]
    public static class Data
    {
        private static int _loadingScene = 0;
        private static int _level = 1;
        private static int _id;

        public static int Level => _level;
        public static int LoadingScene => _loadingScene;
        public static int ID => _id;

        public static void SetLevel(int level)
        {
            _level = level;
        }

        public static void SetID(int id)
        {
            _id = id;
        }
    }
}