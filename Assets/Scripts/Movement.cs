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
    [SerializeField] float maxHeight = 3.9f;
    //Minimum height player can go.
    [SerializeField] float minHeight = -3.9f;
    //Max upward velocity
    [SerializeField] float maxUpwardVelocity = 1;
    //Max falling velocity
    [SerializeField] float maxDownwardVelocity = -1;
    //Speed at which player can move up and down.
    [SerializeField] float speed = 1;
    //Gravity on player. 
    [SerializeField] float gravity = 1;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            rb.velocity = new Vector2(0, rb.velocity.y + speed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.S))
            rb.velocity = new Vector2(0, rb.velocity.y - gravity * 2 * Time.deltaTime);
        else
            rb.velocity = new Vector2(0, rb.velocity.y - gravity * Time.deltaTime);

        //Lock the x position where it is desired onscreen. Temporarily set to 0.
        this.transform.position = new Vector2(0, this.transform.position.y);


        //Stop player from going above / below the speed limit.
        if (rb.velocity.y > maxUpwardVelocity)
        {
            rb.velocity = new Vector2(0, maxUpwardVelocity);
        }
        if (rb.velocity.y < maxDownwardVelocity)
        {
            rb.velocity = new Vector2(0, maxDownwardVelocity);
        }



        //Stop player from going above / below bounds as stated by min/max height.
        if (gameObject.transform.position.y > maxHeight)
        {
            this.gameObject.transform.position = new Vector2(gameObject.transform.position.x, maxHeight);
            rb.velocity = new Vector2(0, 0);
        }
        if (gameObject.transform.position.y < minHeight)
        {
            this.gameObject.transform.position = new Vector2(gameObject.transform.position.x, minHeight);
            rb.velocity = new Vector2(0, 0);
        }

    }
}
