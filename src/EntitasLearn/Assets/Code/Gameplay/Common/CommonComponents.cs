using Assets.Code.Gameplay.Common.Visual;
using Assets.Code.Gameplay.Common.Visual.StatusVisuals;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;


namespace EntitasLearn.Gameplay.Common
{
    [Game] public class Id : IComponent { [PrimaryEntityIndex] public int Value; }
    [Game] public class EntityLink : IComponent { [EntityIndex] public int Value; }
    [Game] public class WorldPosition : IComponent { public Vector3 Value; }
    [Game] public class TransformComponent : IComponent { public Transform Value; }
    [Game] public class Damage : IComponent { public float Value; }
    [Game] public class Active : IComponent { }
    [Game] public class RigidbodyComponent : IComponent { public Rigidbody Value; }
    [Game] public class DamageTakenAnimator : IComponent { public IDamageTakenAnimator Value; }
    [Game] public class StatusVisualsComponent : IComponent { public StatusVisuals Value; }
}