using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DistanceManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI distanceText;
    [SerializeField] private float[] scaling;
    [SerializeField] private int[] milestones;
    private int distance;
    private float second;
    private int milestone;
    private int milestoneIndex;
    public int scalingIndex;
    private bool scaleChanged;
    private bool milestoneChanged;
    // Start is called before the first frame update
    void Start()
    {
        distance = 0;
        scalingIndex = 0;
        milestoneIndex = 0;
        milestone = milestones[milestoneIndex];
        scaleChanged = false;
        milestoneChanged = false;
    }

    // Update is called once per frame
    void Update()
    {
        second += Time.deltaTime;
        if (second >= scaling[scalingIndex])
        {
            second = 0;
            distance += 100;
        }

        if (distance == milestone)
        {
            if (milestoneIndex < milestones.Length - 1 && !milestoneChanged)
            {
                milestoneChanged = true;
                milestoneIndex += 1;
                milestone = milestones[milestoneIndex];
            }

            if (scalingIndex < scaling.Length - 1 && !scaleChanged)
            {
                scaleChanged = true;
                scalingIndex += 1;
            }

            milestoneChanged = false;
            scaleChanged = false;
        }

        distanceText.text = "DISTANCE TRAVELED: " + distance.ToString() +" M";
    }

    public float GetDifficultyScalar()
    {
        return scaling[scalingIndex];
    }

    public int GetDistance()
    {
        return distance;
    }
}
