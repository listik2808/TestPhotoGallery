using UnityEngine;

namespace Scripts
{
    public class Spawn : MonoBehaviour
    {
        [SerializeField] private LoadingIcons _loadingIcons;
        [SerializeField]private ConteinerIcons _conteinerIcons;
        [SerializeField] private Item _item;
        [SerializeField] private Transform _container;

        public void IconSpawn()
        {
            Item item = Instantiate(_item, _container);
            _conteinerIcons.AddItem(item);
        }
    }
}