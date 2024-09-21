using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLeft : MonoBehaviour
{
    [SerializeField] float maxLeft = 0;
    [SerializeField] float speed = 1;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x > maxLeft)
            this.transform.position = new Vector2(this.transform.position.x - speed * Time.deltaTime, this.transform.position.y);
        else
            Destroy(this.gameObject);
    }
}
