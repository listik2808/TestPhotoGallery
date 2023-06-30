using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Scripts
{
    public class LoadingIcons : MonoBehaviour
    {
        private const string _url = "http://data.ikppbb.com/test-task-unity-data/pics/";
        private Image _image;

        [Obsolete]
        public IEnumerator SetIconUrl(List<Item> items)
        {
            foreach (var item in items)
            {
                string _urlImage = _url + item.ID + ".jpg";
                UnityWebRequest unityWebRequest = UnityWebRequestTexture.GetTexture(_urlImage);
                yield return unityWebRequest.SendWebRequest();
                if (unityWebRequest.isNetworkError || unityWebRequest.isHttpError)
                {
                    Debug.Log(unityWebRequest.error);
                }
                else
                {
                    _image = item.GetImage();
                    DownloadHandlerTexture downloadHandlerTexture = GetTexture(unityWebRequest);
                    Texture texture = downloadHandlerTexture.texture;
                    _image.sprite = Sprite.Create((Texture2D)texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                }
            }
        }

        private DownloadHandlerTexture GetTexture(UnityWebRequest unityWebRequest)
        {
            return unityWebRequest.downloadHandler as DownloadHandlerTexture;
        }
    }
}