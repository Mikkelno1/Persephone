using UnityEngine;

namespace DefaultNamespace
{
    public class WorldManager : MonoBehaviour
    {
        [SerializeField] private FoodSpawner _foodSpawner;
        [SerializeField] private CreatureSpawner _creatureSpawner;
        
        
        void Start()
        {
            _foodSpawner.SpawnFood();
            _creatureSpawner.SpawnCreature();
        }
    }
}