using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Scripts
{
    public class ListUrl : MonoBehaviour
    {
        public int _id;

        private List<string> _urlList = new List<string>();

        private string _url = "http://data.ikppbb.com/test-task-unity-data/pics/";
        private bool _search = true;

        public event Action<int> CreatesIcon;

        private void Start()
        {
            StartCoroutine(SetUrlList());
        }

        private IEnumerator SetUrlList()
        {
            while (_search)
            {
                _url += _id + ".jpg";
                UnityWebRequest unityWebRequest = UnityWebRequestTexture.GetTexture(_url);
                yield return unityWebRequest.SendWebRequest();
                if (unityWebRequest.isDone == false)
                {
                    Debug.Log(unityWebRequest.error);
                    _search = false;
                    CreatesIcon?.Invoke(_id--);
                }
                else
                {
                    _id++;
                }
            }
        }
    }
}