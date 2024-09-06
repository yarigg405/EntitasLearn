using Entitas;
using UnityEngine;


namespace Assets.Code.Gameplay.Input
{
    [Game] public class Input : IComponent { }
    [Game] public class AxisInput : IComponent { public Vector2 Value; }
}
