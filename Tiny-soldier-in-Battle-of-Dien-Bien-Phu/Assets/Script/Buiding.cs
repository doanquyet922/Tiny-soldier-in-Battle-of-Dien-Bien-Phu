using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buiding : MonoBehaviour
{
    public GameObject eCanvas;
    bool win = false;
    bool e = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && e==true)
        {
           
            SceneManager.LoadScene("InsideHome");
        }
        HealthEnemy[] enemys = FindObjectsOfType<HealthEnemy>();

        if (enemys.Length == 0)
        {
            win = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && win == true)
        {
            eCanvas.SetActive(true);
            e = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            eCanvas.SetActive(false);
            e = false;
        }
    }
}
