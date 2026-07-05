using UnityEngine;


public class SimulationManager : MonoBehaviour
{
    public GameObject creature;
        private void Start()
        {
            
            Instantiate(creature, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
