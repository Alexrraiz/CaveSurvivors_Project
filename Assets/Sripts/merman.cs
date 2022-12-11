using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class merman : Enemy
{
    [SerializeField] GameObject enemy;
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();        
    }

    public override void Damage(int damage)
    {
        base.Damage(damage);
        if (enemy == null)
        {

        }
            
    }
}
