using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class BasketScirpt : MonoBehaviour
{
    Vector2 inputPos;
    //[SerializeField]GameManger gameManger;
    [SerializeField] private float raduis;
    [SerializeField] private Vector3 offset;
    
    void Start()
    {
        Controls input = new Controls();
        input.Enable();
        input.Gameplay.inputPosition.performed += i => inputPos = i.ReadValue<Vector2>();
        //gameManger = GameManger.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManger.Instance.playerTries < 1)
            return;
        Vector2 mouseToCamera = Camera.main.ScreenToWorldPoint(inputPos);
        transform.position = new Vector3(mouseToCamera.x,transform.position.y ,0 );
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -7.39f, 5.26f), transform.position.y);
        Collider2D hitInfo = Physics2D.OverlapCircle(transform.position + offset, raduis);
        if (hitInfo != null)
        {
            if(hitInfo.CompareTag(GameManger.Instance.CurrentTag))
            {
                Destroy(hitInfo.gameObject);
                GameManger.Instance.collected.Play();
                GameManger.Instance.ChangeTag();
                GameManger.Instance.score += 10;
            }
            else if (!hitInfo.CompareTag(GameManger.Instance.CurrentTag) && !hitInfo.CompareTag("Ground") && !hitInfo.CompareTag("Player"))
            {
                GameManger.Instance.lost.Play();
                GameManger.Instance.playerTries--;
                Destroy(hitInfo.gameObject);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + offset, raduis);
    }
}
