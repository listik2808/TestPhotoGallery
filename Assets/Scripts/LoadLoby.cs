using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scripts
{
    public class LoadLoby : MonoBehaviour
    {
        [SerializeField] private Image _imageBar;
        [SerializeField] private TMP_Text _textBar;
        [SerializeField] private int _sceneID;

        private AsyncOperation _asyncOperation;

        private void OnEnable()
        {
            StartCoroutine(NextScene());
        }

        private IEnumerator NextScene()
        {
            yield return new WaitForSeconds(1f);
            _asyncOperation = SceneManager.LoadSceneAsync(_sceneID);
            while (!_asyncOperation.isDone)
            {
                float progress = _asyncOperation.progress / 0.9f;
                _imageBar.fillAmount = progress;
                _textBar.text = "LOADING " + string.Format("{0:0}%", progress * 100f);
                yield return 0;
            }
        }
    }
}