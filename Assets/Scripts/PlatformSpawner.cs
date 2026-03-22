using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject normalPlatform;
    public GameObject smallPlatform;

    public float spawnX = 40f;
    public float minInterval = 1.1f;
    public float maxInterval = 1.6f;
    public float smallPlatformChance = 0.2f;
    public int smallPlatformMinScore = 5;

    public float minY = -1.5f;
    public float maxY = 1.5f;
    public float maxHeightStep = 0.5f;

    private float lastY;
    private float spawnTimer;

    void Start()
    {
        lastY = 0f;
        SpawnInitialPlatforms();
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        float multiplier = GameManager.Instance.SpeedMultiplier;
        float interval = Random.Range(minInterval, maxInterval) / multiplier;

        if (spawnTimer >= interval)
        {
            spawnTimer = 0f;
            SpawnPlatform();
        }
    }

    void SpawnInitialPlatforms()
    {
        for (float x = 7f; x <= 35f; x += 7f)
        {
            float y = GetNextY();
            Instantiate(normalPlatform, new Vector3(x, y, 0f), Quaternion.identity);
        }
    }

    void SpawnPlatform()
    {
        float y = GetNextY();

        bool useSmall = smallPlatform != null
            && ScoreManager.Instance.GetScore() >= smallPlatformMinScore
            && Random.value < smallPlatformChance;

        if (useSmall)
        {
            Instantiate(smallPlatform, new Vector3(spawnX, y, 0f), Quaternion.identity);
        }
        else
        {
            Instantiate(normalPlatform, new Vector3(spawnX, y, 0f), Quaternion.identity);
        }
    }

    float GetNextY()
    {
        float delta = Random.Range(-maxHeightStep, maxHeightStep);
        lastY = Mathf.Clamp(lastY + delta, minY, maxY);
        return lastY;
    }
}
