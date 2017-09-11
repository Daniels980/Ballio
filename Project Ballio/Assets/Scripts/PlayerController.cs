using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    bool canJump;
	private float jumpDelay;


    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

		//this is used to control jumping so the player can not infinite jump
		canJump = true;
		jumpDelay = 0.7f;

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

		//if jump (in-built to be space) is pressed and the bool allows it, jump!
		if (Input.GetButton("Jump") && canJump)
        {
            rb.AddForce(Vector3.up * jumpSpeed);
			//we have jumped so dont let us do it again in the air
			canJump = false;
			//start a co routine to dictate when to turn jump back on
			StartCoroutine(JumpRoutine());
        }

    }
    
    void OnTriggerEnter(Collider other)
    {
        //pick up yellow item and add 1 to the stats counter through the PlayerManager
		if (other.gameObject.CompareTag("Pickup Yellow"))
          {
			PlayerManager.Get().stats.Yellow += 1;
			other.gameObject.SetActive(false);
          }

		//pick up green item and add 1 to counter
		if (other.gameObject.CompareTag ("Pickup Green")) 
		{
			PlayerManager.Get().stats.Green += 1;
			other.gameObject.SetActive(false);
		}

		//pick up the END item and win the game
		if (other.gameObject.CompareTag ("Pickup End")) 
		{
			//setting the timer to freeze, to be displayed at the end
			PlayerManager.Get ().stats.TimeFreeze = true;
			//load the Win scene due to finish condition being met
			SceneManager.LoadScene("WinScene");
		}

    }

	//this co-routine dictates when the jump mechanic is turned back on
	private IEnumerator JumpRoutine()
	{
		yield return new WaitForSeconds (jumpDelay);

		canJump = true;
	}
    
}
