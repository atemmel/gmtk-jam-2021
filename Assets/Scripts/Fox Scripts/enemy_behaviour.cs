using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_behaviour : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet;
    //Vector3 enemy_velocity;
    //Vector3 acc;
    public float startLerpingDistance;

    public int maximum_dist;
    //public int minimum_dist;
    public float speed;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        //enemy_velocity = getPositionDiff().normalized*speed;
        timer = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        //Move kinda close to player
        var targetPosition = player.transform.position + ((transform.position - player.transform.position).normalized * maximum_dist);
        var positionDelta = targetPosition - transform.position;
        var newVelocity = positionDelta.normalized * speed;

        if (positionDelta.magnitude < startLerpingDistance)
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.Lerp(Vector3.zero, newVelocity, positionDelta.magnitude / startLerpingDistance);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = newVelocity;
        }

        //Look at player
        transform.up = (player.transform.position - transform.position) * -1;

        //var targetPosition = transform.position;
        //if (getPositionDiff().magnitude > minimum_dist)
        //{
        //    targetPosition = player.transform.position + ((transform.position - player.transform.position).normalized * minimum_dist);
        //}
        //else if (getPositionDiff().magnitude < maximum_dist)
        //{
        //    targetPosition = player.transform.position + ((transform.position - player.transform.position).normalized * maximum_dist);
        //}

        //Kulor som skickas
        if (Time.realtimeSinceStartup - timer > 2)
        {
            var bull = Instantiate(bullet, transform.position, transform.rotation);
            var velocity = getPositionDiff().normalized;
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
