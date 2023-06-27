using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scripts
{
    public class TransitionBetweenScenes : MonoBehaviour
    {
        private const string SceneGallery = "SceneGallery";

        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();
        }
        public void NextScene()
        {
            SceneManager.LoadScene(SceneGallery);
        }

    }
}