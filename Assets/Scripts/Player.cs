using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Rigidbody rig;
    public GameObject win;
    public GameObject lose;
    public GameObject hunter;
    public int guyCollected = 0;

    void Update()
    {
        Move();
    }
    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;
        Vector3 vel = new Vector3(x, rig.velocity.y, z);
        vel.Normalize();
        rig.velocity = vel * moveSpeed;
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Respawn"))
        {
            collision.gameObject.SetActive(false);
            guyCollected++;
        }
        else if (collision.gameObject.CompareTag("bird"))
        {
            lose.gameObject.SetActive(true);
            Debug.Log("die");
            Invoke("Reset", 3f);
        }
        if (guyCollected >= 3)
        {
            win.SetActive(true);
            hunter.SetActive(false);
        }
    }

    void Reset()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
