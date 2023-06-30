using Scripts.StaticData;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.TransitionBetweenScenes
{
    public class OpenLoadScreen : MonoBehaviour
    {
        private int _curentLevelIndex;
        private int _level = 1;
        private Item _item;

        private void Awake()
        {
            _curentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        }

        public void OpenBootScreen()
        {
            NextLevel(_level);
        }

        public void PreviousLevel()
        {
            NextLevel(-_level);
        }

        public void NextLevelImage()
        {
            _item = GetComponent<Item>();
            Data.SetID(_item.ID);
            NextLevel(_level);
        }

        private void NextLevel(int level)
        {
            SetLevel(level);
        }

        private void SetLevel(int level)
        {
            Data.SetLevel(_curentLevelIndex + level);
            SceneManager.LoadSceneAsync(Data.LoadingScene);
        }
    }
}