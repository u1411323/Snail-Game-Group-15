using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Class for managing the player's movement.
 * Player is only allowed to control up and down movement.
 * Player should be bound to be able to move in a certain reigon. 
 * 
 * @author Robbie DeMars
 * @date 9/20/24
 */
public class Movement : MonoBehaviour
{
    //Maximum height player can go.
    [SerializeField] float maxHeight = 100;
    //Minimum height player can go.
    [SerializeField] float minHeight = 0;
    //Speed at which player can move up and down.
    [SerializeField] float speed = 1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //W key for up, S key for down.
        if (Input.GetKey(KeyCode.W))
        {
            this.gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - speed * Time.deltaTime);
        }

        //Stop player from going above / below bounds as stated by min/max height.
        if (gameObject.transform.position.y > maxHeight)
        {
            this.gameObject.transform.position = new Vector2(gameObject.transform.position.x, maxHeight);
        }
        if (gameObject.transform.position.y < minHeight)
        {
            this.gameObject.transform.position = new Vector2(gameObject.transform.position.x, minHeight);
        }

    }
}
