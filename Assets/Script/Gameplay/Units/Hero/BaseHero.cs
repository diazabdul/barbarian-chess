using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHero : BaseUnit
{
    [SerializeField] protected Transform pos = null;
    [SerializeField] protected int x;
    [SerializeField] protected int y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected void movement(int x, int y)
    {
        pos.position.Set(x, y, 0);
    }
}
