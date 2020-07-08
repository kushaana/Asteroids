using System.Collections;
using UnityEngine;


public class Probability
{
    public int choose(float[] probabilities)
    {

        float restProbability = 0;
        for (int i = 0; i < probabilities.Length; i++)
        {
            restProbability += probabilities[i];
        }
        for (int i = 0; i < probabilities.Length; i++)
        {
            float randomF = Random.Range(0, restProbability);
            if (randomF < probabilities[i])
                return i;
            else
                restProbability -= probabilities[i];
        }
        return probabilities.Length - 1;
    }
}