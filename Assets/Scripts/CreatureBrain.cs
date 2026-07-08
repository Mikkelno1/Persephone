using UnityEngine;

namespace DefaultNamespace
{
    public class CreatureBrain : MonoBehaviour
    {
        public CreatureBrain layer1;
        public CreatureBrain layer2;
        public CreatureBrain outputLayer;

        private int _noNodes;
        private int _noInputs;

        private float[,] _weightArray;
        private float[] _biasArray;
        private float[] _nodeArray;

        public void Awake()
        {
            layer1 = new CreatureBrain(2, 4);
            layer2 = new CreatureBrain(4, 4);
            outputLayer = new CreatureBrain(4, 2);
        }
        
        public CreatureBrain(int noInputs, int noNodes)
        {
            _noInputs = noInputs;
            _noNodes = noNodes;

            _weightArray = new float[noNodes, noInputs];
            _biasArray = new float[noNodes];
            _nodeArray = new float[noNodes];
        }

        public void nextNode(float[] inputArray)
        {
            _nodeArray = new float[_noNodes];
            for (int i = 0; i < _noNodes; i++)
            {
                for (int j = 0; j < _noInputs; j++)
                {
                    _nodeArray[i] += _weightArray[i, j] * inputArray[j];
                }
                _nodeArray[i] += _biasArray[i];
            }
        }
        
    }
}