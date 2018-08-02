using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Bottle : MonoBehaviour
{
    //Reference variable if the Games isPaused;
    public static bool GameIsPaused;

    //Reference of the SpecialCredits Panel
    public GameObject SpecialPanel;

    //Reference of the PausePanel
    public GameObject PausePanel; 

	public GameObject bottleWater; 
	//..rigibody para mover la botella.
	public Rigidbody rb; 

	//testing
	private float initial; 

	//..Para el addForce.. float
	public float force = 5f;

	//..Para la rotacion del Botella..
	public float torque = 18.0f;
	//..Time..airTime
	private float timeWhenWeStartedFlying;

	//..Referencia del swipe
	private Vector2 swipePosition;
	private Vector2 endSwipe;


	[Header ("Screen Resolutions Settings")]
	private int Height = 600;
	private int width =1024;
	private int refreshRate = 30;
	private bool fullScreen = true;

	// Use this for initialization
	void Start ()
	{
        //Initial value, the game is not paused
        GameIsPaused = false;

        PausePanel.SetActive(false);
        SpecialPanel.SetActive(false);

		initial = Time.time;
		

		//Iphone & Android Resolutions..(Testing)
		#if UNITY_ANDROID || UNITY_IPHONE
		Screen.SetResolution(width, Height, fullScreen, refreshRate);
		#endif



		rb.GetComponent<Rigidbody> ();
		rb.isKinematic = false; 

	}
	
	// Update is called once per frame
	void Update ()
	{
		//..Si aprieto el mouse izquierdo..
		if(Input.GetMouseButtonDown(0))
		{
			//..Camera.main.ScreenToViewportPoint(Input.mousePosition)
			//..Donde apriete es mi posicion reference..
			//..Usando Camera.main.ScreenToViewportPoint, screenplay to viewport point
			//..it goes from 0 to 1, that's the force.. asi no es tan fuerte..
			swipePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
		}

		if (Input.GetMouseButtonUp (0)) 
		{
			endSwipe = Camera.main.ScreenToViewportPoint(Input.mousePosition);

			//..Executing swipe, Swipe Method..
			//..Swipp
			Debug.Log("Swipeee");
			Swipe();
		}

		//..Restarting the level, if the bottle goes below -0
		//bottleFalling ();

	}

	void Swipe()
	{
		rb.isKinematic = false; 

		//..Variable almacena el tiempo desde el comienzo del juego..
		timeWhenWeStartedFlying = Time.time;

		Vector2 swipe = endSwipe - swipePosition;

		//..Añadiendo la force al Rigid
		rb.AddForce(swipe * force, ForceMode.Impulse);

		//..Putting rotation on the bottle..
		rb.AddTorque(0f,0f, torque, ForceMode.Impulse);
	}

	//..Collider que tiene triggered
	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "OfficeCollider" && initial > 2.0f) 
		{
			//..Entro
			Debug.Log ("Entro");
			//..Esto freeza la posicion, rotacion.. 
			rb.isKinematic = true;

			//When the bottle lands on the right place..
			//FindObjectOfType<AudioManager> ().Play ("Alright");
            //Saving Score
            FindObjectOfType<ScoreSystem>().savingScore();
		} 
        	
	}


	void OnCollisionEnter()
	{
		//..Verificando que alla pasando un tiempo, before we start colliding.. 
		float timeInAir = Time.time - timeWhenWeStartedFlying; 

		//..Si no es cierto..
		if (!rb.isKinematic && timeInAir >= .2f) 
		{
	        FindObjectOfType<AudioManager>().Play("Noo");
			//..Restart level
			Restart();
		}
	}

	//..Restarting level..
	void Restart()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}

	void bottleFalling()
	{
		if (bottleWater.transform.position.y <= -1.0f) 
		{
			FindObjectOfType<AudioManager> ().Play ("Noo");
			Restart (); 
		}
	}

    //Quitting Game
    public void QuittingGame ()
    {
        Application.Quit();
    }
}
