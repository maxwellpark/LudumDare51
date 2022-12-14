using UnityEngine;

namespace TarodevController {
    public class CameraFollow : MonoBehaviour {
        [SerializeField] private Transform _player;
        [SerializeField] private float _smoothTime = 0.5f;
        [SerializeField] private float _minX, _maxX;
        [SerializeField] private float _zDistance;

        private Vector3 _currentVel;

        private void Start() {
            if (_player == null) {
                var player = FindObjectOfType<PlayerController>();
                if (player != null) _player = player.transform;
            }

        }


        private void Update() {
            if (!_player) return;

            var target = new Vector3(Mathf.Clamp(_player.position.x, _minX, _maxX), _player.position.y, _zDistance);
            transform.position = Vector3.SmoothDamp(transform.position, target, ref _currentVel, _smoothTime);
        }
    }
}