using System;
using UnityEngine;

namespace DefaultNamespace
{
    /**
     * Constructor used to publish events related to creature
     */
    public class CreateSpawnEventArgs : EventArgs
    {
        public GameObject Creature { get; }

        public CreateSpawnEventArgs(GameObject creature)
        {
            Creature = creature;
        }
        
    }
}