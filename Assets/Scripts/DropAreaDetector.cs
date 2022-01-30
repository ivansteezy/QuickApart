using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DropAreaDetector : MonoBehaviour
{
    public BoxCollider2D m_Collider;
    public GameObject[] characters;

    void Start()
    {
        m_Collider = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        col.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        col.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
    }

    IEnumerator WipeIfInside()
    {
        characters = FindObjectsOfType<CharacterMovement>().Select((e) => { return e.gameObject; }).ToArray();
        foreach (var character in characters)
        {
            var characterCollider = character.GetComponent<BoxCollider2D>();
            if (characterCollider)
            {
                //If the first GameObject's Bounds enters the second GameObject's Bounds, output the message
                Collider2D[] overlap = Physics2D.OverlapAreaAll(characterCollider.bounds.min, characterCollider.bounds.max);
                if (overlap.Length > 1 && Input.GetMouseButtonUp(0))
                {
                    Debug.Log(this.gameObject.tag);
                    Destroy(overlap.FirstOrDefault().gameObject);
                }
            }
        }
        yield return new WaitForSeconds(0.4f);
    }

    void Update()
    {
        Debug.Log(this.gameObject.tag);
        StartCoroutine(WipeIfInside());
    }
}
