using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerBehaviour : MonoBehaviour
{
    public GameObject[] enemies;
    public float spawnInterval;
<<<<<<< Updated upstream
    //public GameObject enemy;
    public bool randomRotation;
=======
>>>>>>> Stashed changes

    float collectedTime = 0.0f;

    const float spawnOffsetX = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        collectedTime += Time.deltaTime;
        if (collectedTime > spawnInterval)
        {
            //Camera cam = Camera.main;
            //float height = 2f * cam.orthographicSize;
            //float width = height * cam.aspect;

            //float x = Random.Range(0.0f, 1.0f);
            float x = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(spawnOffsetX, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width - spawnOffsetX, 0)).x);

            var vec = new Vector3(x, transform.position.y, transform.position.z);

<<<<<<< Updated upstream
            //Instantiate(enemies[Random.Range(0, enemies.Length)], vec, Quaternion.identity);

            //Instantiate(enemy, vec, Quaternion.identity);
            int rand = Random.Range(0, enemies.Length);
            Debug.Log("rand: " + rand);
            Instantiate(enemies[rand], vec, randomRotation ? Quaternion.AngleAxis(Random.Range(0.0f, 360.0f), Vector3.forward) : Quaternion.identity);
=======
            Instantiate(enemies[Random.Range(0, enemies.Length)], vec, Quaternion.identity);
>>>>>>> Stashed changes
            collectedTime = 0.0f;
        }
    }
}
