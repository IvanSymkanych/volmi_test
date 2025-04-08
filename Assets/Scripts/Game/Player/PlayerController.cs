using Core.GlobalServices.ConfigService;
using Game.Collectable;
using Game.Controllers;
using Game.Obstacle;
using UnityEngine;
using VContainer;

namespace Game.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float forwardSpeed = 10f;
        [SerializeField] private float laneSwitchSpeed = 10f;

        [Inject] private IGameController _gameController;
        
        private CharacterController _characterController;
        private IPlayerInput _playerInput;

        private int _laneIndex = 1;
        private bool _canMove;
        
        [Inject] private GameConfigsSO _gameConfigs;
        
        public void Initialize()
        {
            _characterController = GetComponent<CharacterController>();
            _playerInput = new PlayerInput();
            _playerInput.OnMoveLeft += MoveLeft;
            _playerInput.OnMoveRight += MoveRight;
            _playerInput.Initialize();
        }

        public void StartGame()
        {
            _canMove = true;
        }
        
        private void Update()
        {
            var targetX = (_laneIndex - 1) * 2f;
            var currentPos = transform.position;
            var newX = Mathf.MoveTowards(currentPos.x, targetX, laneSwitchSpeed * Time.deltaTime);
            var move = new Vector3(newX - currentPos.x, -9.81f * Time.deltaTime, forwardSpeed * Time.deltaTime);
            _characterController.Move(move);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent<ICollectable>(out var collectable))
                collectable.Pickup();
            
            if (other.TryGetComponent<IObstacle>(out var obstacle))
            {
                obstacle.Interact();
                ObstacleInteract();
            }
        }
        
        private void ObstacleInteract()
        {
            _canMove = false;
            _gameController.GameOver();
        }

        private void MoveLeft()
        {
            if (_laneIndex > 0) 
                _laneIndex--;
        }

        private void MoveRight()
        {
            if (_laneIndex < 2) 
                _laneIndex++;
        }
    }
}