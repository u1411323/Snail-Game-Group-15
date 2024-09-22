using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    [SerializeField] SaveData area1;
    [SerializeField] SaveData area2;
    [SerializeField] SaveData area3;
    [SerializeField] SaveData area4;
    [SerializeField] SaveData man;
    [SerializeField] AreaManager areaManager;

    [SerializeField] TextMeshProUGUI loreCounter;
    [SerializeField] Image heart1;
    [SerializeField] Image heart2;
    [SerializeField] Image heart3;
    [SerializeField] Sprite emptyHeart;

    private int loreCollected = 0;

    float desiredPositionX = 0;
    // Start is called before the first frame update
    void Start()
    {
        desiredPositionX = xPositionAtEachHP[HP - 1];
        loreCollected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= xPositionAtEachHP.Length)
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(xPositionAtEachHP[HP - 1], this.gameObject.transform.position.y), speedBetweenXPoints * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && HP <= 1)
        {
            SceneManager.LoadScene(2); // Lose Screen
        }
        else if (collision.gameObject.CompareTag("Enemy") && HP > 1)
        {
            HP--;

            if (HP == 2)
            {
                heart3.sprite = emptyHeart;
            }

            if (HP == 1)
            {
                heart2.sprite = emptyHeart;
            }

            if (HP == 0)
            {
                heart1.sprite = emptyHeart;
            }
        }
        if (collision.gameObject.CompareTag("Fire") && HP > 1)
        {
            SceneManager.LoadScene(2); // Lose Screen
        }
        if (collision.gameObject.CompareTag("Lore"))
        {
            loreCollected++;
            loreCounter.text = "Lore Collected: " + loreCollected;

            if (areaManager.currentZone == 0 && area1.pagesCollected < 6)
            {
                area1.pagesCollected++;
            }
            else if (areaManager.currentZone == 1 && area2.pagesCollected < 6)
            {
                area2.pagesCollected++;
            }
            else if (areaManager.currentZone == 2 && area3.pagesCollected < 6)
            {
                area3.pagesCollected++;
            }
            else if (areaManager.currentZone == 3 && area4.pagesCollected < 6)
            {
                area4.pagesCollected++;
            }
            else if (man.pagesCollected < 11){
                man.pagesCollected++;
            }
            Destroy(collision.gameObject);
        }
    }

    public int GetLoreCollected()
    {
        return loreCollected;
    }

}
