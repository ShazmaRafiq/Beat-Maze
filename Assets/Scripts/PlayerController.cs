using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    // public float moveSpeed = 3f;
    public static int  lifecounter = 3;
    private int coincounter = 20;
    public int keycounter = 0;
    public Text cointext, keytext, lifetext, gameovertext;
    public GameObject key, keypos;
    public Vector3 startpos;
    public ParticleSystem partical;
    private GameManager gm;
    private AudioSource audioSource;
    public AudioClip coinClip;

    Animator animator;
    public doormove dm;
    public bool active=false, delay=false;
    // Start is called before the first frame update
    void Start()
    {
        // Set up the audio source for later
        audioSource = GetComponent<AudioSource>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        startpos = transform.position;
        Debug.Log(startpos);
        cointext.text = "" + coincounter;
        lifetext.text = "" + lifecounter;

        keytext.text = "" + keycounter;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isrunning", true);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            //transform.GetComponent<Rigidbody>().isKinematic = true;
            animator.SetBool("isrunning", false);
        }
        if (Input.GetKey(KeyCode.W))
        {
           transform.eulerAngles = new Vector3(0, -180, 0);
            //transform.GetComponent<Rigidbody>().isKinematic = false;
        }
       
        if (Input.GetKey(KeyCode.S))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 90, 0);
           
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(0, -90, 0);
           
        }
        if (transform.position.x > 37.5f)
        {
            transform.position = new Vector3(37.5f, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -37.5f)
        {
            transform.position = new Vector3(-37.5f, transform.position.y, transform.position.z);
        }
        if (transform.position.z > 148)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 148);
        }
        if (transform.position.z < -37)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -37);
        }
        if (delay == true)
        {
            StartCoroutine("Delay");
        }


    }
    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(3);
        gm.level2.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "coin" && active==false)
        {
            Debug.Log("Collide with coin");
            Destroy(col.gameObject);
            Instantiate(partical, transform.position, Quaternion.identity);
            partical.Play();
            audioSource.clip = coinClip;
            audioSource.Play();
            coincounter -= 1;
            cointext.text = "" + coincounter;
            if (coincounter == 0)
            {
                active = true;
                Instantiate(key, keypos.transform.position, key.transform.rotation);
            }
        }
        if (col.gameObject.tag == "key")
        {
            Destroy(col.gameObject);
            keycounter += 1;
            keytext.text = "" + keycounter;
            dm.DoorMove();
            delay = true;
            
        }
        if (col.gameObject.tag == "Enemy")
        {

            lifecounter -= 1;
            lifetext.text = "" + lifecounter;
            transform.position = startpos;
            transform.eulerAngles = new Vector3(0, 180, 0);
            if (lifecounter == 0)
            {
                Time.timeScale = 0;
                gameovertext.text = "Game Over";
                gm.restart.gameObject.SetActive(true);
            }

        }

    }
}