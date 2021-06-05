using UnityEngine;

public class CameraManager : MonoBehaviour
{
     public static Transform Player;
     private Vector3 offset = new Vector3(0.072f,1.55f, -4.537f); 
     //6.29
     
    private void Update()
    {
        Player = PlayerManager.CurrentPlayer.transform;
        transform.position = new Vector3(Player.position.x, Player.position.y, Player.transform.position.z) + offset;
    }
}
