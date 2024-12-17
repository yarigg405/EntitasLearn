using Entitas;
using UnityEngine;


namespace Assets.Code.Gameplay.Input
{
    [Input] public class Input : IComponent { }
    [Input] public class AxisInput : IComponent { public Vector2 Value; }
}
