using System.Collections.Generic;
using UnityEngine;

namespace Scripts.InstantiateIcon
{
    public class ConteinerIcons : MonoBehaviour
    {
        [SerializeField] private List<Item> _items = new List<Item>();
        [SerializeField] private Spawn _spawn;
        [SerializeField] private LoadingIcons _loadingIcons;
        [SerializeField] private int _countSpawnIcon;

        private int id = 0;

        private void Awake()
        {
            while (id < _countSpawnIcon)
            {
                _spawn.IconSpawn();
            }

            StartCoroutine(_loadingIcons.SetIconUrl(_items));
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
            AssignNumber(item);
        }

        private void AssignNumber(Item item)
        {
            id++;
            item.SetId(id);
        }
    }
}