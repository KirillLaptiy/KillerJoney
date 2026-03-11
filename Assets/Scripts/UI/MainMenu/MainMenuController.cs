using Mirror;
using ParrelSync;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

namespace UI.MainMenu
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private GameObject hostButton;
        [SerializeField] private GameObject joinButton;

        private void Start()
        {
            if (IsServerEditor())
                joinButton.SetActive(false);
            else
                hostButton.SetActive(false);
        }

        public void Host()
        {
            if (IsServerEditor())
            {
                NetworkManager.singleton.StartServer();
                NetworkManager.singleton.ServerChangeScene(Scenes.TestScene);
                SceneManager.LoadScene(Scenes.MainMenu);
            }
            else
            {
                Join();
            }
        }

        public void Join()
        {
            NetworkManager.singleton.networkAddress = "127.0.0.1"; // второй клиент
            NetworkManager.singleton.StartClient();
        }

        public void Stop()
        {
            NetworkManager.singleton.StopHost();
        }

        private static bool IsServerEditor()
        {
            return ClonesManager.IsClone() && ClonesManager.GetArgument() == "server";
        }

        private void OnApplicationQuit()
        {
            if (NetworkServer.active)
            {
                NetworkManager.singleton.StopServer();
            }
            else
            {
                NetworkManager.singleton.StopClient();
            }
        }
    }
}