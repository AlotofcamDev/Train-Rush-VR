using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float waveInterval;
    public float waveTimer;
    public int waveCounter;

    [Tooltip("Spawn numToSpawn[0] for the first wave, numToSpawn[1] for the second, etc...")]
    public int[] numToSpawn;

    public Transform spawnHere;
    public Transform leftMin;
    public Transform leftMax;
    public Transform rightMin;
    public Transform rightMax;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        waveTimer += Time.deltaTime;

        if (waveTimer >= waveInterval)
        {
            SpawnWave();
            waveCounter++;
            waveInterval *= 0.95f; // Slowly make waves appear quicker
            waveTimer = 0f;
        }
    }

    private void SpawnWave()
    {
        int clampedIndex = (int) Mathf.Clamp(waveCounter, 0, numToSpawn.Length - 1f);
        for (int i=0; i < numToSpawn[clampedIndex]; i++)
        {
            float forwardsOffset = Random.Range(-4f, 4f);

            Vector3 pos;
            bool coinFlipHeads = Random.Range(0, 2) == 0;
            if (coinFlipHeads)
            {
                pos = new Vector3(Random.Range(leftMin.position.x, leftMax.position.x), spawnHere.position.y, spawnHere.position.z + forwardsOffset);
            } else
            {
                pos = new Vector3(Random.Range(rightMin.position.x, rightMax.position.x), spawnHere.position.y, spawnHere.position.z + forwardsOffset);
            }
            Instantiate(enemyPrefab, pos, Quaternion.identity);
        }
    }
}
