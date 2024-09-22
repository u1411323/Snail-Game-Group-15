using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    //HP of player
    [SerializeField] int HP = 3;
    //X position the player should be at at each HP level (array positions will be accessed by hp - 1 as 0 is game over)
    [SerializeField] float[] xPositionAtEachHP;
    //Cooldown between when player can be hurt.
    [SerializeField] float hurtCooldown = 2;
    //The speed at which the player will move between HP points
    [SerializeField] float speedBetweenXPoints = 5;

    float desiredPositionX = 0;
    // Start is called before the first frame update
    void Start()
    {
        desiredPositionX = xPositionAtEachHP[HP - 1];
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= xPositionAtEachHP.Length)
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(xPositionAtEachHP[HP - 1], this.gameObject.transform.position.y), speedBetweenXPoints * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && HP >= 1)
        {
            HP--;
        }
        if (collision.gameObject.CompareTag("Fire") && HP > 1)
        {
            HP = 0;
        }
        if (HP <= 0)
        {
            SceneManager.LoadScene(2); // Lose Screen
        }
    }

}
