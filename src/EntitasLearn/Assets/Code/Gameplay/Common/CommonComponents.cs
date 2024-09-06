using Entitas;
using UnityEngine;


namespace EntitasLearn.Gameplay.Common
{
    [Game] public class Id : IComponent { public int Value; }
    [Game] public class WorldPosition : IComponent { public Vector3 Value; }
    [Game] public class TransformComponent : IComponent { public Transform Value; }
}