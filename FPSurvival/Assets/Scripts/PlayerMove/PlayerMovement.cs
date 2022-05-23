using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementspeed;
    [SerializeField] private float _mousense;
    Vector3 direct;
    Rigidbody rb;
    float MouseX, MouseY;
    float rotx, roty;
    [SerializeField] Camera maincam;
    //[SerializeField] private float _Jumpspeed = 1f;
    CapsuleCollider capsulecol;
    [SerializeField] LayerMask laymaskground;
    [SerializeField] GameObject IArea;
    bool acýkmi;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Cursor.lockState = CursorLockMode.Locked;
        IArea.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            if (acýkmi == false)
            {
                IArea.SetActive(true);
                acýkmi = true;
            }
            else if (acýkmi == true)
            {
                IArea.SetActive(false);
                acýkmi = false;
            } 
        }
        MouseSense();
        //if (Input.GetMouseButtonDown(0))
        //{
        //    if (IsGrounded() == true)
        //    {
        //        Jump();
        //    } 
        //}
    }

    private void LateUpdate()
    {
        CameraLocalRotationMove();
    }

    private void FixedUpdate()
    {
        Hareket();
    }

    public void Hareket()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        direct = new Vector3(hor, 0, ver);
        rb.MovePosition(transform.position + transform.TransformDirection(direct * Time.fixedDeltaTime * _movementspeed));
    }

    public void MouseSense()
    {
        MouseX = Input.GetAxis("Mouse X") * Time.deltaTime * _mousense;
        MouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * _mousense;

        rotx -= MouseY;
        rotx = Mathf.Clamp(rotx, -90, 90);
        roty += MouseX;
        transform.localRotation = Quaternion.Euler(0, roty, 0);
    }

    public void CameraLocalRotationMove()
    {
        maincam.transform.localRotation = Quaternion.Euler(rotx, 0, 0);
    }
    //public void Jump()
    //{

    //    rb.AddForce(Vector3.up  * _Jumpspeed);

    //}

    //bool IsGrounded()
    //{
    //    RaycastHit hit;
    //    if (Physics.Raycast(transform.position, Vector3.down, out hit, capsulecol.bounds.size.y / 2, laymaskground))
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}
}
