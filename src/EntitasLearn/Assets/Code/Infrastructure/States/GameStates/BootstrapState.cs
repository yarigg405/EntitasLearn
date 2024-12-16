using Code.Gameplay.StaticData;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;

namespace Code.Infrastructure.States.GameStates
{
  public class BootstrapState : SimpleState
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly StaticDataService _staticDataService;

    public BootstrapState(IGameStateMachine stateMachine, StaticDataService staticDataService)
    {
      _stateMachine = stateMachine;
      _staticDataService = staticDataService;
    }
    
    public override void Enter()
    {
      _staticDataService.LoadAll();
      
    //  _stateMachine.Enter<LoadProgressState>();
    }
  }
}