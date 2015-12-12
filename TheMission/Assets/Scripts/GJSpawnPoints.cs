
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    public class GJSpawnPoints
    {
        private float m_radius;
        private Vector3 m_spawnPoint;
        private int m_targetAmount;
        //private float m_minDistance;

        private float m_maxYHeight;
        private float m_minYHeight;

        public GJSpawnPoints(float mRadius, Vector3 targetPoint, int mTargetAmount,float maxHeight,float minHeight)
        {
            m_radius = mRadius;
            m_spawnPoint = targetPoint;
            m_targetAmount = mTargetAmount;
            m_maxYHeight = maxHeight;
            m_minYHeight = minHeight;
        }

        public IList<Vector3> generateSpawnPoints()
        {
            IList<Vector3> targets = new List<Vector3>();
            for (int i = 0; i <= m_targetAmount; i++)
            {
                float x = Random.Range(-m_radius, m_radius);
                float y = Random.Range(m_minYHeight, m_maxYHeight); 
                float z = Random.Range(-m_radius, m_radius);
                targets.Add(new Vector3(x + m_spawnPoint.x, y + m_spawnPoint.y, z + m_spawnPoint.z));
                Debug.Log(targets[i]);
            }

            return targets;
        }
    }

}
