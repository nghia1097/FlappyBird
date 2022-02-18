using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colum : MonoBehaviour
{
    public float moveSpeed;
    public float oldPosition;
    public float minY;
    public float maxY;
    private GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        oldPosition = 10;
        minY = -1;
        maxY = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-1 * Time.deltaTime * moveSpeed, 0, 0));
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("ResetColum"))
            obj.transform.position = new Vector3(oldPosition, Random.Range(minY, maxY + 1), 0);
    }
    
}
