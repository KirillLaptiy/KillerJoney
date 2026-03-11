using Unity.Cinemachine;
using UnityEngine;

namespace __Characters.Players._Scripts
{
    public class PlayerVision : MonoBehaviour
    {
        [SerializeField] private float cameraSize = 4f;
        
        private CinemachineCamera _camera;

        private void Awake()
        {
            _camera = FindFirstObjectByType<CinemachineCamera>();
            _camera.Follow = transform;
            UpdateVisionPpU();
        }

        public void SetVisionPpU(float value)
        {
            cameraSize = value;
            UpdateVisionPpU();
        }

        private void UpdateVisionPpU()
        {
            _camera.Lens.OrthographicSize = cameraSize;
        }
    }
}
