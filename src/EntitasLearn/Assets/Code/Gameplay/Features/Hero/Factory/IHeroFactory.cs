using UnityEngine;

namespace Assets.Code.Gameplay.Features.Hero.Factory
{
    public interface IHeroFactory
    {
        GameEntity CreateHero(Vector3 spawnPos);
    }
}