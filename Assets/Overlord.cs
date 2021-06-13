using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlord : MonoBehaviour
{
    public GameObject[] player_objects;
    GameObject found_object;

    public int enemycount;


    private void Start()
    {

    }

    void Update()
    {
        found_object = GameObject.FindGameObjectWithTag("ScoreAdder");
        if (found_object != null)
        {
            enemycount--;
        }
        if (enemycount <= 0)
        {
            player_objects[0].SetActive(false);

            var vec = transform.position;
            Instantiate(player_objects[1], vec, Quaternion.identity);
            enemycount = 100;
        }
    }
}
