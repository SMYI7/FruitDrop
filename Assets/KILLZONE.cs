using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class KILLZONE : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if(!collision.CompareTag(GameManger.Instance.CurrentTag) && !collision.CompareTag("Ground") && !collision.CompareTag("Player"))
            {
                Destroy(collision.gameObject);
            }
            else if (collision.CompareTag(GameManger.Instance.CurrentTag) && !collision.CompareTag("Ground") && !collision.CompareTag("Player"))
            {
                GameManger.Instance.playerTries--;
                Destroy(collision.gameObject);
            }
            
        }
    }
}
