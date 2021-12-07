using UnityEngine;

namespace Script.CommandPattern
{
    public class MoveCommand : Command
    {
        private PlayerMove _player;
        private Vector2 _direction;
        
        public MoveCommand(PlayerMove player, Vector2 direction)
        {
            _player = player;
            _direction = direction;
        }
        
        
        public override void Execute()
        {
            _player.Move(_direction);
        }
    }
}