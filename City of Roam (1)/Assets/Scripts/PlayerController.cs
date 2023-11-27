using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float speedForce;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private float currentHealth;

    private Vector3 ApplyMove;

    [SerializeField]
    private Text scoreDisplay;

    private int score;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = 100;
        score = 0;
        scoreDisplay.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            ApplyMove += new Vector3(0, jumpForce, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            ApplyMove += new Vector3(-speedForce, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            ApplyMove += new Vector3(speedForce, 0, 0);
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(ApplyMove);
        ApplyMove = Vector3.zero;
    }

    public void TakeDamage(float health)
    {
        currentHealth -= health;
        if(health <0)
        {
            //game over function
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(10);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Score")
        {
            score += 10;
            scoreDisplay.text = score.ToString();
        }

        if (collision.tag == "Enemy")
        {
            TakeDamage(10);
        }
    }
}
