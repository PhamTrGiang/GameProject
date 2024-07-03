using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimation : MyBehaviourScript
{
    private Animator anim;

    private bool isRight = true;

    private static PlayerAnimation instance;
    public static PlayerAnimation Instance { get { return instance; } }

    public override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
    }

    public override void Awake()
    {
        base.Awake();
        if (instance != null && instance == this) return;
        instance = this;
    }

    public override void Update()
    {
        base.Update();
        this.SetParameters();
        this.Flip();
    }

    private void SetParameters()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        if(x != 0 || y != 0)
        {
            anim.SetFloat("x", x);
            anim.SetFloat("y", y);
        }
            
    }
    public void SetTrigger(string action)
    {
        anim.SetTrigger(action);
    }
    public void SetBool(string action,bool status)
    {
        anim.SetBool(action,status);
    }
    public float GetFloat(string name)
    {
        return anim.GetFloat(name);
    }

    private void Flip()
    {
        float x = this.GetFloat("x");
        if (isRight && x < 0 || !isRight && x > 0)
        {
            isRight = !isRight;
            Vector3 flip = transform.parent.localScale;
            flip.x = flip.x * -1;
            transform.parent.localScale = flip;
        }
    }
}
