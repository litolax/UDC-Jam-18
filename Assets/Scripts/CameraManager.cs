using UnityEngine;

public class CameraManager : MonoBehaviour
{
     public static Transform Player;
     private Vector3 offset = new Vector3(0.072f,1.55f, -4.537f);
     private Vector3 posEnd, posSmoth;

     void Start()
     {
         Player = PlayerManager.CurrentPlayer.transform;
     }
    private void Update()
    {
        transform.position = new Vector3(Player.position.x, Player.position.y, Player.position.z) + offset;

        transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, transform.position.z), 
            new Vector3(transform.position.x, Player.transform.position.y+1.55f, transform.position.z), 0.0001f);
    }
}
