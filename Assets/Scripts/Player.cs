using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject PowerB;
    [SerializeField] float nextfire;
    bool modo=false;
    int counter;
    float minX, maxX, minY, maxY, tamX, tamY, canFire;

    // Start is called before the first frame update
    void Start()
    {
        float tamX = (GetComponent<SpriteRenderer>()).bounds.size.x;
        float tamY = (GetComponent<SpriteRenderer>()).bounds.size.y;


        Vector2 esquinaSupDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        maxX = esquinaSupDer.x - tamX/2;
        maxY = esquinaSupDer.y - tamY/2;

        Vector2 esquinaInfIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        minX = esquinaInfIzq.x + tamX/2;
        minY = esquinaInfIzq.y + 7;

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        ChangeMode();
        
        if (Input.GetKey(KeyCode.Space))
        {
            counter++;
            Debug.Log(counter);
        }
        

        if (modo == false)
        {
            Fire();
        }
        else
        {
            PowerBullet();
        }
    }

    void Movement()
    {
        float movH = Input.GetAxis("Horizontal");
        float movV = Input.GetAxis("Vertical");

        transform.Translate(new Vector2(movH * Time.deltaTime * speed, movV * Time.deltaTime * speed));

        float newX = Mathf.Clamp(transform.position.x, minX, maxX);
        float newY = Mathf.Clamp(transform.position.y, minY, maxY);

        transform.position = new Vector2(newX, newY);
    }

    void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= canFire)
        {
            Instantiate(bullet, transform.position - new Vector3(0, tamY / 2, 0), transform.rotation);
            canFire = Time.time + nextfire;
            counter = 0;
        }
    }

    void PowerBullet()
    {
        if (Input.GetKeyUp(KeyCode.Space) && counter >= 600)
        {
            Instantiate(PowerB, transform.position - new Vector3(0, tamY / 2, 0), transform.rotation);
            counter = 0;
        }
        else if (Input.GetKeyUp(KeyCode.Space) && counter< 600)
        {
            counter = 0;
        }
    }

    void ChangeMode()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (modo == true)
            {
                modo = false;
            }
            else if (modo == false)
            {
                modo = true;
            }
        }
    }
}
