using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MyBehaviourScript : MonoBehaviour
{
    public virtual void Awake()
    {
        this.LoadComponent();
    }
    public virtual void Start()
    {
        
    }

    public virtual void Update()
    {
        
    }
    public virtual void Reset()
    {
        this.LoadComponent();
    }

    public virtual void LoadComponent()
    {

    }
}
