﻿using UnityEngine;

namespace ETModel
{
    public static class UnitFactory
    {
        public static Unit Create(long id)
        {
            ResourcesComponent resourcesComponent = Game.Scene.GetComponent<ResourcesComponent>();
            GameObject bundleGameObject = (GameObject) resourcesComponent.GetAsset("Unit.unity3d", "Unit");
            GameObject prefab = bundleGameObject.Get<GameObject>("HuanCi");

            UnitComponent unitComponent = Game.Scene.GetComponent<UnitComponent>();

            // GameObject go = UnityEngine.Object.Instantiate(prefab);
            // Unit unit = ComponentFactory.CreateWithId<Unit, GameObject>(id, go);

            Game.Scene.GetComponent<GameObjectPool<Unit>>().Add("HuanCi", prefab);
            Unit unit = Game.Scene.GetComponent<GameObjectPool<Unit>>().FetchWithId(id, "HuanCi");

            unit.AddComponent<AnimatorComponent>();
            unit.AddComponent<MoveComponent>();
            unit.AddComponent<TurnComponent>();
            unit.AddComponent<UnitPathComponent>();

            unitComponent.Add(unit);
            return unit;
        }
    }
}