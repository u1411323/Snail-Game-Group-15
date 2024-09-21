using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SlowHorizontalRotation : MonoBehaviour
{

    [SerializeField] float speed = 1;
    private float rotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotation += Time.deltaTime * speed;
        
        if (rotation > 360)
            rotation = 0;

        this.transform.eulerAngles = new Vector3(0, -rotation, 0);
    }
}
