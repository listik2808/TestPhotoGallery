using UnityEngine;
using UnityEngine.UI;

namespace Scripts
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private Image _image;

        private int _id =0;

        public int ID => _id;

        public void SetId( int id)
        {
            _id = id;
        }

        public Image GetImage()
        {
            return _image;
        }
    }
}