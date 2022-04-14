using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   // public GameObject enemyprefab,pos;
    private Animator enemy;
    public bool first, second, third;
    private void Awake()
    {
        enemy =GetComponent<Animator>();
        enemy.SetBool("isrunning", true);
    }
    // Start is called before the first frame update
    void Start()
    {
        first = true;
        second = false;
        third = false;
      
    }

    // Update is called once per frame
    void Update()
    {
            transform.Translate(Vector3.forward * 10 * Time.deltaTime);
       
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "second")
        {
            transform.eulerAngles = new Vector3(0,90, 0);
            

        }
        if (collision.gameObject.tag=="third")
        {
            transform.eulerAngles = new Vector3(0, -90, 0);
        }
    }
}
