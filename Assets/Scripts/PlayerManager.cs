using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static GameObject CurrentPlayer;
    public static bool _isGrounded;
    public static Rigidbody rigidbody;
    public static float SessionSpeed;
    public static Vector3 movement;
    public static float jumpForce = 3f;
    private Quaternion rot;
    private float Cooldown = 0.3f;
    private float timer;
    //timer < 0.0f
    //timer = Cooldown;
    //timer -= Time.deltaTime;

    private void Awake()
    {
        SessionSpeed = 5;
        
    }

    private void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        CurrentPlayer = this.gameObject;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            Movement();
            if (gameObject.transform.position.y == 270)
            {
                gameObject.transform.rotation = Quaternion.Euler(0f,90f,0f);
            }
            else
            {
                gameObject.transform.rotation = Quaternion.Euler(0f,90f,0f);
            }
            
        }

        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.transform.Translate(new Vector3(0f,0f,1f)*SessionSpeed/100);
            if (gameObject.transform.position.y == 90)
            {
                gameObject.transform.rotation = Quaternion.Euler(0f,270f,0f);
            }
            else
            {
                gameObject.transform.rotation = Quaternion.Euler(0f,270f,0f);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpate(collision, true);
    }

    private void OnCollisionExit(Collision collision)
    {
        IsGroundedUpate(collision, false);
    }

    private void OnCollisionStay(Collision collision)
    {
        IsGroundedUpate(collision, true);
    }


    public static void Movement()
    {
        SessionSpeed += Time.deltaTime / 14;
        movement = new Vector3(0f, 0f, 1f);
        rigidbody.transform.Translate(movement*SessionSpeed/100);
    }

    private void IsGroundedUpate(Collision collision, bool value)
    {
        if (collision.gameObject.tag == "Ground") _isGrounded = value;
    }
}
