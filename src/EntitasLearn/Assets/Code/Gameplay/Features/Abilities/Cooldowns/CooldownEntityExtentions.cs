namespace Assets.Code.Gameplay.Features.Abilities.Cooldowns
{

    internal static class CooldownEntityExtentions
    {
        public static GameEntity PutOnCooldown(this GameEntity entity)
        {
            if (!entity.hasCooldown) return entity;

            entity.isCooldownIsUp = false;
            entity.ReplaceCooldownLeft(entity.Cooldown);

            return entity;
        }

        public static GameEntity PutOnCooldown(this GameEntity entity, float cooldown)
        {
            entity.isCooldownIsUp = false;
            entity.ReplaceCooldown(cooldown);
            entity.ReplaceCooldownLeft(cooldown);

            return entity;
        }
    }

}