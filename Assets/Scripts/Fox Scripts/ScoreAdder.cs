using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAdder : MonoBehaviour
{

    public int value;
    public int multiplier;

    public void destruction_sequence()
    {
        Destroy(gameObject);
    }
}
