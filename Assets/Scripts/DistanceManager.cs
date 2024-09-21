using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DistanceManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI distanceText;
    private int distance;
    private float second;

    // Start is called before the first frame update
    void Start()
    {
        distance = 0;
    }

    // Update is called once per frame
    void Update()
    {
        second += Time.deltaTime;
        if (second >= .1)
        {
            second = 0;
            distance += 10;
        }
        
        Debug.Log(distance);
        distanceText.text = "DISTANCE TRAVELED: " + distance.ToString() +" M";
    }
}
