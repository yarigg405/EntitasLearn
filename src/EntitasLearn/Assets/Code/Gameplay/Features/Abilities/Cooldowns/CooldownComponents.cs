using Entitas;


namespace Assets.Code.Gameplay.Features.Abilities.Cooldowns
{
    public sealed class CooldownComponents
    {
        [Game] public class Cooldown : IComponent { public float Value; }
        [Game] public class CooldownLeft : IComponent { public float Value; }
        [Game] public class CooldownIsUp : IComponent { }
    }
}
