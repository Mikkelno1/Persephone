using System;
using UnityEngine;

namespace DefaultNamespace
{
    /**
     * Constructor used to publish events related to food
     */
    public class FoodEatenEventArgs : EventArgs
    {
        public GameObject Food { get; }

        public FoodEatenEventArgs(GameObject food)
        {
            Food = food;
        }
    }
}