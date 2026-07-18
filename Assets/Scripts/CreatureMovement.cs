using System;
using DefaultNamespace;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class CreatureMovement : MonoBehaviour
{
    /**
     * 
     */
    
    [SerializeField] private float speed = 5f;
    [SerializeField] private float directionChangeSpeed = 5f;

    private Rigidbody rb;

    private float _timeSpent;
    private int _numberOfRaycasts = 18;
    private int _raycastAngle = 20;
    private Vector3 _rotation;
    private float[] _distanceToFood = new float[135];
    private int _creatureViewDistance = 20;
    private LayerMask _foodMask;
    private CreatureBrain cb;
    public float FB = 0;
    public float LR = 0;
    
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        _foodMask = LayerMask.GetMask("Food");
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float startAngle = -67.5f;
        int noOfLines = 135;
        float step = 135f / (noOfLines - 1);
        RaycastHit hit;
        
        for (int i = 0; i < noOfLines; i++)
        {
            float angle = startAngle + i * step;
            Vector3 rayDirection = Quaternion.Euler(0, angle, 0) * transform.forward;
            Vector3 rayDirectionDown = (Quaternion.Euler(0, angle, 0) * transform.forward + Vector3.down * 0.1f).normalized;
            Vector3 rayStart = transform.position + Vector3.up * 0.1f;
            Vector3 downRay = (transform.position + Vector3.down * -0.1f);
            Debug.DrawRay(rayStart, rayDirection * 8f, Color.green);
            Debug.DrawRay(downRay, rayDirectionDown * 8f, Color.red);
            
            if (Physics.Raycast(rayStart, rayDirection, out hit, _creatureViewDistance, _foodMask)) 
            {
                if (hit.transform.gameObject.CompareTag("Food"))
                {
                    _distanceToFood[i] = hit.distance / _creatureViewDistance;
                    Console.WriteLine("Found food " + hit.distance / _creatureViewDistance);
                }
            }
        }
        
        
    }

    private void NewDirection()
    {
        _rotation = new Vector3(
            Random.Range(-1f, 1f),
            0f,
            Random.Range(-1f, 1f)
        ).normalized;
    }

    private void Move(float fb, float lr)
    {
        fb = Mathf.Clamp(fb, 0, 1);
        lr = Mathf.Clamp(lr, -1, 1);

        _rotation = new Vector3(0, lr, 0);
        
        rb.AddForce(Vector3.forward * (speed * fb));
        
    }
    
    
    
    
}


