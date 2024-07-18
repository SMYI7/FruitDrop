using JetBrains.Annotations;
using RTLTMPro;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    [SerializeField] private RTLTextMeshPro scoreText;
    [SerializeField] private RTLTextMeshPro finalScore;
    [SerializeField] private RTLTextMeshPro triesText;
    [SerializeField] private GameObject lostCanva;
    [SerializeField] private float delay;
    public float playerTries;
    [SerializeField]private float currentTimer;
    public AudioSource collected;
    public AudioSource lost;

    void Start()
    {
        Time.timeScale = 1f;
        ChangeTag();
        Instance = this;
        currentTimer = delay;
        StartCoroutine(SpawnFruit());
        int random = Random.Range(0, tags.Length - 1);
        CurrentTag = tags[random];
        for (int j = 0; j < tags.Length; j++)
        {
            UIfruits[j].GetComponent<SpriteRenderer>().enabled = false;
        }
        UIfruits[random].GetComponent<SpriteRenderer>().enabled = true;
        
        playerTries = 5;
    }

    // Update is called once per frame
    void Update()
    {
        triesText.text = playerTries.ToString();
        scoreText.text = score.ToString();
        finalScore.text = score.ToString();
        currentTimer -= Time.deltaTime;
        if(playerTries < 1)
        {
            lostCanva.SetActive(true);
            Time.timeScale = 0f;
        }

     }
    public void ChangeTag()
    {
        
            int random = Random.Range(0, tags.Length - 1);
            CurrentTag = tags[random];
            for (int j = 0; j < tags.Length; j++) 
            {
                UIfruits[j].GetComponent<SpriteRenderer>().enabled = false;
            }
            UIfruits[random].GetComponent<SpriteRenderer>().enabled = true;
            
        

    }
    IEnumerator SpawnFruit()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.1f,2f));
            int j = Random.Range(10,20);
            for (int i = 0; i < j; i++)
            {
            float xRandomize = Random.Range(minRandomzier.position.x, maxRandomzier.position.x);
            float yRandomize = Random.Range(minRandomzier.position.y, maxRandomzier.position.y);
            Vector2 randomizer = new Vector2(xRandomize, yRandomize);
                Instantiate(fruits[Random.Range(0, fruits.Length - 1)], randomizer, new Quaternion(0, 0, 0, 0));
            yield return new WaitForSeconds(Random.Range(0.1f,1f));

            }

            currentTimer = delay;
        }
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
    
}
