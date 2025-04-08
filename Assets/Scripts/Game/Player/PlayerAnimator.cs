using UnityEngine;

namespace Game.Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimator : MonoBehaviour
    {
        private static readonly int IdleHash = Animator.StringToHash("Idle");
        private static readonly int GameOverHash = Animator.StringToHash("GameOver");
        private static readonly int RunHash = Animator.StringToHash("Run");
        
        private Animator _animator;
        
        public void Initialize() => _animator = GetComponent<Animator>();

        public void PlayIdleAnimation() => _animator.SetTrigger(IdleHash);
        
        public void PlayRunAnimation() => _animator.SetTrigger(RunHash);
        
        public void PlayGameOverAnimation() => _animator.SetTrigger(GameOverHash);

    }
}