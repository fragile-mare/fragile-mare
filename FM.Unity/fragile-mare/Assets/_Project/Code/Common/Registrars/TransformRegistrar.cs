using _Project.Code.Infrastructure.View.Registrars;

namespace _Project.Code.Common.Registrars
{
    public class TransformRegistrar : EntityComponentRegistrar
    {
        public override void RegisterComponents()
        {
            Entity.AddTransform(transform);
        }

        public override void UnregisterComponents()
        {
            Entity.RemoveTransform();
        }
    }
}