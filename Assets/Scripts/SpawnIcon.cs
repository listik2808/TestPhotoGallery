using System;
using System.Collections;
using UnityEngine;

namespace Scripts
{
    public class SpawnIcon : MonoBehaviour
    {
        [SerializeField] private Transform _contaner;
        [SerializeField] private GameObject _icon;

        private ListUrl _listUrl;
        private int _id;

        public event Action InstallingIcons;

        private void OnEnable()
        {
            _listUrl.CreatesIcon += SetId;
        }

        private void OnDisable()
        {
            _listUrl.CreatesIcon -= SetId;
        }

        private void SetId(int id)
        {
            _id = id;
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while(_id > 0)
            {
                Instantiate(_icon, _contaner);
                _id--;
            }
            InstallingIcons?.Invoke();
            yield return null;
        }
    }
}