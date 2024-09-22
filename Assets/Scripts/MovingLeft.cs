using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLeft : MonoBehaviour
{
    [SerializeField] float maxLeft = 0;
    [SerializeField] private float[] speed;
    private float speedValue;
    private DistanceManager dm;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("Man");
        dm = obj.GetComponent<DistanceManager>();
        speedValue = speed[dm.scalingIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x > maxLeft)
        {
            this.transform.position = new Vector2(this.transform.position.x - speedValue * Time.deltaTime, this.transform.position.y);
        }
        else
            Destroy(this.gameObject);
    }
}
