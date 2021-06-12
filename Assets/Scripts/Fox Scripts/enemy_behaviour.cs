using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_behaviour : MonoBehaviour
{
    public List<GameObject> player_objects;
    public GameObject bullet;
    //Vector3 enemy_velocity;
    //Vector3 acc;
    public float startLerpingDistance;

    float check_mag;
    float new_mag;
    int closest_object;
    public int maximum_dist;
    //public int minimum_dist;
    public float speed;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        //enemy_velocity = getPositionDiff().normalized*speed;
        timer = Time.realtimeSinceStartup;
        check_mag = getPositionDiff(player_objects[0]).magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < player_objects.Count; i++)
        {
            new_mag = getPositionDiff(player_objects[i]).magnitude;
            if (new_mag < check_mag)
            {
                check_mag = new_mag;
                closest_object = i;
            }
        }
        check_mag = getPositionDiff(player_objects[closest_object]).magnitude;

        //Vector3 pos_diff = getPositionDiff();
        var targetPosition = player_objects[closest_object].transform.position + ((transform.position - player_objects[closest_object].transform.position).normalized * maximum_dist);
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

        //Kulor som skickas
        if (Time.realtimeSinceStartup - timer > 2)
        {
            var bull = Instantiate(bullet, transform.position, transform.rotation);
            var velocity = getPositionDiff(player_objects[closest_object]).normalized;
            bull.GetComponent<Rigidbody2D>().velocity = velocity;
            timer = Time.realtimeSinceStartup;
        }
    }

    Vector3 getPositionDiff(GameObject player)
    {
        return player.transform.position - transform.position;
    }

    float getAngle(GameObject player)
    {
        return Vector3.Angle(transform.position, player.transform.position);
    }
}
