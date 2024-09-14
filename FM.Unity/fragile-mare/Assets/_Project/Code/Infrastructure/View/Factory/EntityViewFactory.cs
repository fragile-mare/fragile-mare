using _Project.Code.Common.Services.Assets;
using UnityEngine;
using Zenject;

namespace _Project.Code.Infrastructure.View.Factory
{
    public class EntityViewFactory : IEntityViewFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IInstantiator _instantiator;
        private Vector3 _farAway = new Vector3(-99999, -99999, -99999);

        public EntityViewFactory(IAssetProvider assetProvider, IInstantiator instantiator)
        {
            _assetProvider = assetProvider;
            _instantiator = instantiator;
        }

        public EntityBehaviour CreateViewForEntity(GameEntity entity)
        {
            EntityBehaviour viewPrefab = _assetProvider.LoadAsset<EntityBehaviour>(entity.ViewPath);
            var view = _instantiator.InstantiatePrefabForComponent<EntityBehaviour>(
                viewPrefab,
                position: _farAway,
                Quaternion.identity,
                parentTransform: null
            );
            
            view.SetEntity(entity);
            
            return view;
        }

        public EntityBehaviour CreateViewForEntityFromPrefab(GameEntity entity)
        {
            var view = _instantiator.InstantiatePrefabForComponent<EntityBehaviour>(
                entity.viewPrefab.Value,
                position: _farAway,
                Quaternion.identity,
                parentTransform: null
            );
            
            view.SetEntity(entity);
            
            return view;
        }
    }
}