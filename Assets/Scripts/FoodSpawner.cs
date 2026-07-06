using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject _food;
    [SerializeField] private int _maxSpawn = 20;
    [SerializeField] private GameObject _ground;
    private LayerMask mask;
    private int foodCount = 0;
    private Vector3 randomVector3;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
        /*
        if (_food.IsDestroying())
        {
            SpawnFood();
        }
        */
       
    }

    private void Awake()
    {
        mask = LayerMask.GetMask("Ground");
    }

    private void FixedUpdate()
    {
        int randomX = Random.Range(-18, 18);
        int randomZ = Random.Range(-17, 17);
        randomVector3 = new Vector3(randomX, 15f, randomZ);
        
        RaycastHit hit;
        if (Physics.Raycast(randomVector3, transform.TransformDirection(Vector3.up * -1.0f), out hit, 20, mask))
        {
            Debug.DrawRay(randomVector3, transform.TransformDirection(Vector3.up * -1.0f) * hit.distance, Color.red);
            
            GameObject newFood = Instantiate(_food, new Vector3(randomX, hit.point.y, randomZ), Quaternion.identity);
            foodCount++;
            /*
            //hit.collider.gameObject.Equals(_ground)
            Debug.Log(hit.collider.gameObject.layer + " " + mask);
            if (hit.transform.gameObject.layer == mask)
            {
                Debug.Log("Inside if");
                GameObject newFood = Instantiate(_food, new Vector3(randomX, 5f, randomZ), Quaternion.identity);
                foodCount++;
            }
            */
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnFood()
    {
        //Vector3 pos = ground.transform.position;
        //pos.y = ground.transform.position.y;
        
        //Vector3 randomSpawnPosition = new Vector3(Random.Range(-10, 11), 8.3f, Random.Range(-10, 11));
        GameObject newFood = Instantiate(_food, randomVector3, Quaternion.identity);
        
    }
}
