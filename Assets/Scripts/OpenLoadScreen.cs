using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLoadScreen : MonoBehaviour
{
    [SerializeField] private GameObject _loadScreen;

    public void OpenBootScreen()
    {
        _loadScreen.SetActive(true);
    }
}
