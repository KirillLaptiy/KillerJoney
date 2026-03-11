using Mirror;
using UnityEngine;

namespace Networking.SpawnManager
{
    public class NetworkSpawnManager : MonoBehaviour
    {
        [SerializeField] private GameObject slimePrefab;
    
    
        private void Start()
        {
            if (!NetworkServer.active) return;
        
            GameObject slime = Instantiate(slimePrefab, slimePrefab.transform.position, slimePrefab.transform.rotation).gameObject;
            NetworkServer.Spawn(slime);
        
            slime = Instantiate(slimePrefab, slimePrefab.transform.position, slimePrefab.transform.rotation).gameObject;
            NetworkServer.Spawn(slime);
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}
