using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_behaviour : MonoBehaviour
{

    public GameObject player;
    public GameObject bullet;
    Vector3 enemy_velocity;
    Vector3 acc;
    public float startLerpingDistance;

    public int maximum_dist;
    readonly int minimum_dist = 4;
    public float speed;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        enemy_velocity = getPositionDiff().normalized*speed;
        timer = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos_diff = getPositionDiff();

        //Bestämmer vilken hastighet objektet har just nu
        var targetPosition = (transform.position - player.transform.position).normalized * maximum_dist;
        var positionDelta = targetPosition - transform.position;

        /*if (positionDelta.magnitude < startLerpingDistance)
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.Lerp(positionDelta.normalized, positionDelta.normalized * speed, positionDelta.magnitude / startLerpingDistance);
        }
        else*/
        {
            GetComponent<Rigidbody2D>().velocity = positionDelta.normalized * speed;
        }

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
