using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject bullet;
    [SerializeField] float nextfire;

    float minX, maxX, minY, maxY, tamX, tamY, canFire;
    float NST = 7;

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
        Fire();
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
            Instantiate(bullet, transform.position - new Vector3(0,tamY/5,0), transform.rotation);
            canFire = Time.time + nextfire;
        }
    }

    void Damagex2()
    {
        if (Input.GetKeyDown(KeyCode.Z) && Time.time == NST)
        {

        }
    }
}
