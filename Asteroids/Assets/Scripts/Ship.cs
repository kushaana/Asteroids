using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    GameObject HUD;

    Rigidbody2D rb2d;
    Vector2 thrustDirection = new Vector2(1.0f, 0.0f);
    const int ThrustForce = 5;
    float rotateDegreesPerSecond=270;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float rotationInput = Input.GetAxis("Rotate");
        float rotationAmount = rotationInput*rotateDegreesPerSecond * Time.deltaTime;
        transform.Rotate(Vector3.forward, rotationAmount);

        Vector3 eAng = transform.eulerAngles;
        thrustDirection.x = Mathf.Cos(Mathf.Deg2Rad * eAng.z);
        thrustDirection.y = Mathf.Sin(Mathf.Deg2Rad * eAng.z);

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = gameObject.transform.position;
            bullet.GetComponent<Bullet>().ApplyForce(thrustDirection);
            AudioManager.Play(AudioClipName.PlayerShot);
        }

    }

    void FixedUpdate()
    {
        if (Input.GetAxis("Thrust") > 0)
        {
            rb2d.AddForce(ThrustForce * thrustDirection, ForceMode2D.Force);
        }
        
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        AudioManager.Play(AudioClipName.PlayerDeath);
        HUD.GetComponent<HUD>().StopGameTimer();
        Destroy(gameObject);
    }

}
