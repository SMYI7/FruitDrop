using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KILLZONE : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if(!collision.CompareTag(GameManger.Instance.CurrentTag))
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
