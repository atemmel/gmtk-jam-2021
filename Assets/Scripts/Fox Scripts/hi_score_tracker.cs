using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hi_score_tracker : MonoBehaviour
{
    int score = 0;
    GameObject found_object;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        found_object = GameObject.FindGameObjectWithTag("ScoreAdder");
        if (found_object != null)
        {
            score += found_object.GetComponent<ScoreAdder>().value;
            found_object.GetComponent<ScoreAdder>().destruction_sequence();
            GetComponent<Text>().text = score.ToString();
        }
    }
}
