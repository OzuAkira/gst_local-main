using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nw : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy_bullet"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
