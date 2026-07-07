using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class CreatureSpawner : MonoBehaviour
{
    [SerializeField] private GameObject creature;
    [SerializeField] private int maxSpawn = 10;
    [SerializeField] private GameObject ground;
    private List<GameObject> _creatureList = new List<GameObject>();
    private LayerMask _mask;
    private Renderer _rend;
    
    public event EventHandler<CreateSpawnEventArgs> OnCreatureSpawn;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("CreatureSpawner spawning");
        _rend = GetComponent<Renderer>();
        _rend.enabled = false;
        
        
    }

    private void Awake()
    {
        _mask = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    public void SpawnInitialCreatures()
    {
        
        for (int i = 0; i < maxSpawn; i++)
        {
            SpawnCreature();
        }
    }

    public void SpawnCreature()
    { 
        Vector3 _randomVector3 = new Vector3(RandomX(), 15f, RandomZ());
        RaycastHit hit;
        
        if (_creatureList.Count < maxSpawn && Physics.Raycast(_randomVector3, transform.TransformDirection(Vector3.up * -1.0f), out hit, 20, _mask))
        {
            Debug.DrawRay(_randomVector3, transform.TransformDirection(Vector3.up * -1.0f) * hit.distance, Color.red);
            
            GameObject newCreature = Instantiate(creature, new Vector3(_randomVector3.x, hit.point.y, _randomVector3.z), Quaternion.identity);
            _creatureList.Add(newCreature);
            OnCreatureSpawned(newCreature);
        }
    }

    private void OnCreatureSpawned(GameObject gameObject)
    {
        CreateSpawnEventArgs creatureSpawnEventArgs = new CreateSpawnEventArgs(gameObject);
        OnCreatureSpawn?.Invoke(this, creatureSpawnEventArgs);
    }

    private int RandomX()
    {
        return Random.Range(-18, 18);
    }

    private int RandomZ()
    {
        return Random.Range(-17, 17);
    }
    
}
