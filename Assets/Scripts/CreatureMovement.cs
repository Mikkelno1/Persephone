using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CreatureMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    

    private Vector3 randomDirection;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        randomDirection = new (Random.Range(0, 360), Random.Range(0, 360));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * (Time.deltaTime * speed));
        //transform.Rotate(randomDirection * (speed * Time.deltaTime));
    }
}
