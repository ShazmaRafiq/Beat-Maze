using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text gameover;
    public Button pause, resume, restart, level2;
    public Text leveltext;
    //public Slider slider;
    // public GameObject pannel;
    public static float counter = 0;
    public Text cointext;
    public GameObject key;
    public GameObject keypos;
    public Text keytext;
    public float keycounter;
    public GameObject cam,player;
    public GameObject door;
    private doormove dm;
    // Start is called before the first frame update
    void Start()
    {
        dm = GameObject.Find("Door").GetComponent<doormove>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGame()
    {
      //  pannel.SetActive(false);
       // title.gameObject.SetActive(false);
        pause.gameObject.SetActive(true);
        Time.timeScale = 1;
        //slider.gameObject.SetActive(false);
    }
    public void Pause()
    {
        resume.gameObject.SetActive(true);
        restart.gameObject.SetActive(true);
        pause.gameObject.SetActive(false);
        //setting.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void Resume()
    {
        resume.gameObject.SetActive(false);
        restart.gameObject.SetActive(false);
        pause.gameObject.SetActive(true);
        //setting.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void Restart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        resume.gameObject.SetActive(false);
        restart.gameObject.SetActive(false);
    }
    public void Setting()
    {
        //setting.gameObject.SetActive(false);
        //slider.gameObject.SetActive(true);
    }
    public void Coin()
    {
        counter += 1;
        cointext.text = "   " + counter;
        if (counter == 20)
        {
            Instantiate(key,keypos.transform.position,key.transform.rotation);
            
        }
    }
    public void KeyCollection()
    {
        
        keycounter += 1;
        keytext.text = "" + keycounter;
        Debug.Log("open the door");
        dm.DoorMove();
        //door.transform.Translate(Vector3.right * 10 * Time.deltaTime);
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        gameover.text = "Game Over";
        restart.gameObject.SetActive(true);
    }
    public void Dead()
    {
        Destroy(player);
        cam.transform.position = new Vector3(0, 5, 0);
    }
    public void Level2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }
}
