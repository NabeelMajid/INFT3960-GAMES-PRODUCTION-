using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 4;
    [SerializeField] private float jumpforce = 7;
    [SerializeField] private AudioSource coin;
    private Rigidbody2D rb;
    public static Vector2 checkpoint;
    Animator animator;
    private void OnEnable()
    {
        KillPlayer.Death += DisableMovement;
    }
    private void OnDisable()
    {
        KillPlayer.Death -= DisableMovement;
    }
    private void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.Play("Player_idle");
        //EnableMovement();
    }
    private void Update()
    {
        var move = Input.GetAxis("Horizontal");

        transform.position += new Vector3(move, 0, 0) * Time.deltaTime * speed;
        if(move>0.1)
        {
            animator.Play("Move_right");
        }
        else if (move<0)
        {
            animator.Play("move_left");
        }
        else
        {
            animator.Play("Player_idle");
        }

        if(Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Checkpoint")
        {
            KillPlayer.respawnPoint = transform.position;
        }
        else if(collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            coin.Play();
        }
    }

    private void DisableMovement()
    {
        animator.enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
    }
    private void EnableMovement()
    {
        animator.enabled = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

}