using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    Animator anim;
    CharacterController CC;

    [System.Serializable] // mở tuần tự hóa 
    public class Character{
        public string Forword = "Forword";
        public string Straigth = "Straigth";
        public string Sprint = "Sprint";
    }
    [SerializeField] // đóng tuần tự hóa 

    Character setting;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        CC = GetComponent<CharacterController>();
    }

    public void CharexterMove(float Straigth, float Forword)
    {
        anim.SetFloat(setting.Straigth, Straigth);
        anim.SetFloat(setting.Forword, Forword);

    }

    public void CharexterSprint(bool Sprint)
    {
        anim.SetBool(setting.Sprint, Sprint);
    }
}
