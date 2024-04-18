using UnityEngine;
using Zenject;

namespace Picture
{
    public class PictureView : MonoBehaviour
    {
        [SerializeField] private GameObject[] Differences;
        
        public class Pool: MonoMemoryPool<PictureView>
        {
            
        }
    }
}