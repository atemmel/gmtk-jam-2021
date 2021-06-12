using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_behaviour : MonoBehaviour
{

    public GameObject player;
    public GameObject bullet;
    Vector3 enemy_velocity;

    int curr_dir = 1;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        enemy_velocity = getPositionDiff() / 4;
        timer = Time.realtimeSinceStartup;
        //Vector3 acc = (getPositionDiff().magnitude);
    }

    // Update is called once per frame
    void Update()
    {
        //Get difference in position
        Vector3 pos_diff = getPositionDiff();

        /*if (Mathf.Abs(Acc.magnitude) > 1)
            acc = Mathf.Pow(pos_diff - 4);*/

        Quaternion player_angle = Quaternion.Euler(0, 0, getAngle());

        //enemy_velocity = 

        if (pos_diff.magnitude < 3 && curr_dir == 1)
            curr_dir = -1;
        else if (pos_diff.magnitude > 5 && curr_dir == -1)
            curr_dir = 1;

        //enemy_velocity += acc*Time.deltaTime;

        transform.position += curr_dir*(enemy_velocity* Time.deltaTime);

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
