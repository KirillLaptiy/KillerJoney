using __Objects.Interfaces;
using Core;
using UnityEngine;

namespace __Characters.Players._Scripts.CollectZone
{
    public class PlayerCollectZone : MonoBehaviour
    {
        private GameObject _player;

        private void Awake()
        {
            _player = GetComponentInParent<Player>().gameObject;
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (!other.CompareTag(Tags.Collectable)) return;
            other.GetComponent<ICollectable>().Collect(_player);
        }
    }
}