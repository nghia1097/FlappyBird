using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdControler : MonoBehaviour
{
    public float flypower;

    public AudioClip flyclip;
    public AudioClip gameoverclip;

    private AudioSource audiosoure;

    private Animator anim;

    GameObject obj;
    public GameObject GameControler;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        flypower = 100;
        audiosoure = obj.GetComponent<AudioSource>();
        audiosoure.clip = flyclip;
        anim = obj.GetComponent<Animator>();
        anim.SetFloat("Flypower", 0);
        anim.SetBool("isDead", false);
        

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            if (GameControler.GetComponent<GameControler>().isEndgame == false)
            {
                audiosoure.Play();
            }
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, flypower));
          
        }
        anim.SetFloat("Flypower", obj.GetComponent<Rigidbody2D>().velocity.y);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Endgame();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameControler.GetComponent<GameControler>().GetPoint();
    }

    void Endgame()
    {
        anim.SetBool("isDead", true);
        audiosoure.clip = gameoverclip;
        audiosoure.Play();
        GameControler.GetComponent<GameControler>().Endgame();
    }
  
}
