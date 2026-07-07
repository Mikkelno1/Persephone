using System;
using DefaultNamespace;
using UnityEngine;

public class FoodEaten : MonoBehaviour
{
    public event EventHandler<FoodEatenEventArgs> OnFoodEaten;
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Food")) 
        {
            Destroy(collision.gameObject);
            Debug.Log("I just removed some food that was totally destroyed");
            
            FoodEatenEventArgs foodEatenEventArgs = new FoodEatenEventArgs(collision.gameObject);
                
            OnFoodEaten?.Invoke(this, foodEatenEventArgs);
        }
    }

    
}
