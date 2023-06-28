using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using static System.Net.WebRequestMethods;
using static UnityEditor.Progress;

namespace Scripts
{
    public class LoadingIcons : MonoBehaviour
    {
        [SerializeField] private int _id;
        [SerializeField] private ConteinerIcons _conteinerIcons;
        private Image _image;
        private string _url = "http://data.ikppbb.com/test-task-unity-data/pics/";

        private List<Item> _items = new List<Item>();

        public IEnumerator SetIconUrl(List<Item> items)
        {
            foreach (var item in items)
            {
                if(item.ID == _id)
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
                        yield return unityWebRequest.isDone;
                        DownloadHandlerTexture downloadHandlerTexture = GetTexture(unityWebRequest);
                        Texture texture = downloadHandlerTexture.texture;
                        _image.sprite = Sprite.Create((Texture2D)texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                    }
                    _id++;
                }
            }
        }

        private static DownloadHandlerTexture GetTexture(UnityWebRequest unityWebRequest)
        {
            return unityWebRequest.downloadHandler as DownloadHandlerTexture;
        }
    }
}