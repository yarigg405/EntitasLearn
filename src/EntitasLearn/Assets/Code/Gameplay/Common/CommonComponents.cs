using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;


namespace EntitasLearn.Gameplay.Common
{
    [Game] public class Id : IComponent { [PrimaryEntityIndex] public int Value; }
    [Game] public class WorldPosition : IComponent { public Vector3 Value; }
    [Game] public class TransformComponent : IComponent { public Transform Value; }
    [Game] public class Damage : IComponent { public float Value; }
}