using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _creature;
    public Renderer rend;
    [SerializeField] private int _maxSpawn = 2;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
        
        for (int i = 0; i < _maxSpawn; i++)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-10, 11), 2.3f, Random.Range(-10, 11));
            GameObject newCreature = Instantiate(_creature, randomSpawnPosition, Quaternion.identity);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
