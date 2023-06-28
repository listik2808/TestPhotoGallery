using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenLoadScreen : MonoBehaviour
{
    [SerializeField] private int _id;
    public void OpenBootScreen()
    {
        SceneManager.LoadSceneAsync(_id);
    }
}
