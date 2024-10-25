using Assets.Code.Gameplay.Features.Effects;
using Assets.Code.Gameplay.Features.Statuses;
using Entitas;
using System.Collections.Generic;


namespace Assets.Code.Gameplay.Features.Abilities.Armaments
{
    public sealed class ArmamentComponents
    {
        [Game] public class Armament : IComponent { }
        [Game] public class TargetLimit : IComponent { public int Value; }
        [Game] public class EffectSetups : IComponent { public List<EffectSetup> Value; }
        [Game] public class StatusSetups : IComponent { public List<StatusSetup> Value; }
        [Game] public class Processed : IComponent { }
    }
}
