using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolveSquare : MonoBehaviour
{
    private PlayerMove playerMove;
    void Start()
    {
    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerMove = collision.gameObject.GetComponent<PlayerMove>();
            playerMove.player.GetComponent<Rigidbody2D>().constraints &= ~RigidbodyConstraints2D.FreezeRotation;
            Debug.Log("Colliding with player");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerMove = collision.gameObject.GetComponent<PlayerMove>();
            playerMove.player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            Debug.Log("Stopped colliding with player");
        }
    }
}
