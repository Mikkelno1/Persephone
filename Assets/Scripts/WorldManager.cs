using System;
using UnityEngine;

namespace DefaultNamespace
{
    /**
     * used to initialize world
     */
    public class WorldManager : MonoBehaviour
    {
        [SerializeField] private FoodSpawner _foodSpawner;
        [SerializeField] private CreatureSpawner _creatureSpawner;
        
        
        void Start()
        {
            //_foodSpawner.SpawnFood();
            //_creatureSpawner.SpawnCreature();
        }

        private void Update()
        {
        }

        private void LateUpdate()
        {
            _foodSpawner.SpawnFood();
            _creatureSpawner.SpawnCreature();
        }
    }
}