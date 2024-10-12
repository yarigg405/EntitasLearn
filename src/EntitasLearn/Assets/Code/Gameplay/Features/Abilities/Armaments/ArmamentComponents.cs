using Entitas;


namespace Assets.Code.Gameplay.Features.Abilities.Armaments
{
    public sealed class ArmamentComponents
    {
        [Game] public class Armament : IComponent { }
        [Game] public class TargetLimit : IComponent { public int Value; }
        [Game] public class Processed : IComponent { }
    }
}
