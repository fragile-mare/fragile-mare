using System;
using System.Linq;
using System.Text;
using _Project.Code.Common.Extensions;
using _Project.Code.Gameplay.Features.Character;
using Code.Common.Entity.ToStrings;
using Entitas;
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
        switch (component.GetType().Name)
        {
          case nameof(Character):
            return PrintCharacter();
        }
      }
    }
    catch (Exception exception)
    {
      Debug.LogError(exception.Message);
    }

    return components.First().GetType().Name;
  }

  private string PrintCharacter()
  {
    return new StringBuilder($"Character ")
      .With(s => s.Append($"Id:{Id}"), when: hasId)
      .ToString();
  }

  public string BaseToString() => base.ToString();
}
