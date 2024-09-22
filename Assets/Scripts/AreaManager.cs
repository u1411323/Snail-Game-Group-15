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
    GameObject secondMostRecent;
    GameObject firstMostRecent;

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
    }

    // Update is called once per frame
    void Update()
    {
        
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
            secondMostRecent.transform.position = new Vector2(secondMostRecent.transform.position.x - scrollSpeed * Time.deltaTime, secondMostRecent.transform.position.y);
        }
        if (firstMostRecent != null)
        {
            firstMostRecent.transform.position = new Vector2(firstMostRecent.transform.position.x - scrollSpeed * Time.deltaTime, firstMostRecent.transform.position.y);
            if (firstMostRecent.transform.position.x < deleteAfterReachedX)
            {
                Destroy(firstMostRecent);
                firstMostRecent = secondMostRecent;
                secondMostRecent = addNewWall();
            }
        }
    }


    GameObject addNewWall()
    {
        GameObject temp = null;

        if (currentZone == 0)
        {
            temp = Instantiate(shipBackgrounds[(int)(Random.value * shipBackgrounds.Length)]);
            temp.transform.position = new Vector3(firstMostRecent.transform.position.x + 100, firstMostRecent.transform.position.y, firstMostRecent.transform.position.z);
        }
        else if (currentZone == 1)
        {
            temp = Instantiate(BackgroundsTwo[(int)(Random.value * BackgroundsTwo.Length)]);
            temp.transform.position = new Vector3(firstMostRecent.transform.position.x + 100, firstMostRecent.transform.position.y, firstMostRecent.transform.position.z);
        }
        else if (currentZone == 2)
        {
            temp = Instantiate(BackgroundsThree[(int)(Random.value * BackgroundsThree.Length)]);
            temp.transform.position = new Vector3(firstMostRecent.transform.position.x + 100, firstMostRecent.transform.position.y, firstMostRecent.transform.position.z);
        }
        else if (currentZone == 3)
        {
            temp = Instantiate(BackgroundsFour[(int)(Random.value * BackgroundsFour.Length)]);
            temp.transform.position = new Vector3(firstMostRecent.transform.position.x + 100, firstMostRecent.transform.position.y, firstMostRecent.transform.position.z);
        }
        return temp;
    }


}
