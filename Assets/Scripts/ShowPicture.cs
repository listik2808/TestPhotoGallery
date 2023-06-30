using Scripts.StaticData;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class ShowPicture : MonoBehaviour
    {
        [SerializeField] private LoadingIcons _loadingIcons;
        [SerializeField] private Item _item;

        private List<Item> _items = new List<Item>();

        private void Start()
        {
            _item.SetId(Data.ID);
            _items.Add(_item);
            StartCoroutine(_loadingIcons.SetIconUrl(_items));
        }
    }
}