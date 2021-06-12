using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerBehaviour : MonoBehaviour
{
	public GameObject enemy;
	public float spawnInterval;

	float collectedTime = 0.0f;

	const float spawnOffsetX = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
		collectedTime += Time.deltaTime;
		if(collectedTime > spawnInterval) {
			//Camera cam = Camera.main;
			//float height = 2f * cam.orthographicSize;
			//float width = height * cam.aspect;

			//float x = Random.Range(0.0f, 1.0f);
			float x = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(spawnOffsetX, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width - spawnOffsetX, 0)).x);

			var vec = new Vector3(x, transform.position.y, transform.position.z);

			Instantiate(enemy, vec, Quaternion.identity);
			collectedTime = 0.0f;
		}
    }
}
