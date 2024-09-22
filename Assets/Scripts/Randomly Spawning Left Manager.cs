using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

/**
 * This script manages the spawning of objects such as platforms and enemies
 * from the spawnables array and within the given max / min heights
 * 
 * @author Robbie DeMars
 * @date 9/20/24
 */


public class RandomlySpawningLeftManager : MonoBehaviour
{

    [SerializeField] GameObject[] spawnables;
    [SerializeField] float maxHeight = 3.9f;
    [SerializeField] float minHeight = -3.9f;
    [SerializeField] float cooldown = 0.5f;
    [SerializeField] DistanceManager distanceManager;
    [SerializeField] PlayerHP playerHP;
    double timeAtLastFrame = 0;
    double timeSinceLastSpawn = 0;
    GameObject lastSpawned = null;
    float heightRange = 0;
    bool spawnedLore = false;

    // Start is called before the first frame update
    void Start()
    {
        heightRange = maxHeight - minHeight;
    }

    // Update is called once per frame
    void Update()
    {
        timeAtLastFrame = Time.timeAsDouble;
        if (distanceManager.GetDistanceIncrease() && distanceManager.GetDistance() >= 500 
            && distanceManager.GetDistance() % 500 == 0 && playerHP.GetLoreCollected() < 30) 
        {
            lastSpawned = Instantiate(spawnables[0]);
            lastSpawned.transform.position = new Vector2(this.transform.position.x, maxHeight - Random.value * heightRange);
            distanceManager.SetDistanceIncrease(false);
        }

        if (timeAtLastFrame - timeSinceLastSpawn > cooldown * distanceManager.GetDifficultyScalar() && spawnables.Length != 0)
        {
            int value = (int) Random.Range(1, spawnables.Length);
            lastSpawned = Instantiate(spawnables[value]);


            if (value == 1) 
            {
                lastSpawned.transform.position = new Vector2(this.transform.position.x, (maxHeight - 1.4f) - Random.value * heightRange);
            }
            else
            {
                lastSpawned.transform.position = new Vector2(this.transform.position.x, maxHeight - Random.value * heightRange);
            }
            
            timeSinceLastSpawn = Time.timeAsDouble;
        }
    }
}