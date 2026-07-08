using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class CreatureSpawner : MonoBehaviour
{
    /**
     * Handles spawning of creatures 
     */
    
    [SerializeField] private GameObject creature;
    [SerializeField] private int maxSpawn = 10;
    [SerializeField] private GameObject ground;
    private List<GameObject> _creatureList = new List<GameObject>();
    private LayerMask _mask;
    private Renderer _rend; //used to turn spawner invisible
    
    public event EventHandler<CreateSpawnEventArgs> OnCreatureSpawn; //eventhandler used to publish messages to subscribers when a creature is spawned
    
    void Start()
    {
        _rend = GetComponent<Renderer>();
        _rend.enabled = false; //turns spawner invisible 
    }

    private void Awake()
    {
        _mask = LayerMask.GetMask("Ground"); //fetches layer with specific name
    }
    
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    /**
     * used to spawn the initial amount of creatures
     */
    public void SpawnInitialCreatures()
    {
        
        for (int i = 0; i < maxSpawn; i++)
        {
            SpawnCreature();
        }
    }

    /**
     * used to spawn creature based on a set grid and distance from ground
     */
    public void SpawnCreature()
    { 
    
        Vector3 _randomVector3 = new Vector3(RandomX(), 15f, RandomZ());
        RaycastHit hit;
        
        if (_creatureList.Count < maxSpawn && Physics.Raycast(_randomVector3, transform.TransformDirection(Vector3.up * -1.0f), out hit, 20, _mask))
        {
            Debug.DrawRay(_randomVector3, transform.TransformDirection(Vector3.up * -1.0f) * hit.distance, Color.red); //draws rays for debugging
            
            GameObject newCreature = Instantiate(creature, new Vector3(_randomVector3.x, 3f, _randomVector3.z), Quaternion.identity);
            _creatureList.Add(newCreature);
            OnCreatureSpawned(newCreature);
        }
    }

    /**
     * sends message to subscribers on creature spawn
     */
    private void OnCreatureSpawned(GameObject gameObject)
    {
        CreateSpawnEventArgs creatureSpawnEventArgs = new CreateSpawnEventArgs(gameObject);
        OnCreatureSpawn?.Invoke(this, creatureSpawnEventArgs);
    }

    /**
     * used to define a random x-coordinate based on values set
     */
    private int RandomX()
    {
        return Random.Range(-18, 18);
    }

    /**
     * used to define a random z-coordinate based on values set
     */
    private int RandomZ()
    {
        return Random.Range(-17, 17);
    }
    
}
