using Assets.Code.Infrastructure.View.Registrar;
using UnityEngine;


internal sealed class RigidbodyRegistrar : EntityComponentRegistrar
{
    [SerializeField] private Rigidbody body;

    public override void RegisterComponents()
    {
        Entity.AddRigidbody(body);
    }

    public override void UnregisterComponents()
    {
        Entity.RemoveRigidbody();
    }
}