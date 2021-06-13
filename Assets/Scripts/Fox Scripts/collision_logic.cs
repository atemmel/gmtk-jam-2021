using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision_logic : MonoBehaviour
{
    public GameObject explosionVfx;
    public int hp;

    public GameObject score_empty;
    public int hitScore;
    public int killScore;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > 20)
        {
            hp -= 3;
        }

        if (hp <= 0)
        {
            var effect = Instantiate(explosionVfx, transform.position, Quaternion.identity);
            AddScore(killScore);
            Destroy(effect, 0.5f);
            Destroy(gameObject);
        }
    }

    private void AddScore(int score)
    {
        var down_bound = Camera.main.ScreenToWorldPoint(Vector3.zero).y;
        var upper_bound = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, Camera.main.pixelHeight, 0.0f)).y;
        if (transform.position.y > down_bound && transform.position.y < upper_bound)
        {
            var add_score = Instantiate(score_empty, transform.position, Quaternion.identity);
            add_score.GetComponent<ScoreAdder>().value = score;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6) //playerBullet layer
        {
            hp -= 1;
            AddScore(hitScore);
            Destroy(collision.gameObject);
            var effect = Instantiate(explosionVfx, collision.transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
        }

        if (hp <= 0)
        {
            var effect = Instantiate(explosionVfx, transform.position, Quaternion.identity);
            AddScore(killScore);
            Destroy(effect, 0.5f);
            Destroy(gameObject);
        }
    }

}
