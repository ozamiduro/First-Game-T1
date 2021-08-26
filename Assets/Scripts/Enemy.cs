using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool direction;
    [SerializeField] GameObject life;
    private float maxX;
    private float minX;
    public Sprite NHP;
    public int nChild;



    // Start is called before the first frame update
    void Start()
    {

        Vector2 esquinaInfDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));
        maxX = esquinaInfDer.x;

        Vector2 esquinaInfzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        minX = esquinaInfzq.x;

        nChild = transform.childCount;


    }

    // Update is called once per frame
    void Update()
    {

        if (direction)
            transform.Translate(new Vector2(speed * Time.deltaTime, 0));
        else
            transform.Translate(new Vector2(-speed * Time.deltaTime, 0));

        if (transform.position.x >= maxX)
            direction = true;
        else if (transform.position.x <= minX)
            direction = false;

        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (nChild > 1)
            {
                life = transform.GetChild(nChild-1).gameObject;
                life.gameObject.GetComponent<SpriteRenderer>().sprite = NHP;
                
                Debug.Log(nChild);
                Debug.Log(transform.GetChild(3));
                nChild -= 1;
            } 
            else 
            {
                Destroy(this.gameObject);
            }
        }
    }
}
