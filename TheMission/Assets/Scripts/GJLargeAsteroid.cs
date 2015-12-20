using UnityEngine;
using System.Collections;


public class GJLargeAsteroid : AGJAsteriod
{
    #region members
    [SerializeField]
    private float Min_Speed;
    [SerializeField]
    private float Max_Speed;
    #endregion

    #region mono functions
    new void Start()
    {            
        MinSpeed = Min_Speed;
        MaxSpeed = Max_Speed;
        base.Start();
    }
    #endregion
}

