using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    [SerializeField] GameObject[] shipBackgrounds;
    [SerializeField] GameObject[] BackgroundsTwo;
    [SerializeField] GameObject[] BackgroundsThree;
    [SerializeField] GameObject[] BackgroundsFour;
    GameObject secondMostRecent;
    GameObject firstMostRecent;

    [SerializeField] float scrollSpeed = 1;
    [SerializeField] Vector3 spawnPostion;
    [SerializeField] float deleteAfterReachedX;

    private int currentZone = 0;


    // Start is called before the first frame update
    void Start()
    {
        firstMostRecent = Instantiate(shipBackgrounds[0]);
        firstMostRecent.transform.position = new Vector3(spawnPostion.x - 100, spawnPostion.y, spawnPostion.z);
        secondMostRecent = addNewWall();
    }

    // Update is called once per frame
    void Update()
    {
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
        GameObject temp = Instantiate(shipBackgrounds[0]);
        temp.transform.position = spawnPostion;
        return temp;
    }
}
