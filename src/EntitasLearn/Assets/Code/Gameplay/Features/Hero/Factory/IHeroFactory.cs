using UnityEngine;

namespace Assets.Code.Gameplay.Features.Hero.Factory
{
    internal interface IHeroFactory
    {
        GameEntity CreateHero(Vector3 spawnPos);
    }
}