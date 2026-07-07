using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class CreateSpawnEventArgs : EventArgs
    {
        public GameObject Creature { get; }

        public CreateSpawnEventArgs(GameObject creature)
        {
            Creature = creature;
        }
        
    }
}