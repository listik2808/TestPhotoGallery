using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using static System.Net.WebRequestMethods;

namespace Scripts
{
    public class LoadingIcons : MonoBehaviour
    {
        public int _id;
        public List<string> _listUrl = new List<string>();
        public Image _image;

        private string _url = "http://data.ikppbb.com/test-task-unity-data/pics/";
        private bool _isLoading = true;

        private IEnumerator Start()
        {
            while (_isLoading)
            {
                _url += _id + ".jpg";
                UnityWebRequest unityWebRequest = UnityWebRequestTexture.GetTexture(_url);
                yield return unityWebRequest.SendWebRequest();
                if (unityWebRequest.isDone == false)
                {
                    Debug.Log(unityWebRequest.error);
                    _isLoading = false;
                }
                else
                {
                    Texture texture = ((DownloadHandlerTexture)unityWebRequest.downloadHandler).texture;
                    _image.sprite = Sprite.Create((Texture2D)texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                }
                _id++;
            }
        }
    }
}