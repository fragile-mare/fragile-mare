using System;
using _Project.Code.Common.Entity;
using _Project.Code.Common.Extensions;
using _Project.Code.Common.Services.Identifiers;
using _Project.Code.Gameplay.Features.Status.Configs;
using UnityEngine;

namespace _Project.Code.Gameplay.Features.Status.Factories
{
    public class StatusFactory : IStatusFactory
    {
        private readonly IIdentifierService _identifierService;

        public StatusFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateStatus(StatusSetup statusSetup, int targetId, int producerId)
        {
            GameEntity entity;

            switch (statusSetup.type)
            {
                case StatusType.Acceleration:
                    entity = CreateAccelerationStatus(statusSetup.targetVelocity,
                        statusSetup.deltaAxis);
                    break;
                case StatusType.AccelerationInput:
                    entity = CreateAccelerationInputStatus(statusSetup.targetVelocity,
                        statusSetup.deltaAxis);
                    break;
                case StatusType.SphereRelativePush:
                    entity = CreateSphereRelativePushStatus(statusSetup.radius);
                    break;
                default:
                    throw new Exception($"Unknown status with type id {statusSetup.type}");
            }

            entity
                .AddId(_identifierService.Next())
                .AddStatusType(statusSetup.type)
                .AddTargetId(targetId)
                .AddProducerId(producerId)
                .AddEffectValue(statusSetup.value)
                .With(e => e.isStatus = true)
                .With(e => e.AddDurationTimer(statusSetup.duration), when: statusSetup.duration > 0);

            return entity;
        }

        public GameEntity CreateAccelerationStatus(int targetId, int producerId, float force, Vector3 deltaAxis)
        {
            return CreateStatus(targetId, producerId, force, StatusType.Acceleration)
                .AddTargetVelocity(Vector3.zero)
                .AddDeltaAxis(deltaAxis)
                .With(e => e.isAccelerationStatus = true);
        }

        public GameEntity CreateSphereRelativePushingStatus(int targetId, int producerId, float force, float radius)
        {
            return CreateStatus(targetId, producerId, force, StatusType.SphereRelativePush)
                .AddRadius(radius)
                .With(e => e.isSphereRelativePushStatus = true);
        }

        public GameEntity CreateAccelerationStatusForInput(int targetId, int producerId, float force)
        {
            return CreateAccelerationStatus(targetId, producerId, force, new Vector3(1, 0, 1))
                .With(e => e.isInputAccelerationStatus = true);
        }

        private GameEntity CreateStatus(int targetId, int producerId, float value, StatusType type)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddStatusType(type)
                .AddTargetId(targetId)
                .AddProducerId(producerId)
                .AddEffectValue(value)
                .With(e => e.isStatus = true);
        }

        private GameEntity CreateSphereRelativePushStatus(float radius)
        {
            return CreateEntity.Empty()
                .AddRadius(radius)
                .With(e => e.isSphereRelativePushStatus = true);
        }

        private GameEntity CreateAccelerationStatus(Vector3 targetVelocity, Vector3 deltaAxis)
        {
            return CreateEntity.Empty()
                .AddTargetVelocity(targetVelocity)
                .AddDeltaAxis(deltaAxis)
                .With(e => e.isAccelerationStatus = true);
        }

        private GameEntity CreateAccelerationInputStatus(Vector3 targetVelocity, Vector3 deltaAxis)
        {
            return CreateAccelerationStatus(targetVelocity, deltaAxis)
                .With(e => e.isInputAccelerationStatus = true);
        }
    }
}