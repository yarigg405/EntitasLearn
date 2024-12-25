using Code.Infrastructure.States.StateInfrastructure;
using RSG;


namespace Assets.Code.Infrastructure.States.GameStates
{
    public class EndOfFrameExitState : IState, IUpdateable
    {
        private Promise _exitPromise;


        IPromise IExitableState.BeginExit()
        {
            _exitPromise = new Promise();
            return _exitPromise;
        }

        void IExitableState.EndExit()
        {
            ExitOnEndFrame();
            _exitPromise = null;
        }

        protected virtual void ExitOnEndFrame()
        {

        }

        public virtual void Enter()
        {


        }

        void IUpdateable.Update()
        {
            if (_exitPromise == null)
                OnUpdate();

            if (_exitPromise != null)
                ResolveExitPromise();
        }

        protected virtual void OnUpdate() { }

        private void ResolveExitPromise()
        {
            _exitPromise?.Resolve();
        }
    }
}
