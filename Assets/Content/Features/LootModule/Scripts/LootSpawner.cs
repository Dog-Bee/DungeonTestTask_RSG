using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using Zenject;

namespace Content.Features.LootModule.Scripts
{
    public enum DropState
    {
        OneItem = 0,
        MultipleItems = 1,
        AllItems = 2,
    }

    [Serializable] public struct LootChance
    {
        public Loot Prefab;
        [Range(0, 100)] public int Chance;
    }

    public class LootSpawner : MonoBehaviour
    {
        [SerializeField] private List<LootChance> _lootToSpawn;
        [SerializeField] private DropState _dropState = DropState.OneItem;

        private DiContainer _diContainer;

        [Inject] public void InjectDependencies(DiContainer diContainer) =>
            _diContainer = diContainer;

        public void SpawnLoot()
        {
            switch (_dropState)
            {
                case DropState.OneItem:
                    SpawnSingle();
                    break;

                case DropState.MultipleItems:
                    SpawnMultiple();
                    break;

                case DropState.AllItems:
                    SpawnAll();
                    break;
            }
        }

        public void SpawnSingle()
        {
            int totalChance = 0;
            foreach (var l in _lootToSpawn) totalChance += l.Chance;

            if (totalChance == 0) return;

            int roll = UnityEngine.Random.Range(0, totalChance);
            int accumulation = 0;

            foreach (var l in _lootToSpawn)
            {
                accumulation += l.Chance;
                if (roll < accumulation)
                {
                    _diContainer.InstantiatePrefab(l.Prefab, transform.position, Quaternion.identity, null);
                    return;
                }
            }
        }

        public void SpawnMultiple()
        {
            foreach (var l in _lootToSpawn)
            {
                if (UnityEngine.Random.Range(0, 100) <= l.Chance)
                {
                    _diContainer.InstantiatePrefab(l.Prefab, transform.position, Quaternion.identity, null);
                }
            }
        }

        public void SpawnAll()
        {
            foreach (var l in _lootToSpawn)
            {
                _diContainer.InstantiatePrefab(l.Prefab, transform.position, Quaternion.identity, null);
            }
        }
    }
}