using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class BasketScirpt : MonoBehaviour
{
    Vector2 inputPos;
    [SerializeField]GameManger gameManger;
    [SerializeField] private float raduis;
    void Start()
    {
        Controls input = new Controls();
        input.Enable();
        input.Gameplay.inputPosition.performed += i => inputPos = i.ReadValue<Vector2>();
        gameManger = GameManger.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseToCamera = Camera.main.ScreenToWorldPoint(inputPos);
        transform.position = new Vector3(mouseToCamera.x,transform.position.y ,0 );
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.38f, 2.33f), transform.position.y);
        Collider2D hitInfo = Physics2D.OverlapCircle(transform.position, raduis);
        if (hitInfo != null)
        {
            if(hitInfo.CompareTag(gameManger.CurrentTag))
            {
                Destroy(hitInfo.gameObject);
                gameManger.score += 100;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, raduis);
    }
}
