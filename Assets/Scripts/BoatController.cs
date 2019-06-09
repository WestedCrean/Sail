using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PhysicsScripts;

public class BoatController : MonoBehaviour
{

    public Transform BoatEngine;
    public float SteerPower = 500f;
    public float Power = 5f;
    public float MaxSpeed = 10f;
    public float Drag = 0.1f;

    protected Rigidbody Rigidbody;
    protected Quaternion StartRotation;


    public int count;

    public Text countText;
    public Text winText;



    void Start() {
        Rigidbody = GetComponent<Rigidbody>();
        
        RandomStartLocation();
        StartRotation = BoatEngine.localRotation;

        count = 0;
        countText.color = Color.magenta;
        SetCountText();
        winText.text = "";
        winText.color = Color.green;
    }

    // Update is called once per frame
    void FixedUpdate() {
        var ForceDirection = transform.forward;
        var steer = 0;

        if (Input.GetKey(KeyCode.D))
            steer = 1;
        if (Input.GetKey(KeyCode.A))
            steer = -1;

        Rigidbody.AddForceAtPosition(steer * transform.right * SteerPower / 100f, BoatEngine.position);

        var forward = Vector3.Scale(new Vector3(1,0,1), transform.forward);
        
        if (Input.GetKey(KeyCode.W))
            PhysicsHelper.ApplyForceToReachVelocity(Rigidbody, forward * MaxSpeed, Power);
        if (Input.GetKey(KeyCode.S))
            PhysicsHelper.ApplyForceToReachVelocity(Rigidbody, forward * -MaxSpeed, Power);
    }

    public void RandomStartLocation() {
        float x = (float) Random.Range(200, 800);
        float z = (float) Random.Range(200, 800);
        x /= 10;
        z /= 10;
        transform.position = new Vector3(x,10f,z);
        Rigidbody.velocity = Vector3.zero;
        Rigidbody.angularVelocity = Vector3.zero;
        count = 0;
        SetCountText();
    }

    void OnTriggerEnter(Collider collectible) {
        if(collectible.gameObject.CompareTag("collectible")) {
            count++;
            SetCountText();
            collectible.gameObject.SetActive(false);
            float x = (float) Random.Range(200, 800);
            float z = (float) Random.Range(200, 800);
            x /= 10;
            z /= 10;
            collectible.transform.position = new Vector3(x,26.1f,z);
            collectible.gameObject.SetActive(true);
        }
    }

    void SetCountText() {
        countText.text = "Punkty: " + count.ToString ();
        if (count >= 3) {
            winText.text = "Wygrales!";
        }
    }
}
