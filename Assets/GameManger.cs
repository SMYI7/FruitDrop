using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public float score;
    public string CurrentTag;
    public string[] tags;
    void Start()
    {
       StartCoroutine(ChangeTag());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ChangeTag()
    {
        while (true) 
        {
            yield return new WaitForSeconds(Random.Range(0.1f,2f));
            CurrentTag = tags[Random.Range(0, tags.Length - 1)];
        } 

    }
}
