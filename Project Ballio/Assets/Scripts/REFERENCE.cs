using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class REFERENCE : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    bool canJump;


    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //this is used to control jumping so the player can not infinite jump
        canJump = true;

    }

    void FixedUpdate()
    {
        //if jump (in-built to be space) is pressed and the bool allows it, jump!
        if (Input.GetButton("Jump") && canJump)
        {
            rb.AddForce(Vector3.up * jumpSpeed);
            //we have jumped so dont let us do it again in the air
            canJump = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }
}