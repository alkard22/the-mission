using UnityEngine;
using System.Collections;

public class GJMeteor : MonoBehaviour {

    #region members
    private Vector3 m_target;
    private Transform m_transform;
    #endregion

    #region mono functions
    // Use this for initialization
    void Start () {
        m_target = GJSpawnManager.Instance.Target;
        m_transform = this.gameObject.transform;
       StartCoroutine(moveFoward());
    }
	
	// Update is called once per frame
	void Update () {
       
    }
    #endregion

    #region public functions

    public void destroy()
    {
        this.gameObject.SetActive(false);
        GJSpawnManager.Instance.AliveCount--;
    }

    #region private functions

    private IEnumerator moveFoward()
    {
        Vector3 relativePosition = (m_target - m_transform.position).normalized;
        Vector3 targetMovePosition = m_target - (relativePosition * 2f);

        m_transform.LookAt(m_target);
        while (m_target != targetMovePosition)
        {

            m_transform.position = Vector3.MoveTowards(m_transform.position, targetMovePosition, Time.deltaTime * 5f);

            yield return null;
        }
        yield break;
    }
    #endregion
    
    #region properties
    public Vector3 Target
    {
        get
        {
            return m_target;
        }
        set
        {
            m_target = value;
        }
    }
    #endregion
}
