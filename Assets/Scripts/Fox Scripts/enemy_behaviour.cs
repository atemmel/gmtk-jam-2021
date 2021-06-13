using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_behaviour : MonoBehaviour
{
    GameObject[] player_objects;
    public GameObject bullet;
    public float startLerpingDistance;
    public float rot_speed;
    public float bull_speed;

    float check_mag;
    float new_mag;
    int closest_object;
    public int maximum_dist;
    public float speed;
    float timer = 0;
    int rotation_dir = -1;
    int[] last_activation = { 0, 0 };

    public float shotTimer;
    float last_shot;

    // Start is called before the first frame update
    void Start()
    {
        last_shot = shotTimer;
        player_objects = new GameObject[] { GameObject.FindGameObjectWithTag("ship_left"), GameObject.FindGameObjectWithTag("ship_right"), GameObject.FindGameObjectWithTag("cargo")};
        check_mag = getPositionDiff(player_objects[0]).magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        closeObjectLogic();
        Movement();

        //Look at player
        transform.up = (player_objects[closest_object].transform.position - transform.position) * -1;

        //Kulor som skickas
        ShootyShoot();
    }

    void closeObjectLogic()
    {
        for (int i = 0; i < player_objects.Length; i++)
        {
            new_mag = getPositionDiff(player_objects[i]).magnitude;
            if (new_mag < check_mag)
            {
                check_mag = new_mag;
                closest_object = i;
            }
        }
        check_mag = getPositionDiff(player_objects[closest_object]).magnitude;
    }

    void Movement()
    {
        var targetPosition = player_objects[closest_object].transform.position + ((transform.position - player_objects[closest_object].transform.position).normalized * maximum_dist);
        var positionDelta = targetPosition - transform.position;
        var newVelocity = positionDelta.normalized * speed;

        if (transform.rotation.eulerAngles.z > 80 && transform.rotation.eulerAngles.z < 180 && last_activation[0] == 0)
        {
            rotation_dir *= -1;
            last_activation[0] = 1;
            last_activation[1] = 0;
        }
        else if (transform.rotation.eulerAngles.z < 280 && transform.rotation.eulerAngles.z > 180 && last_activation[1] == 0)
        {
            rotation_dir *= -1;
            last_activation[0] = 0;
            last_activation[1] = 1;
        }

        if (positionDelta.magnitude < startLerpingDistance)
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.Lerp(Vector3.zero, newVelocity, positionDelta.magnitude / startLerpingDistance);
            transform.RotateAround(player_objects[closest_object].transform.position, Vector3.forward, rotation_dir * rot_speed * Time.deltaTime);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = newVelocity/10;
        }

        if (transform.position.y < player_objects[closest_object].transform.position.y)
        {
            GetComponent<Rigidbody2D>().velocity = player_objects[closest_object].GetComponent<Rigidbody2D>().velocity;
        }
        
    }

    void ShootyShoot()
    {
        last_shot += Time.deltaTime;
        if (last_shot > shotTimer)
        {
            var bull = Instantiate(bullet, transform.position + getPositionDiff(player_objects[closest_object]).normalized*transform.localScale.magnitude/2, transform.rotation);
            var velocity = getPositionDiff(player_objects[closest_object]).normalized * bull_speed;
            bull.GetComponent<Rigidbody2D>().velocity = velocity;
            last_shot = 0;
            GetComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/Bugman_move");
        }
        if (shotTimer - last_shot < 0.5)
        {
            GetComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/Bugman_shoot");
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
