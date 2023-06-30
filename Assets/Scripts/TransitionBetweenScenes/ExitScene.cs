using Scripts.StaticData;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.TransitionBetweenScenes
{
    public class ExitScene : MonoBehaviour
    {
        private int _curentLevel;

        private void Awake()
        {
            _curentLevel = SceneManager.GetActiveScene().buildIndex;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                int nextScene = _curentLevel - 1;
                if (nextScene == 0)
                {
                    Application.Quit();
                }
                else
                {
                    Data.SetLevel(nextScene);
                    SceneManager.LoadSceneAsync(0);
                }
            }
        }
    }
}