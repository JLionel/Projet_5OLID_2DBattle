using UnityEngine;

namespace Script.CommandPattern
{
    [CreateAssetMenu (menuName = "GameCommand/PlayerCommand/Move")]
    public class MovePlayerCommand : PlayerCommand
    {
        public DirectionMove Direction;
        
        [SerializeField] private PlayerNames playerNames;
        [SerializeField] private PlayerGO playerGO;
        
        public override void Execute(string playerName)
        {
            if(playerNames.Contains(playerName))
            {
                PlayerMove player = CatchPlayer(playerName);
                if(player)
                    player.MoveInDirection(VectorDirectionMove.FetchDirection(Direction));
            }
        }

        private PlayerMove CatchPlayer(string playerName)
        {
            int index = playerNames.GetPlayerIndex(playerName);
            GameObject playerObject = playerGO.GameObjects[index];
            return playerObject?.GetComponent<PlayerMove>();
        }
    }
}