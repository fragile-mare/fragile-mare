using System;
using System.Linq;
using System.Text;
using _Project.Code.Common.Extensions;
using _Project.Code.Gameplay.Features.Ability;
using _Project.Code.Gameplay.Features.Character;
using _Project.Code.Gameplay.Features.Status;
using Code.Common.Entity.ToStrings;
using Entitas;
using UnityEngine;

// ReSharper disable once CheckNamespace
public sealed partial class GameEntity : INamedEntity
{
    private EntityPrinter _printer;

    public string EntityName(IComponent[] components)
    {
        try
        {
            if (components.Length == 1)
                return components[0].GetType().Name;

            foreach (IComponent component in components)
            {
                switch (component.GetType().Name)
                {
                    case nameof(Character):
                        return PrintCharacter();
                    case nameof(AbilityComponents.Ability):
                        return PrintAbility();
                    case nameof(Status):
                        return PrintStatus();
                }
            }
        }
        catch (Exception exception)
        {
            Debug.LogError(exception.Message);
        }

        return components.First().GetType().Name;
    }

    public string BaseToString() => base.ToString();

    public override string ToString()
    {
        if (_printer == null)
            _printer = new EntityPrinter(this);

        _printer.InvalidateCache();

        return _printer.BuildToString();
    }

    private string PrintCharacter()
    {
        return new StringBuilder($"Character ")
            .With(s => s.Append($"Id:{Id}"), when: hasId)
            .ToString();
    }

    private string PrintAbility()
    {
        return new StringBuilder($"Ability ")
            .With(s => s.Append("Ready "), when: isReady)
            .With(s => s.Append($"CD:{CooldownTimer} "), when: hasCooldownTimer && !isReady)
            .With(s => s.Append($"Id:{Id}"), when: hasId)
            .ToString();
    }

    private string PrintStatus()
    {
        return new StringBuilder($"Status ")
            .With(s => s.Append($"Id:{Id}"), when: hasId)
            .ToString();
    }
}