using System;
using System.Collections.Generic;
using DefaultNamespace;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class FoodSpawner : MonoBehaviour
{
    /**
     * spawns initial food and subscribes to publishers to determine new food spawn 
     */
    [SerializeField] private GameObject food;
    [SerializeField] private int maxSpawn = 20;
    [SerializeField] private GameObject ground;
    [SerializeField] private CreatureSpawner _creatureSpawner;
    private LayerMask _mask;
    private List<GameObject> _foodList = new List<GameObject>();
    private Vector3 _randomVector3;
    private Renderer _rend; //used to turn spawner invisible
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _creatureSpawner.OnCreatureSpawn += Receiving_OnCreatureSpawn; //subscribes to message from publisher whenever creature is spawned
        _rend = GetComponent<Renderer>();
        _rend.enabled = false; //turns spawner invisible
    }

    private void Awake()
    {
        _mask = LayerMask.GetMask("Ground"); //fetches layer with specific name
    }

    private void FixedUpdate()
    {
        SpawnFood();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
     * spawns food based on random grid coordinates and set distance from ground
     */
    public void SpawnFood()
    {
        var randomX = Random.Range(-18, 18);
        var randomZ = Random.Range(-17, 17);
        _randomVector3 = new Vector3(randomX, 15f, randomZ);
        
        RaycastHit hit;
        if (Physics.Raycast(_randomVector3, transform.TransformDirection(Vector3.up * -1.0f), out hit, 20, _mask) && _foodList.Count < maxSpawn)
        {
            Debug.DrawRay(_randomVector3, transform.TransformDirection(Vector3.up * -1.0f) * hit.distance, Color.red); //used to draw rays for debugging
            
            GameObject newFood = Instantiate(food, new Vector3(randomX, hit.point.y, randomZ), Quaternion.identity);
            _foodList.Add(newFood);
        }
    }
    
    /**
     * subscribes to message related to food eaten - if eaten, remove said food from list
     */
    private void Sending_OnFoodEaten(object sender, FoodEatenEventArgs f)
    {
        if (_foodList.Contains(f.Food))
        {
            _foodList.Remove(f.Food);
        }
    }

    /**
     * fetches foodEaten component from newly spawned creatures
     */
    private void Receiving_OnCreatureSpawn(object receiver, CreateSpawnEventArgs c)
    {
        FoodEaten foodEaten = c.Creature.GetComponent<FoodEaten>();
        foodEaten.OnFoodEaten += Sending_OnFoodEaten;
    }
    
    
}
