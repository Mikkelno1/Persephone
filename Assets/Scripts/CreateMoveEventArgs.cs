using UnityEngine;

namespace DefaultNamespace
{
    public class CreateMoveEventArgs
    {
        public GameObject Creature { get; }

        public CreateMoveEventArgs(GameObject creature)
        {
            Creature = creature;
        }
    }
}