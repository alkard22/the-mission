using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets;

public class GJSpawnManager : MonoBehaviour {

    #region members
    //private GJTargets m_targetsGenerator;
    private IList<Vector3> m_spawnPoints;
    
    private GJSpawnPoints m_spawnPointGenerator;
    private static GJSpawnManager m_instance;
    private GJPool m_pool;
    private int m_aliveCount;

    //public Transform TargetsPrefab;
    //public int TargetsAmount;
    //public int TargetsRadius;
    public GameObject spawnPrefab;
    public int SpawnAmount;
    public int SpawnRadius;
    public float maxHeightLimit;
    public float minHeightLimit;
    public Transform targetPostion;
    public int PoolSize;
    //public Transform[] Metiors;
    #endregion

    #region mono functions
    //used to set the instance 
    void Awake()
    {
        if (m_instance == null)
        {
            m_instance = this;
            DontDestroyOnLoad(m_instance);
        }       

    }
      
    // Use this for initialization
    void Start () {
       
      
        m_aliveCount = 0;
        m_pool = new GJPool(spawnPrefab, PoolSize);
       
        m_spawnPointGenerator = new GJSpawnPoints(SpawnRadius, transform.position, m_aliveCount, maxHeightLimit, minHeightLimit);
        StartCoroutine(Spawn());

    }
	

	// Update is called once per frame
	void Update () {
               
        
    }
    #endregion

    #region Properties

    public static GJSpawnManager Instance
    {
        get
        {
            if (m_instance == null)
            {
                Debug.LogError("SpawnManager Instance is not setup");
            }

            return m_instance;
        }
    }

    public static bool IsAwake
    {
        get
        {
            return m_instance != null;
        }
    }

    public Vector3 Target
    {
        get
        {
            //int index = Random.Range(0, Targets.Length);
            return targetPostion.position;
        }
    }

    public int AliveCount
    {
        get { return m_aliveCount; }
        set { m_aliveCount = value; }
    }

    
    #endregion

    #region private functions
    
    private IEnumerator Spawn()
    {
      
        yield return new WaitForSeconds(1);
        if (m_aliveCount < SpawnAmount)
        {
            GameObject obj =  m_pool.retrieveNonActiveFromPool;
            obj.transform.position = m_spawnPointGenerator.GenerateSpawnPoint();
            obj.SetActive(true);
            obj.GetComponent<AGJAsteriod>().StartMovement();
            AliveCount ++;
        }

        yield return Spawn();
    }
    #endregion
}
