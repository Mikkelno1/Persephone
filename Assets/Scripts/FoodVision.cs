using UnityEngine;

public class FoodVision : MonoBehaviour
{
    /**
     * adds rays to individual food objects used for spawning
     */
    [SerializeField] private GameObject _food;
    private LayerMask mask;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(_food.transform.position, transform.TransformDirection(Vector3.up * -1.0f), out hit, 20, mask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up * -1.0f) * hit.distance, Color.red); //draws rays used for debugging
        }

    }
}
