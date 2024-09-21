using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    double timeAtLastFrame = 0;
    double timeSinceLastSpawn = 0;
    GameObject lastSpawned = null;
    float heightRange = 0;

    // Start is called before the first frame update
    void Start()
    {
        heightRange = maxHeight - minHeight;
    }

    // Update is called once per frame
    void Update()
    {
        timeAtLastFrame = Time.timeAsDouble;
        if (timeAtLastFrame - timeSinceLastSpawn > cooldown && spawnables.Length != 0)
        {
            lastSpawned = Instantiate(spawnables[0]);
            lastSpawned.transform.position = new Vector2(this.transform.position.x, maxHeight - Random.value * heightRange);
            timeSinceLastSpawn = Time.timeAsDouble;
        }
    }
}
