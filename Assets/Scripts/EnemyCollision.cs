using System;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            gameObject.transform.position = new Vector3(0.44f,10.44f,-6.77f);
        }
    }
}
