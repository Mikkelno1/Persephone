using System;
using DefaultNamespace;
using UnityEngine;

public class FoodEaten : MonoBehaviour
{
    /**
     * checks for collision of spawned creatures and publishes message to subscribers when condition met
     */
    public event EventHandler<FoodEatenEventArgs> OnFoodEaten;
    
    
    
    void Start()
    {
        
    }
    
    void Update()
    {
    }
    
    /**
     * publishes message when gameobject equals food
     */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Food")) 
        {
            Destroy(collision.gameObject);
            
            FoodEatenEventArgs foodEatenEventArgs = new FoodEatenEventArgs(collision.gameObject);
                
            OnFoodEaten?.Invoke(this, foodEatenEventArgs);
        }
    }

    
}
