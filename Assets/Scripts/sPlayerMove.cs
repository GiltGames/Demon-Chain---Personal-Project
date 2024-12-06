using System.IO;
using Unity.Hierarchy;
using UnityEngine;

public class sPlayerMove : MonoBehaviour
{
    public float vPlayerMoveSpeed = 5;
    public float vPlayerTurnSpeed = 5;
    public Rigidbody rb;
    Vector3 vPlayerMove;


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        KeyInput();

    }




    void KeyInput()
    {
       float vMoveForward = Input.GetAxis("Vertical");
        float vMoveSideways = Input.GetAxis("Horizontal");

        vPlayerMove = ((Vector3.forward * vMoveForward )* vPlayerMoveSpeed).normalized *Time.deltaTime;

        transform.Translate(vPlayerMove);
        transform.Rotate(new Vector3(0,Time.deltaTime* vMoveSideways * vPlayerTurnSpeed,0));






    }

}
