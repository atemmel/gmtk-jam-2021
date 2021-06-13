using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionTracker : MonoBehaviour
{
    public GameObject score_empty;
    public int score;

    private void OnDestroy()
    {
        var down_bound = Camera.main.ScreenToWorldPoint(Vector3.zero).y;
        var upper_bound = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, Camera.main.pixelHeight, 0.0f)).y;
        if (transform.position.y > down_bound && transform.position.y < upper_bound)
        {
            var add_score = Instantiate(score_empty, transform.position, Quaternion.identity);
            add_score.GetComponent<ScoreAdder>().value = score;
        }
    }
}
