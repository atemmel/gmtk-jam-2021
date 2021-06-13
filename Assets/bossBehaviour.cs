using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBehaviour : MonoBehaviour
{

    public float sideSpeed;
    public float downSpeed;
    public float bound;
    public float bossWith;
    public float timeBetweenShots;
    public GameObject bulletPrefab;
    public float bulletSpeed;

    Rigidbody2D _rigidbody2D;
    bool entered = false;
    float timeSinceLastShot;
    Vector2 dir;



    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.velocity = Vector2.down * downSpeed;
        timeSinceLastShot = timeBetweenShots;
        GetComponent<Collider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        var left_bound = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
        var right_bound = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x;
        var upper_bound = Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, 0)).y;

        Debug.Log("left_bound: " + left_bound);
        Debug.Log("right_bound: " + right_bound);
        Debug.Log("upper_bound: " + (upper_bound - GetComponent<CapsuleCollider2D>().bounds.extents.y));

        if (entered)
        {
            if (transform.position.x + GetComponent<CapsuleCollider2D>().bounds.extents.x > right_bound)
            {
                dir = Vector2.left;
            }
            if (transform.position.x - GetComponent<CapsuleCollider2D>().bounds.extents.x < left_bound)
            {
                dir = Vector2.right;
            }

            _rigidbody2D.velocity = dir * sideSpeed;

            timeSinceLastShot += Time.deltaTime;
            if (timeSinceLastShot > timeBetweenShots)
            {
                var bulletDown = Instantiate(bulletPrefab, transform.position, transform.rotation);
                bulletDown.GetComponent<Rigidbody2D>().velocity = Vector2.down * bulletSpeed;
                var bulletLeft = Instantiate(bulletPrefab, transform.position, transform.rotation);
                bulletLeft.GetComponent<Rigidbody2D>().velocity = (Vector2.down + Vector2.left).normalized * bulletSpeed;
                var bulletRight = Instantiate(bulletPrefab, transform.position, transform.rotation);
                bulletRight.GetComponent<Rigidbody2D>().velocity = (Vector2.down + Vector2.right).normalized * bulletSpeed;
                timeSinceLastShot = 0;
            }
        }
        else
        {
            _rigidbody2D.velocity = Vector2.down * downSpeed;
            if (transform.position.y < (upper_bound - GetComponent<CapsuleCollider2D>().size.y))
            {
                entered = true;
                GetComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/Angery_shoot");
                dir = Vector2.right;
                GetComponent<Collider2D>().enabled = true;
            }
        }
    }
}
