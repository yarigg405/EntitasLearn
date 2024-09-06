//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherDirection;

    public static Entitas.IMatcher<GameEntity> Direction {
        get {
            if (_matcherDirection == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Direction);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDirection = matcher;
            }

            return _matcherDirection;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Assets.Code.Gameplay.Common.Movement.Direction direction { get { return (Assets.Code.Gameplay.Common.Movement.Direction)GetComponent(GameComponentsLookup.Direction); } }
    public UnityEngine.Vector2 Direction { get { return direction.Value; } }
    public bool hasDirection { get { return HasComponent(GameComponentsLookup.Direction); } }

    public GameEntity AddDirection(UnityEngine.Vector2 newValue) {
        var index = GameComponentsLookup.Direction;
        var component = (Assets.Code.Gameplay.Common.Movement.Direction)CreateComponent(index, typeof(Assets.Code.Gameplay.Common.Movement.Direction));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceDirection(UnityEngine.Vector2 newValue) {
        var index = GameComponentsLookup.Direction;
        var component = (Assets.Code.Gameplay.Common.Movement.Direction)CreateComponent(index, typeof(Assets.Code.Gameplay.Common.Movement.Direction));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveDirection() {
        RemoveComponent(GameComponentsLookup.Direction);
        return this;
    }
}
