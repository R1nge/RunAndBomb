using Players;

namespace Services
{
    public class PlayerReferenceHolder
    {
        private Player _player;

        public void SetPlayer(Player player) => _player = player;
        
        public Player Player => _player;
    }
}