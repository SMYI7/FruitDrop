using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public float score;
    public string CurrentTag;
    public string[] tags;
    public GameObject[] fruits;
    public GameObject[] UIfruits;
    public static GameManger Instance;
    [SerializeField] private Transform minRandomzier;
    [SerializeField] private Transform maxRandomzier;
    [SerializeField] private float delay;
    [SerializeField]private float currentTimer;
    void Start()
    {
       StartCoroutine(ChangeTag());
        Instance = this;
        currentTimer = delay;
        StartCoroutine(SpawnFruit());
        CurrentTag = tags[Random.Range(0, tags.Length - 1)];
        for (int j = 0; j < tags.Length; j++)
        {
            UIfruits[j] = GameObject.FindGameObjectWithTag(tags[j]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTimer -= Time.deltaTime;
        float xRandomize = Random.Range(minRandomzier.position.x, maxRandomzier.position.x);
        float yRandomize = Random.Range(minRandomzier.position.y, maxRandomzier.position.y);
        Vector2 randomizer = new Vector2(xRandomize, yRandomize);

     }
    IEnumerator ChangeTag()
    {
        while (true) 
        {
            yield return new WaitForSeconds(Random.Range(1f,4f));
            int random = Random.Range(0, tags.Length - 1);
            CurrentTag = tags[random];
            for (int j = 0; j < tags.Length; j++) 
            {
                UIfruits[j].SetActive(false);
            }
            UIfruits[random].SetActive(true);
            
        }

    }
    IEnumerator SpawnFruit()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.1f,2f));
            int j = 6;
            for (int i = 0; i < j; i++)
            {
            float xRandomize = Random.Range(minRandomzier.position.x, maxRandomzier.position.x);
            float yRandomize = Random.Range(minRandomzier.position.y, maxRandomzier.position.y);
            Vector2 randomizer = new Vector2(xRandomize, yRandomize);
                Instantiate(fruits[Random.Range(0, fruits.Length - 1)], randomizer, new Quaternion(0, 0, 0, 0));
            yield return new WaitForSeconds(Random.Range(0.1f,2f));

            }

            currentTimer = delay;
        }
    }
}
