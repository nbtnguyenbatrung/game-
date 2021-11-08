using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]

public class InputSystem : MonoBehaviour
{
    Movement movement;
    [System.Serializable] // mở tuần tự hóa 
    public class InputString
    {
        public string horizontal = "Horizontal"; // trục x
        public string vertical = "Vertical"; // trục y 
        public string sprint = "Sprint";
    }
    [SerializeField] // đóng tuần tự hóa 

    InputString input;
    [Header("camera & character syncing ")]
    public float lookDistance = 5;
    public float lookSpeed = 5;

    Transform camCenter;
    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
        camCenter = Camera.main.transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis(input.horizontal)!=0 || Input.GetAxis(input.vertical) != 0)
        {
            rotatecamview();
        }
        movement.CharexterMove(Input.GetAxis(input.horizontal), Input.GetAxis(input.vertical));
        movement.CharexterSprint(Input.GetButton(input.sprint));
    }

    void rotatecamview()
    {
        Vector3 camCenterPos = camCenter.position;
        Vector3 lookPoint = camCenterPos + camCenter.forward * lookDistance;
        Vector3 dir = lookPoint - transform.position;
        Quaternion lookRotion = Quaternion.LookRotation(dir);
        lookRotion.x = 0;
        lookRotion.z = 0;

        Quaternion final = Quaternion.Lerp(transform.rotation, lookRotion, Time.deltaTime * lookSpeed);
        transform.rotation = final;

    }

}
