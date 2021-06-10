using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCollision : MonoBehaviour
{
    public static bool isDead = false;
    private Rigidbody rigidbody;
    public GameObject Nimb;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        isDead = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (!isDead)
            {

                isDead = true;
                rigidbody.useGravity = false;
                rigidbody.isKinematic = true;
                rigidbody.freezeRotation = true;
                gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                    gameObject.transform.position.y + 1.5f, gameObject.transform.position.z);
                StartCoroutine(ReturnCoroutine());

                IEnumerator ReturnCoroutine()
                {
                    for (int i = 0; i < 150; i++)
                    {
                        gameObject.transform.eulerAngles += new Vector3(0f, 0f, 1.2f);
                        yield return new WaitForSeconds(0.0003f);
                    }

                    Nimb.SetActive(true);
                    for (int i = 0; i < 140; i++)
                    {
                        gameObject.transform.position += new Vector3(0f, +0.0095f, 0f);
                        yield return new WaitForSeconds(0.0003f);
                    }

                    yield return new WaitForSeconds(2f);
                    SceneManager.LoadScene("Game");
                }
               
            }
            else
            {
                
            }
        }
        else if (other.CompareTag("Finish"))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
