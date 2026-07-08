using System;
using DefaultNamespace;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class CreatureMovement : MonoBehaviour
{
    /**
     * 
     */
    [SerializeField] private float speed = 5f;

    private Rigidbody rb;

    private Vector3 randomDirection;
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        //randomDirection = new (Random.Range(0, 360), Random.Range(0, 360));
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        rb.AddForce(Vector3.right * 5f, ForceMode.Impulse);
        //rb.useGravity = true;
        //transform.Translate(Vector3.forward * (Time.deltaTime * speed), Space.World);
        //transform.Rotate(randomDirection * (speed * Time.deltaTime));
    }
    
   
}


