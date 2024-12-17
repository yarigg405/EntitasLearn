//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherAxisInput;

    public static Entitas.IMatcher<InputEntity> AxisInput {
        get {
            if (_matcherAxisInput == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.AxisInput);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherAxisInput = matcher;
            }

            return _matcherAxisInput;
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
public partial class InputEntity {

    public Assets.Code.Gameplay.Input.AxisInput axisInput { get { return (Assets.Code.Gameplay.Input.AxisInput)GetComponent(InputComponentsLookup.AxisInput); } }
    public UnityEngine.Vector2 AxisInput { get { return axisInput.Value; } }
    public bool hasAxisInput { get { return HasComponent(InputComponentsLookup.AxisInput); } }

    public InputEntity AddAxisInput(UnityEngine.Vector2 newValue) {
        var index = InputComponentsLookup.AxisInput;
        var component = (Assets.Code.Gameplay.Input.AxisInput)CreateComponent(index, typeof(Assets.Code.Gameplay.Input.AxisInput));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public InputEntity ReplaceAxisInput(UnityEngine.Vector2 newValue) {
        var index = InputComponentsLookup.AxisInput;
        var component = (Assets.Code.Gameplay.Input.AxisInput)CreateComponent(index, typeof(Assets.Code.Gameplay.Input.AxisInput));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public InputEntity RemoveAxisInput() {
        RemoveComponent(InputComponentsLookup.AxisInput);
        return this;
    }
}