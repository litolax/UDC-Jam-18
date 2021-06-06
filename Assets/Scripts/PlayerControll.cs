using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    private float Cooldown = 0.5f;
    private float timer;
    void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && PlayerManager._isGrounded && timer < 0.0f)
        {
            PlayerManager.rigidbody.AddForce(Vector3.up * (PlayerManager.jumpForce*2.4f), ForceMode.VelocityChange);
            timer = Cooldown;
        }
    }
}
