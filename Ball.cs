
using UnityEngine;

public class Ball : MonoBehaviour {
    [SerializeField] Paddle paddle1;
    [SerializeField] float x;
    [SerializeField] float y;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;
    bool hasStarted = false;

    //state
    Vector2 paddletoBallVector;
    //Cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;
    // Use this for initialization
    level level;
	void Start ()
    {
        paddletoBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        
           if (!hasStarted)
        {
            LockBallToPaddle();

            LaunchOnMouseClick();

       
        }     
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(x, y);
            
        }

    }

    private void LockBallToPaddle()
    {
      
        

            Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
            transform.position = paddletoBallVector + paddlePos;
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
            (Random.Range(0f, randomFactor), 
            Random.Range(0f, randomFactor));

        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
        }
    }
     public void Velocity()
    {
        y += 3;
        x += 5;
    }
}
