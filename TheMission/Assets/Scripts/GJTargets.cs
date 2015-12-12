using System.Collections.Generic;
using UnityEngine;
namespace Assets
{
    public class GJTargets
    {
        private float m_radius;
        private Vector3 m_spawnPoint;
        private int m_targetAmount;

        public GJTargets(float mRadius, Vector3 targetPoint, int mTargetAmount)
        {
            m_radius = mRadius;
            m_spawnPoint = targetPoint;
            m_targetAmount = mTargetAmount;
        }

        public IList<Vector3> generateTargets()
        {
            IList<Vector3> targets = new List<Vector3>();
            for (int i = 0; i < m_targetAmount; i++)
            {
                float x = Random.Range(-m_radius, m_radius);
                float y = Random.Range(0, m_radius); // starts at zero because we want it in the positive space
                float z = Random.Range(-m_radius, m_radius);
                targets.Add(new Vector3(x + m_spawnPoint.x, y + m_spawnPoint.y, z + m_spawnPoint.z));
            }

            return targets;
        }
    }
}

