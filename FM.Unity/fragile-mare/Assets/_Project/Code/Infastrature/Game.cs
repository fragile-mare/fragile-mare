namespace _Project.Code.Infastrature
{
    public class Game
    {
        public readonly GameStateMachine StateMachine;

        public Game()
        {
            StateMachine = new GameStateMachine();
        }
    }
}