using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public float CPHeight;      //used for testing the height the ball needs to be at for the charge pad
	public float crUp;

	//variables relating to android controls
	public GameObject AndroidJump;   // used for toggling left click jump based on whether the jump UI is visible
	public VirtualJoystick joystick; // used for Android joystick movement.

	public float speed;         //Speed the player is moving at.
	public float B_speed;       //B_speed and B_jumpSpeed are used to restore speed and jumpSpeed to there original values. 
	public float jumpSpeed;     //Intensity of player's jump.
	public float B_jumpSpeed;
	public string Scene;        //current scene.

	bool canJump;               //Bool used to stop the player from jumping in mid air
	bool charging;              //Used for the charge float value.
	bool onCharge;              //Bool for checking whether or not the player is on a charge pad.
	bool ChargeRIM;             //Checks if the released charge is "in motion" (time between Z release and ChargeRoutine ending).

	public float chargeDelay;   //How long after charge release until player can move again.
	private float charge;       //How much charge the player currently has.
	public float chargeMax;     //How much charge the player can have.
	public float chargeUp;      //Player's Charging Up rate.
	public float chargeDown;    //Player's Cooling Down rate.

	private int H_Move;         //Used to determine which way Horizontally the Charge Pad will move the player.
	private int V_Move;         //Used to determine which way Vertically the Charge Pad will move the player.

	public Transform quitMenu;  //Gets the Quitmenu canvas component 
	public Transform pausemenu;    //Gets the Pausemenu canvas component 
	public Button resume;       //Gets the Resume button component 
	public Button levelSelect;         //Gets the Exit button component 

	public AudioClip[] pu; //Get the Pick up sound component

	private Rigidbody rb;       //Player's RigidBody Component, used for movement and charge via adding force.
	private Vector3 CP;         //Used to lock the player to the Charge Pads centre on Z press.
	void Start()
	{
		PlayerManager.Get().stats.Green = 0; // resets values of pickups at start of new scene.
		PlayerManager.Get().stats.Yellow = 0;
		PlayerManager.Get().stats.Red = 0;

		rb = GetComponent<Rigidbody>(); //assign RigidBody component to rb Data Type.
		canJump = true;                 //true on start, so the player can jump from the get go.
		charging = false;               //false on start since player isn't charging.      
		onCharge = false;               //false on start since player isn't on charge pad.
		ChargeRIM = false;              //false on start since charge isn't in motion.
		charge = 0;
		CP =new Vector3(0, 0, 0);
	}

	// Using Update to avoid slowdown in FixedUpdate (Currently speculation)
	void Update()
	{
		/*if player isn't onCharge and Release isn't in motion, Speed stats stay at base value, 
		 *This is a contermeasure for a charge pad bug which causes charge to be exited and speed
		 *to be stuck on 0 [60-64].
		 */
		if (!onCharge && !ChargeRIM)
		{
			speed = B_speed;
			jumpSpeed = B_jumpSpeed;
		}
		//debugging
		if (Input.GetKeyDown(KeyCode.Alpha1))
			Time.timeScale = Time.timeScale - 0.1f;
		if (Input.GetKeyDown(KeyCode.Alpha2))
			Time.timeScale = Time.timeScale + 0.1f;

		/* uses chargeDown to lower the value of charge when not charging and
		 * sets lowest possible value of charge to 0 to avoid negative values [68-69]. 
		 */
		if (!charging) charge = charge - chargeDown; //Charge01
		if (charge <= 0) charge = 0;                 //Charge02
	}
	void FixedUpdate()
	{

		//float moveHorizontal = Input.GetAxis("Horizontal"); //MoveH
		//float moveVertical = Input.GetAxis("Vertical");     //MoveV

		float moveHorizontal = joystick.Horizontal(); //MoveH
		float moveVertical = joystick.Vertical();     //MoveV

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); //Move01

		rb.AddForce(movement * speed);                                      //Move02

		/* On 'cancel' input pressed (Mapped to 'Esc') Pause UI becomes Active and time scale becomes 0,
		 * causing everything to stop/pause, if it's already Active however than 'cancel' Deactivates
		 * the Pause UI and Time scale returns to 1 and gameplay continues [84-96]. 
		 */ 
		if (Input.GetButtonDown("Cancel")) // Pause01
		{
			if (pausemenu.gameObject.activeInHierarchy == false)
			{
				pausemenu.gameObject.SetActive(true);
				Time.timeScale = 0;
			}
			else
			{
				pausemenu.gameObject.SetActive(false);
				Time.timeScale = 1;
			}
		}
		/* checks if player pressed jump and if the canJump bool is restricting them,
		 * if not then AddForce is applied to the Y axis by the jumpSpeed value. canJump 
		 * is set to false so the player can't jump again. Can jump becomes true again
		 * when the player collides with the ground (which is tagged as 'Ground') [102-106].
		 */
		if (Input.GetButton("Jump") && canJump && AndroidJump.activeInHierarchy == (false)) //Jump01
		{
			//rb.AddForce(Vector3.up * jumpSpeed);//AddForce is inconsistent, velocity will be used for jump and charge instead.
			rb.velocity = (Vector3.up * jumpSpeed); // AF:V = 250:1.65 Ratio
			canJump = false;            //we have jumped so dont let us do it again in the air
		}
		/* checks if player is pressing 'Fire1' and is on a charge pad, if true then the
		 * player stops moving via speed values set to 0 and charge float rises
		 * until it reaches chargeMax or until the player releases 'Fire1' [111-119].
		*/ 
		if (Input.GetButton("Fire1") && onCharge) //Charge03
		{
			charging = true;
			speed = 0;
			jumpSpeed = 0;
			charge = charge + chargeUp;
			transform.position = CP + new Vector3 (0, CPHeight, 0);
			if (charge >= chargeMax) charge = chargeMax;
		}
		/*checks if player released 'Fire1' and is on charge pad, if true then AddForce is
		 * used to launch the player in a direction depending on the pad they're on. Charging
		 * is set to false to make the charge go down again and the ChargeRoutine is initiated.
		 * meaning the player can't move until the ChargeRoutine timer is done [125-131] ChargeRoutine [195-206].
		*/
		if (Input.GetButtonUp("Fire1") && onCharge) //Charge04
		{
			//rb.AddForce(new Vector3(charge * (10 * H_Move), -5, charge * (10 * V_Move)));
			rb.velocity = new Vector3(charge * H_Move, crUp, charge * V_Move);
			StartCoroutine(ChargeRoutine());
			charging = false;
		}
	}
	void OnTriggerEnter(Collider Other) //Pickups
	{
		/*All pick ups are created in the stats script and controlled by the player manager script
		 *other scripts such as doors will call on the player manager when using pick ups.
		 */
		/* pick up yellow item and add 1 to the stats counter through the PlayerManager, also deactivates pickup 
		 * and plays audio clip in 'pu' array that equals the current number of pickups had before collision 
		 * (e.g. pu[0] plays if player has picked up 0 yellow flags) same is applied to green pickups[141-146].
		 */
		if (Other.gameObject.CompareTag("Pickup Red"))
		{
			AudioSource.PlayClipAtPoint(pu[PlayerManager.Get().stats.Red], Camera.main.transform.position);
			Other.gameObject.SetActive(false);
			PlayerManager.Get().stats.Red += 1;
		}
		if (Other.gameObject.CompareTag("Pickup Yellow"))
		{
			AudioSource.PlayClipAtPoint(pu[PlayerManager.Get().stats.Yellow], Camera.main.transform.position);
			Other.gameObject.SetActive(false);
			PlayerManager.Get().stats.Yellow += 1;
		}

		if (Other.gameObject.CompareTag ("Pickup Green")) 
		{
			AudioSource.PlayClipAtPoint(pu[PlayerManager.Get().stats.Green], Camera.main.transform.position);
			Other.gameObject.SetActive(false);
			PlayerManager.Get().stats.Green += 1;
		}
		//used to restart level once player falls in pit.
		if (Other.gameObject.CompareTag ("Respawn"))
		{
			SceneManager.LoadScene(Scene);
		}

	}
	void OnTriggerStay (Collider Other)
	{
		/* used for a constant wind effect from the fans in World 4, different tags are for different
		 * directions. If possible, change this to rely only on 1 tag and use the rotation of the fan 
		 * instead for executing different directions (same for chargepads) [173-189].
		*/
		if (Other.gameObject.CompareTag("Wind")) //WindLeft
		{
			rb.AddForce(new Vector3(-500, 0, 0));
		}
		if (Other.gameObject.CompareTag("WindUp"))
		{
			rb.AddForce(new Vector3(0, 500, 0));
		}
		if (Other.gameObject.CompareTag("WindForward"))
		{
			rb.AddForce(new Vector3(0, 0, 1000));
		}
		if (Other.gameObject.CompareTag("WindRight"))
		{
			rb.AddForce(new Vector3(300, 0, 0));
		}
	}
	//checks if player touching an object via collision.
	void OnCollisionEnter(Collision Other)
	{
		/*Charge pads shoot in different directions based on there tags, once
		 * the Pad has been identified different values are applied to the H_Move
		 * and V_Move ints to move the player in their assigned direction.
		 * H_Move: -1 = left, 0 = N/A, 1 = Right.
		 * V_Move: -1 = Back, 0 = N/A, 1 = Forward.
		 * onCharge is also set to true to enable the charge to initiate on 'Z' press. [201-227]
		*/

		if (Other.gameObject.CompareTag("Charge Pad Up")) //ChargePad01
		{
			onCharge = true;
			H_Move = 0;
			V_Move = 1;
			CP = Other.gameObject.transform.position;
		}
		if (Other.gameObject.CompareTag("Charge Pad Down")) //ChargePad02
		{
			onCharge = true;
			H_Move = 0;
			V_Move = -1;
			CP = Other.gameObject.transform.position;
		}
		if (Other.gameObject.CompareTag("Charge Pad Left")) //ChargePad03
		{
			onCharge = true;
			H_Move = -1;
			V_Move = 0;
			CP = Other.gameObject.transform.position;
		}
		if (Other.gameObject.CompareTag("Charge Pad Right")) //ChargePad04
		{
			onCharge = true;
			H_Move = 1;
			V_Move = 0;
			CP = Other.gameObject.transform.position;
		}
		// Used for returning jump on collision with 'Ground' tagged objects [230-233].
		if (Other.gameObject.CompareTag("Ground"))
		{
			canJump = true;
		}
	}
	void OnCollisionExit(Collision Other)
	{
		//Upon leaving the Pad onCharge is set back to false.
		if (Other.gameObject.tag.Contains("Charge Pad")) //ChargePad05
		{
			onCharge = false;
			CP =new Vector3(0, 0, 0);
		}
	}

	/* UI Buttons call upon these 'voids' when they are clicked, the Resume and Level Select Buttons are prompted
	 * via the 'Cancel' input while the 'Yes' and 'No' buttons are prompted on Level select being clicked [248-271].
	 */
	public void resumeback()    //Unpauses the game when Resume button is pressed, alternative to input 'cancel'.
	{
		pausemenu.gameObject.SetActive(false);
		Time.timeScale = 1;
	}

	public void LevelSelectPress() //activates 'Are you sure?' UI and disables resume and Level select.
	{
		quitMenu.gameObject.SetActive(true);
		resume.enabled = false;
		levelSelect.enabled = false;
	}

	public void NoPress() //If No is selected for 'Are you sure?' UI, said UI is deactivated and previous buttons are re-enabled.
	{
		quitMenu.gameObject.SetActive(false);
		resume.enabled = true;
		levelSelect.enabled = true;
	}
	public void YesPress()  //if Yes is selected, 'LevelSelect' Scene is loaded and timescale is set back to 1.
	{
		SceneManager.LoadScene("LevelSelect");
		Time.timeScale = 1;
	}
	public void OnJump_Clicked()
	{
		if (canJump)
		{
			//rb.AddForce(Vector3.up * jumpSpeed);//AddForce is inconsistent, velocity will be used for jump and charge instead.
			rb.velocity = (Vector3.up * jumpSpeed); // AF:V = 250:1.65 Ratio
			canJump = false;                        //we have jumped so dont let us do it again in the air
		}
	}
	public void OnCharge_Clicked()
	{
		if (onCharge)
		{
			charging = true;
			speed = 0;
			jumpSpeed = 0;
			charge = charge + chargeUp;
			transform.position = CP + new Vector3(0, CPHeight, 0);
			if (charge >= chargeMax) charge = chargeMax;

			//rb.AddForce(new Vector3(charge * (10 * H_Move), -5, charge * (10 * V_Move)));
			rb.velocity = new Vector3(charge * H_Move, crUp, charge * V_Move);
			StartCoroutine(ChargeRoutine());
			charging = false;
		}
	}
	public void OnPause_Clicked()
	{
		if (pausemenu.gameObject.activeInHierarchy == false)
		{
			pausemenu.gameObject.SetActive(true);
			Time.timeScale = 0;
		}
		else
		{
			pausemenu.gameObject.SetActive(false);
			Time.timeScale = 1;
		}
	}
	//this co-routine dictates when the player can move again after using the charge [273-284].
	private IEnumerator ChargeRoutine()
	{
		yield return new WaitForSeconds(chargeDelay); //how long until the player can move again.
		//all movement is given back to the player.
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		rb.AddForce(movement * speed);
		//backup floats are used for restoring previous values.
		speed = B_speed;
		jumpSpeed = B_jumpSpeed;
	}
}