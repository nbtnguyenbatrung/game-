using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;
    private Vector3 offset;

    [System.Serializable]
    public class Camsetting
    {
        public float moveSpeed = 5;
        public float movecenti = 5;
        public float minclamp = 0;
        public float maxclamp = 90;
        public double rotespeed = 0.1;
    }
    [SerializeField]

    Camsetting camsetting;
    [System.Serializable]
    public class CamInput
    {
        public string movexasis = "Mouse X";
        public string moveyasis = "Mouse Y";
    }
    [SerializeField]
    CamInput camInput;
    Camera maincamera;
    Transform center;
    Transform target;
    float camxrote = 0;
    float camyrote = 0;
    // Start is called before the first frame update
    void Start()
    {
        maincamera = Camera.main;
        center = transform.GetChild(0);
        target = GameObject.FindGameObjectWithTag("Player").transform;
        //tính chênh lệch vị trí của player và camera
        offset = this.transform.position - Player.transform.position;
    }
    void Update()
    {
        camrote();
    }
    // Update is called once per frame
    void LateUpdate()
    {
        //đặt vị trí của camera ở mỗi khung hình phụ thuộc vào vị trí player + khoảng cách
        this.transform.position = Player.transform.position + offset;
        
    }

    void camrote()
    {
        camxrote += Input.GetAxis(camInput.moveyasis)*camsetting.movecenti;
        camyrote += Input.GetAxis(camInput.movexasis) * camsetting.movecenti;

        camxrote = Mathf.Clamp(camxrote, camsetting.minclamp,camsetting.maxclamp);
        camyrote = Mathf.Repeat(camyrote, 360);

        Vector3 rotingangle = new Vector3(camxrote, camyrote, 0);
        Quaternion rotate = Quaternion.Slerp(center.transform.localRotation,Quaternion.Euler(rotingangle),(float)camsetting.rotespeed*Time.deltaTime);
        center.transform.localRotation = rotate;
    }
}
