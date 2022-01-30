using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterMovement : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public float movementSpeed = 0.5f;

    private int randomDirection;
    private Vector2 movementDirection = new Vector2();
    private Vector2 downRight = Vector2.down + Vector2.right;
    private Vector2 downLeft = Vector2.down + Vector2.left;

    private Rigidbody2D rb;
    public bool isDraggin = false;

    public BoxCollider2D redShelveBoxCollider;
    public BoxCollider2D blueShelveBoxCollider;

    private BoxCollider2D boxCollider2d;

    [SerializeField]
    private AudioClip audioPickUp, audioDrop;
    private AudioSource audioSource;


    void Start()
    {
        boxCollider2d = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
        randomDirection = Random.Range(0, 3);

        if (randomDirection == 0) movementDirection = downLeft;
        if (randomDirection == 1) movementDirection = downRight;
        if (randomDirection == 2) movementDirection = Vector2.down;

        // dragDrop = GetComponent<DragDrop>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (isDraggin)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            //rb.isKinematic = true;
            transform.Translate(mousePosition);
        }
        else
        {
            // rb.isKinematic = false;
            transform.Translate(movementDirection * movementSpeed * Time.deltaTime, Space.World);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collisiono!");

        Vector2 inNormal = collision.contacts[0].normal;
        Vector2 newMovementDirection = Vector2.Reflect(movementDirection, inNormal);

        movementDirection = newMovementDirection;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //audioSource.PlayOneShot(audioPickUp);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        rb.isKinematic = false;
        isDraggin = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rb.isKinematic = true;
        isDraggin = true;
    }
}
