using UnityEngine;

public class FoodRayCast : MonoBehaviour
{
    [SerializeField] private GameObject _food;
    private LayerMask mask;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(_food.transform.position, transform.TransformDirection(Vector3.up * -1.0f), out hit, 20, mask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up * -1.0f) * hit.distance, Color.red);
        }

    }
}
