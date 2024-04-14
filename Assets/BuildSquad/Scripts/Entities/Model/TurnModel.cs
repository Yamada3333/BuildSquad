namespace BuildSquad.Scripts.Entities.Model
{
    public class TurnModel
    {
        private int Turn { get; set; } = 1;

        public void NextTurn()
        {
            Turn++;
        }
        
        public void ClearTurn()
        {
            Turn = 1;
        }
    }
}
