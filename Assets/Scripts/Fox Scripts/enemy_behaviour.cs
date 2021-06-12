using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_behaviour : MonoBehaviour
{

    public GameObject player;
    public GameObject bullet;
    Vector3 enemy_velocity;

    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        enemy_velocity = getPositionDiff() / 4;
        timer = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos_diff = getPositionDiff();

        GetComponent<Rigidbody2D>().velocity = enemy_velocity + pos_diff.normalized;

        //Kulor som skickas
        if (Time.realtimeSinceStartup - timer > 2)
        {
            var bull = Instantiate(bullet, transform.position, transform.rotation);
            var velocity = pos_diff.normalized;
            bull.GetComponent<Rigidbody2D>().velocity = velocity;
            timer = Time.realtimeSinceStartup;
        }
    }
    Vector3 getPositionDiff()
    {
        return player.transform.position - transform.position;
    }
    float getAngle()
    {
        return Vector3.Angle(transform.position, player.transform.position);
    }
}
