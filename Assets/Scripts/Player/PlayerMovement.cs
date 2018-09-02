using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject bulletSpawnPosition;
    public GameObject bullet;
    //Sound stuff
    public AudioSource audioSource;
    public float playerSpeed;
    //Cooldown stuff
    public float shootingCooldown;
    float shootingIn;
    bool canShoot = true;
    // Use this for initialization
    void Start ()
    { }
    // Update is called once per frame
    void Update ()
    {
        //Moving left and preventing movement beyond the boundaries 
        if (Input.GetKey (KeyCode.LeftArrow) && (this.transform.position.x >= -6.7f))
        {
            Vector3 pos = transform.position;
            pos.x -= playerSpeed * Time.deltaTime;
            transform.position = pos;
            //Moving right and preventing movement beyond the boundaries 	 
        }
        else if (Input.GetKey (KeyCode.RightArrow) && (this.transform.position.x <= 6.67f))
        {
            Vector3 pos = transform.position;
            pos.x += playerSpeed * Time.deltaTime;
            transform.position = pos;
        }
        //Shootin'
        if (Input.GetKeyDown (KeyCode.Space) && canShoot == true)
        {
            //Preventing the player from shooting
            canShoot = false;
            //Setting the timer
            shootingIn = shootingCooldown;
            //Getting the sound from the source component
            audioSource = this.GetComponent<AudioSource> ();
            //Play shooting sound effect
            audioSource.Play ();
            //Spawn bullet at buller spawner
            Instantiate (bullet, bulletSpawnPosition.transform.position, bulletSpawnPosition.transform.rotation);
        }
        //Cooldown going down
        if (canShoot == false)
        {
            shootingIn -= Time.deltaTime;
            //Preventing it from going negative
            if (shootingIn <= 0f)
            {
                shootingIn = 0f;
                canShoot = true;
            }
        }
    }
}