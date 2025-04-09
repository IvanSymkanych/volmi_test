using System;
using Core.GlobalServices.ConfigService;
using Game.Collectable;
using Game.Obstacle;
using UnityEngine;
using VContainer;

namespace Game.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        public event Action OnGameOver;
        
        [SerializeField] private PlayerAnimator playerAnimator;
        
        [Inject] private GameConfigsSO _gameConfigs;

        private CharacterController _characterController;
        private IPlayerInput _playerInput;

        private int _laneIndex = 1;
        private bool _canMove;
        
        public void Initialize()
        {
            _characterController = GetComponent<CharacterController>();
            _playerInput = new PlayerInput();
            _playerInput.Initialize();
            playerAnimator.Initialize();
            _playerInput.OnMoveLeft += MoveLeft;
            _playerInput.OnMoveRight += MoveRight;
        }

        public void Dispose()
        {
            _playerInput.Dispose();
            _playerInput.OnMoveLeft -= MoveLeft;
            _playerInput.OnMoveRight -= MoveRight;
        }
        
        public void StartGame()
        {
            _canMove = true;
            playerAnimator.PlayRunAnimation();
        }
        
        private void Update()
        {
            if(!_canMove)
                return;
            
            var targetX = (_laneIndex - 1) * 2f;
            var currentPos = transform.position;
            var newX = Mathf.MoveTowards(currentPos.x, targetX, _gameConfigs.laneSwitchSpeed * Time.deltaTime);
            var move = new Vector3(newX - currentPos.x, -9.81f * Time.deltaTime, _gameConfigs.forwardSpeed * Time.deltaTime);
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
            playerAnimator.PlayGameOverAnimation();
            OnGameOver?.Invoke();
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