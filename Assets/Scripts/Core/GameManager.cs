using __Objects.Exp;
using Mirror;
using UnityEngine;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject expPrefab;
    
        public static GameManager Instance { get; private set; }
        public bool IsServer { get; private set; }
        public bool SkipMainMenu { get; private set; }
    
        private void Awake()
        {
            Instance = this;
            IsServer = false;
            SkipMainMenu = true;
        }

        private void Start()
        {
            NetworkManager.singleton.StartHost();
            FindFirstObjectByType<Camera>().gameObject.SetActive(false);
        }

        public void SpawnExp(Vector2 pos, double expAmount)
        {
            var expSphere = Instantiate(expPrefab, pos, Quaternion.identity);
            expSphere.GetComponent<ExpSphere>().SetExpAmount(expAmount);
        }
    }
}
