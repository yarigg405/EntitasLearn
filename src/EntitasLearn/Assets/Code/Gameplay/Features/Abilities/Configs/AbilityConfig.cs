using UnityEngine;


namespace Assets.Code.Gameplay.Features.Abilities.Configs
{
    [CreateAssetMenu(fileName = "AbilityConfig", menuName = "ScriptableObjects/AbilityConfig")]
    internal sealed class AbilityConfig : ScriptableObject
    {
        [field: SerializeField] public AbilityId AbilityId { get; private set; }
        [field: SerializeField] public AbilityLevel[] AbilityLevels { get; private set; }
    }
}
