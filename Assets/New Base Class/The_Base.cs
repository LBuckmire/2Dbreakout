//  Liam Buckmire
//  Base Class
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class The_Base : MonoBehaviour
{

    #region Paddle Variables
    [SerializeField]
    protected float PadSpeed = 1f;
    [SerializeField]
    protected Vector3 PaddlePos = new Vector3 (0, -9.5f, 0);
    #endregion

    #region Brick Variables
    protected GameObject brickObj;
    #endregion

    #region Ball Variables
    [SerializeField]
    protected float Velocityball = 600f;
    private Rigidbody2D rb2d;
    private bool InPlayball;
    #endregion

    protected virtual void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>(); 
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        PaddMovement();
        BallMovement();
	}

    #region PaddleMovement
    protected virtual void PaddMovement()
    {
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * PadSpeed);
        PaddlePos = new Vector3(Mathf.Clamp(xPos, -8f, 8f), -9.5f, 0f);
        transform.position = PaddlePos;
    }
    #endregion

    #region Brick Collision
    protected virtual void OnCollisionEnter2D(Collision2D BrickColl)
    {
        Instantiate(brickObj, transform.position, Quaternion.identity);
        GM.instance.BrickDestroy();
        Destroy(gameObject);
    }
    #endregion

    #region BallMovement
    protected virtual void BallMovement()
    {
        if (Input.GetButtonDown("Fire1") && InPlayball == false)
        {
            transform.parent = null;
            InPlayball = true;
            rb2d.isKinematic = false;
            rb2d.AddForce(new Vector3(Velocityball, Velocityball, 0));
        }
    }
    #endregion

}
