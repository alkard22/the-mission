using UnityEngine;
using System.Collections;

public class GJRotateTowards : MonoBehaviour
{
    #region members
    public GameObject m_target = null;
    #endregion

    #region mono functions

    void Start () 
    {
		if (m_target == null)
			m_target = GJPlayer.Instance.gameObject;
	}

	void Update () 
	{
		if (m_target == null)
			m_target = GJPlayer.Instance.gameObject;

		Vector3 targetPosition = -m_target.transform.position;
		targetPosition.y = transform.position.y;

		transform.LookAt(targetPosition);
	}
    #endregion
}