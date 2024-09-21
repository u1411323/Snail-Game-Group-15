using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPosition : MonoBehaviour
{
    public float x;
    public float y;
    public bool unlocked = false;
    // Start is called before the first frame update
    void Start()
    {
        x = this.gameObject.transform.position.x;
        y = this.gameObject .transform.position.y;
    }
}
