using System;

namespace Game.Player
{
    public interface IPlayerInput
    {
        event Action OnMoveLeft;
        event Action OnMoveRight;
        void Initialize();
        void Dispose();
    }
}