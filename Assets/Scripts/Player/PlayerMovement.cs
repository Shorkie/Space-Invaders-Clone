using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public GameObject bulletSpawnPosition;
    public GameObject bullet;
    public float playerSpeed;
    // Use this for initialization
    void Start () { }

    // Update is called once per frame
    void Update () {
        //Moving left and preventing movement beyond the boundaries 
        if (Input.GetKey (KeyCode.LeftArrow) && (this.transform.position.x >= -6.7f)) {
            Vector3 pos = transform.position;
            pos.x -= playerSpeed * Time.deltaTime;
            transform.position = pos;
            //Moving right and preventing movement beyond the boundaries 	 
        } else if (Input.GetKey (KeyCode.RightArrow) && (this.transform.position.x <= 6.67f)) {
            Vector3 pos = transform.position;
            pos.x += playerSpeed * Time.deltaTime;
            transform.position = pos;
        }
        //Shootin'
        if (Input.GetKeyDown (KeyCode.Space)) {
            Instantiate (bullet, bulletSpawnPosition.transform.position, bulletSpawnPosition.transform.rotation);
        }
    }
}