using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class GJPool:MonoBehaviour
{

    #region members
    private IList<GameObject> m_pool;
    private int m_poolSize = 5;
    private GameObject m_cloneObject;
    #endregion

    #region constructors

    public GJPool(GameObject cloneObject)
    {
        m_cloneObject = cloneObject;
        populatePool();
    }
    #endregion

    #region mono functions
    #endregion

    #region properties

    public GameObject retrieveNonActiveFromPool
    {
        get
        {
            GameObject poolObject = m_pool.FirstOrDefault(po => po.activeSelf == false);
            if (poolObject)
            {
                return poolObject;
            }
            else
            {
                GameObject cloneGameObject = Instantiate(m_cloneObject, Vector3.zero, Quaternion.identity) as GameObject;
                m_pool.Add(cloneGameObject);
                Debug.Log("Created " + m_pool.Count);
                return cloneGameObject;
            }
        }
    }
     
    #endregion

    #region private functions
    private void populatePool()
    {
        GameObject cloneGameObject;
        m_pool = new List<GameObject>();
        for (int i=0; i < m_poolSize; i++)
        {
            cloneGameObject = Instantiate(m_cloneObject, Vector3.zero, Quaternion.identity) as GameObject;
            cloneGameObject.SetActive(false);
            m_pool.Add(cloneGameObject);
        }
    }
    #endregion
}
