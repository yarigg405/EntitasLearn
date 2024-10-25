using System;


namespace Assets.Code.Gameplay.Features.Statuses
{
    [Serializable]
    public struct StatusSetup
    {
        public StatusTypeId StatusTypeId;
        public float Value;
        public float Duration;
        public float Period;
    }
}
