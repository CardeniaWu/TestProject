using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    public bool inTriggerArea = false;

    bool jump = false;
    bool crouch = false;

    public Text crateInteractText; 

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch")); 
        {
            crouch = false;
        }
    }

    private void FixedUpdate()
    {
        // Move our Character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
        Debug.Log(inTriggerArea);
        
        
          if (inTriggerArea == true)
        {
            crateInteractText.gameObject.SetActive(true);
        } 
        else { crateInteractText.gameObject.SetActive(false); } 

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player Entered trigger area.");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        inTriggerArea = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inTriggerArea = false;
    }
}
