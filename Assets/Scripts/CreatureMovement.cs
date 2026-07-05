using UnityEngine;

public class CreatureMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Vector3 randomDirection = new (Random.Range(0, 360), Random.Range(0, 360));
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Random.rotation;
        transform.Translate(Vector3.forward * (Time.deltaTime * speed));
    }
}
