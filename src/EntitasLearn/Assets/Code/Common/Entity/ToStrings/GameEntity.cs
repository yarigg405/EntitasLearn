﻿using Code.Common.Entity.ToStrings;
using Code.Common.Extensions;
using Entitas;
using System;
using System.Linq;
using System.Text;
using UnityEngine;

// ReSharper disable once CheckNamespace
public sealed partial class GameEntity : INamedEntity
{
    private EntityPrinter _printer;

    public override string ToString()
    {
        if (_printer == null)
            _printer = new EntityPrinter(this);

        _printer.InvalidateCache();

        return _printer.BuildToString();
    }

    public string EntityName(IComponent[] components)
    {
        try
        {
            if (components.Length == 1)
                return components[0].GetType().Name;

            foreach (IComponent component in components)
            {

                Debug.LogError("Here need");

                return "Entity";

                //switch (component.GetType().Name)
                //{
                //  case nameof(Hero):
                //    return PrintHero();

                //  case nameof(Enemy):
                //    return PrintEnemy();
                //}
            }
        }
        catch (Exception exception)
        {
            Debug.LogError(exception.Message);
        }

        return components.First().GetType().Name;
    }

    private string PrintHero()
    {
        return new StringBuilder($"Hero ")
          .With(s => s.Append($"Id:{Id}"), when: hasId)
          .ToString();
    }

    private string PrintEnemy() =>
      new StringBuilder($"Enemy ")
        .With(s => s.Append($"Id:{Id}"), when: hasId)
        .ToString();

    public string BaseToString() => base.ToString();
}

