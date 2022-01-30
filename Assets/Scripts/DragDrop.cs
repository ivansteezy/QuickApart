using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private BoxCollider2D boxCollider2d;

    [SerializeField]
    private AudioClip audioPickUp, audioDrop;
    private AudioSource audioSource;

    public bool isDraggin = false;

    public BoxCollider2D redShelveBoxCollider;
    public BoxCollider2D blueShelveBoxCollider;


    void Start()
    {
        boxCollider2d = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        audioSource.PlayOneShot(audioPickUp);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDraggin = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        isDraggin = true;
    }
}
