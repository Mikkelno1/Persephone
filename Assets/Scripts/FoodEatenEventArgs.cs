using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class FoodEatenEventArgs : EventArgs
    {
        public GameObject Food { get; }

        public FoodEatenEventArgs(GameObject food)
        {
            Food = food;
        }
    }
}