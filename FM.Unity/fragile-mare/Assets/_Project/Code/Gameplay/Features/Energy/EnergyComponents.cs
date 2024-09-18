using Entitas;

namespace _Project.Code.Gameplay.Features.Energy
{
   [Game] public class MaxEnergy : IComponent {public float Value; }
   [Game] public class CurrentEnergy : IComponent {public float Value; }
   [Game] public class EnergyRegenTimer : IComponent {public float Value; }
   [Game] public class EnergyType : IComponent { } //True - светлая, False - темная
   [Game] public class EnergyToApply : IComponent {public float Value; }
   [Game] public class EnergyToRegen : IComponent {public float Value; }
   
   
}