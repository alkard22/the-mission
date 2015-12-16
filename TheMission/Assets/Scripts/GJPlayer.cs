using UnityEngine;
using System.Collections;

public class GJPlayer : MonoBehaviour
{
    #region members
    public static GJPlayer Instance = null;
    #endregion

    #region mono functions
    void Awake()
    {
        Instance = this;
    }
    #endregion
}
