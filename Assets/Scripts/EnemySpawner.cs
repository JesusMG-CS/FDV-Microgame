using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject asteroidPrefab;
    public float spawnRatePerMinute = 30f;
    public float spawnRateIncreasement = 1f;
    public float xlimit;

    private float spawnNext = 0;

    void Update()
    {
        if (Time.time > spawnNext)
        {
            spawnNext = Time.time + 60 / spawnRatePerMinute;

            spawnRatePerMinute += spawnRateIncreasement;

            float rand = Random.Range(-xlimit, xlimit);

            Vector3 spawnPosition = new Vector3(
                rand,
                26.54f,
                0f
            );

            Instantiate(
                asteroidPrefab,
                spawnPosition,
                Quaternion.identity
            );
        }
    }
}
