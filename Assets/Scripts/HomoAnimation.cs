using UnityEngine;

public class HomoAnimation : MonoBehaviour
{
    public Mesh[] frames = new Mesh[2];
    //public Mesh[] framesJump = new Mesh[1];
    public float animationSpeed = .1f;
    public static bool jumpAnim = false, runAnim = true;
    private float animationStartTime;
    private int currentFrame;
    //private int currentFrame2;

    void Start()
    {
        currentFrame = 0;
       // currentFrame2 = 0;
        animationStartTime = Time.time;
        UpdateMesh();
    }

    void Update()
    {
        currentFrame = Mathf.FloorToInt((Time.time - animationStartTime) / animationSpeed);
        currentFrame = currentFrame % frames.Length;
      //  currentFrame2 = Mathf.FloorToInt((Time.time - animationStartTime) / animationSpeed);
       // currentFrame2 = currentFrame2 % framesJump.Length;
        UpdateMesh();
    }

    void UpdateMesh()
    {
        if (!Input.anyKey)
        {
            GetComponent<MeshFilter>().mesh = frames[0];
        }
        else if (PlayerManager._isGrounded && Input.anyKey)
        {
            GetComponent<MeshFilter>().mesh = frames[currentFrame];
        }
        else if (!PlayerManager._isGrounded)
        {
            GetComponent<MeshFilter>().mesh = frames[0];
        }
        
        /*if (runAnim)
        {
            GetComponent<MeshFilter>().mesh = frames[currentFrame];
        }
        else if (jumpAnim)
        {
            GetComponent<MeshFilter>().mesh = framesJump[currentFrame2];
        }*/
        
    }
}
