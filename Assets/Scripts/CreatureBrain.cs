using UnityEngine;

namespace DefaultNamespace
{
    public class CreatureBrain : MonoBehaviour
    {
        private int[] _NetworkLayers = { 2, 4, 2 };
        private NetworkLayer[] _layer;
        
        public void Awake()
        {
            _layer = new NetworkLayer[_NetworkLayers.Length - 1];

            for (int i = 0; i < _layer.Length; i++)
            {
                _layer[i] = new NetworkLayer(_NetworkLayers[i], _NetworkLayers[i + 1]);
            }
        }

        public float[] Brain(float[] inputs)
        {
            for (int i = 0; i < _layer.Length; i++)
            {
                if (i == 0)
                {
                    _layer[i].NextNode(inputs);
                    _layer[i].Activation();
                } 
                else if (i == _layer.Length - 1)
                {
                    _layer[i].NextNode(_layer[i - 1].nodesArray);
                }
                else
                {
                    _layer[i].NextNode(_layer[i - 1].nodesArray);
                    _layer[i].Activation();
                }
            }

            return _layer[_layer.Length - 1].nodesArray;
        }
        
    }
}