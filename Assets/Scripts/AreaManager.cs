using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    [SerializeField] GameObject[] shipBackgrounds;
    [SerializeField] GameObject[] BackgroundsTwo;
    [SerializeField] GameObject[] BackgroundsThree;
    [SerializeField] GameObject[] BackgroundsFour;

    [SerializeField] GameObject[] Backgrounds;

    GameObject secondMostRecent;
    GameObject firstMostRecent;
    GameObject background1;
    GameObject background2;


    [SerializeField] AudioSource area1Music;
    [SerializeField] AudioSource area2Music;
    [SerializeField] AudioSource area3Music;
    [SerializeField] AudioSource area4Music;

    [SerializeField] float timeBetweenAreas;
    float timeSinceAreaChange = 0;
    
    [SerializeField] float scrollSpeed = 1;
    [SerializeField] Vector3 spawnPostion;
    [SerializeField] float deleteAfterReachedX;

    public int currentZone = 0;


    // Start is called before the first frame update
    void Start()
    {
        firstMostRecent = Instantiate(shipBackgrounds[0]);
        firstMostRecent.transform.position = spawnPostion;
        secondMostRecent = addNewWall();
        timeSinceAreaChange = Time.time;

        background1 = Instantiate(Backgrounds[0]);
        background1.transform.position = new Vector3(spawnPostion.x, spawnPostion.y, spawnPostion.z + 0.1f);
        background2 = Instantiate(Backgrounds[0]);
        background2.transform.position = new Vector3(spawnPostion.x + 100, spawnPostion.y, spawnPostion.z + 0.1f); ;

        area1Music.mute = false;
        area2Music.mute = true;
        area3Music.mute = true;
        area4Music.mute = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(background1.transform.position.z + "HERE");
        //Check to see if area changes
        if (Time.time - timeSinceAreaChange > timeBetweenAreas)
        {
            currentZone++;
            Debug.Log(currentZone);
            if (currentZone >= 4)
                currentZone = 0;
            timeSinceAreaChange = Time.time;
        }

        if (secondMostRecent != null)
        {
            secondMostRecent.transform.position = new Vector3(secondMostRecent.transform.position.x - scrollSpeed * Time.deltaTime, secondMostRecent.transform.position.y, secondMostRecent.transform.position.z);
        }
        if (firstMostRecent != null)
        {
            firstMostRecent.transform.position = new Vector3(firstMostRecent.transform.position.x - scrollSpeed * Time.deltaTime, firstMostRecent.transform.position.y, firstMostRecent.transform.position.z);
            if (firstMostRecent.transform.position.x < deleteAfterReachedX)
            {
                Destroy(firstMostRecent);
                firstMostRecent = secondMostRecent;
                secondMostRecent = addNewWall();
            }
        }

        //Move backgrounds
        background1.transform.position = new Vector3(background1.transform.position.x - scrollSpeed * 1.1f * Time.deltaTime, background1.transform.position.y, spawnPostion.z + 0.1f);
        background2.transform.position = new Vector3(background2.transform.position.x - scrollSpeed * 1.1f * Time.deltaTime, background2.transform.position.y, spawnPostion.z + 0.1f);

        if (background1.transform.position.x < deleteAfterReachedX)
        {
            //Make new Background
            Destroy(background1);
            background1 = background2;
            background2 = Instantiate(Backgrounds[currentZone]);
            background2.transform.position = new Vector3(background1.transform.position.x + 100, background1.transform.position.y, spawnPostion.z + 0.1f);
        }
    }


    GameObject addNewWall()
    {
        GameObject temp = null;

        if (currentZone == 0)
        {
            temp = Instantiate(shipBackgrounds[(int)(Random.value * shipBackgrounds.Length)]);
            temp.transform.position = new Vector3(firstMostRecent.transform.position.x + 100, firstMostRecent.transform.position.y, firstMostRecent.transform.position.z);
            area1Music.mute = false;
            area2Music.mute = true;
            area3Music.mute = true;
            area4Music.mute = true;
        }
        else if (currentZone == 1)
        {
            temp = Instantiate(BackgroundsTwo[(int)(Random.value * BackgroundsTwo.Length)]);
            temp.transform.position = new Vector3(firstMostRecent.transform.position.x + 100, firstMostRecent.transform.position.y, firstMostRecent.transform.position.z);
            area1Music.mute = true;
            area2Music.mute = false;
            area3Music.mute = true;
            area4Music.mute = true;
        }
        else if (currentZone == 2)
        {
            temp = Instantiate(BackgroundsThree[(int)(Random.value * BackgroundsThree.Length)]);
            temp.transform.position = new Vector3(firstMostRecent.transform.position.x + 100, firstMostRecent.transform.position.y, firstMostRecent.transform.position.z);
            area1Music.mute = true;
            area2Music.mute = true;
            area3Music.mute = false;
            area4Music.mute = true;
        }
        else if (currentZone == 3)
        {
            temp = Instantiate(BackgroundsFour[(int)(Random.value * BackgroundsFour.Length)]);
            temp.transform.position = new Vector3(firstMostRecent.transform.position.x + 100, firstMostRecent.transform.position.y, firstMostRecent.transform.position.z);
            area1Music.mute = true;
            area2Music.mute = true;
            area3Music.mute = true;
            area4Music.mute = false;
        }
        return temp;
    }


}
