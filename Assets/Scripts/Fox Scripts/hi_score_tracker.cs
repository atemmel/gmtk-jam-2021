using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hi_score_tracker : MonoBehaviour
{
    public float multiplier_time;
    int score = 0;
    int multi = 1;
    float multiplied_last;
    GameObject found_object;
    // Start is called before the first frame update
    void Start()
    {
        multiplied_last = multiplier_time;
    }

    // Update is called once per frame
    void Update()
    {
        multiplied_last += Time.deltaTime;
        if (multiplied_last > multiplier_time)
        {
            multi = 1;
        }
        found_object = GameObject.FindGameObjectWithTag("ScoreAdder");
        if (found_object != null)
        {
            if (found_object.GetComponent<ScoreAdder>().multiplier == 1)
            {
                multi += found_object.GetComponent<ScoreAdder>().multiplier;
                multiplied_last = 0;
            }
            score += found_object.GetComponent<ScoreAdder>().value * multi;
            found_object.GetComponent<ScoreAdder>().destruction_sequence();
        }
        GetComponent<Text>().text = score.ToString() + " " + multi.ToString() + "x";
    }
}
