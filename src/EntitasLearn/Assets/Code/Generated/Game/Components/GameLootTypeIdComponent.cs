//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherLootTypeId;

    public static Entitas.IMatcher<GameEntity> LootTypeId {
        get {
            if (_matcherLootTypeId == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LootTypeId);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLootTypeId = matcher;
            }

            return _matcherLootTypeId;
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

    public Assets.Code.Gameplay.Features.Loot.LootTypeIdComponent lootTypeId { get { return (Assets.Code.Gameplay.Features.Loot.LootTypeIdComponent)GetComponent(GameComponentsLookup.LootTypeId); } }
    public Assets.Code.Gameplay.Features.Loot.LootTypeId LootTypeId { get { return lootTypeId.Value; } }
    public bool hasLootTypeId { get { return HasComponent(GameComponentsLookup.LootTypeId); } }

    public GameEntity AddLootTypeId(Assets.Code.Gameplay.Features.Loot.LootTypeId newValue) {
        var index = GameComponentsLookup.LootTypeId;
        var component = (Assets.Code.Gameplay.Features.Loot.LootTypeIdComponent)CreateComponent(index, typeof(Assets.Code.Gameplay.Features.Loot.LootTypeIdComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceLootTypeId(Assets.Code.Gameplay.Features.Loot.LootTypeId newValue) {
        var index = GameComponentsLookup.LootTypeId;
        var component = (Assets.Code.Gameplay.Features.Loot.LootTypeIdComponent)CreateComponent(index, typeof(Assets.Code.Gameplay.Features.Loot.LootTypeIdComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveLootTypeId() {
        RemoveComponent(GameComponentsLookup.LootTypeId);
        return this;
    }
}