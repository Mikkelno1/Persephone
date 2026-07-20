using UnityEngine;

namespace DefaultNamespace
{
    public class NetworkLayer 
    {
        public float[,] weightsArray;
        public float[] biasArray;
        public float[] nodesArray;
        public int inputs;
        public int neurons;

        public NetworkLayer(int inputs, int neurons)
        {
            this.neurons = neurons;
            this.inputs = inputs;
            

            weightsArray = new float[neurons, inputs];
            biasArray = new float[neurons];
        }
        
        public void NextNode(float[] inputArray)
        {
            nodesArray = new float[neurons];
            for (int i = 0; i < neurons; i++)
            {
                for (int j = 0; j < inputs; j++)
                {
                    nodesArray[i] += weightsArray[i, j] * inputArray[j];
                }
                nodesArray[i] += biasArray[i];
            }
        }
        
        public void Activation()
        {
            for (int i = 0; i < neurons; i++)
            {
                if (nodesArray[i] < 0)
                {
                    nodesArray[i] = 0;
                }
            }
        }

        public NetworkLayer[] CopyLayer(int[] networkDepth, NetworkLayer[] oldLayer)
        {
            NetworkLayer[] copyLayer = new NetworkLayer[networkDepth.Length - 1];

            for (int i = 0; i < oldLayer.Length; i++)
            {
                copyLayer[i] = new NetworkLayer(networkDepth[i], networkDepth[i + 1]);
                System.Array.Copy(oldLayer[i].weightsArray, copyLayer[i].weightsArray, oldLayer[i].weightsArray.GetLength(0)*oldLayer[i].weightsArray.GetLength(1));
                System.Array.Copy(oldLayer[i].biasArray, copyLayer[i].biasArray, oldLayer[i].biasArray.GetLength(0));
            }

            return copyLayer;
        }

        public void RandomizeWeightsAndBiases()
        {
            for (int i = 0; i < neurons; i++)
            {
                for (int j = 0; j < inputs; j++)
                {
                    weightsArray[i, j] = Random.Range(-1f, 1f);
                }
                biasArray[i] = Random.Range(-1f, 1f);
            }
        }
        
        

        
        
       
    }
}