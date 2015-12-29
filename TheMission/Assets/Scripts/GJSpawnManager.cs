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
    private GJPool m_smallPool;
    private GJPool m_mediumPool;
    private GJPool m_largePool;
    private int m_aliveCount;

    //public Transform TargetsPrefab;
    //public int TargetsAmount;
    //public int TargetsRadius;
    public GameObject LargeAsteroidsSpawnPrefab;
    public GameObject MediumAsteroidsSpawnPrefab;
    public GameObject SmallAsteroidsSpawnPrefab;
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
        m_smallPool = new GJPool(SmallAsteroidsSpawnPrefab, PoolSize);
        m_mediumPool = new GJPool(MediumAsteroidsSpawnPrefab, PoolSize);
        m_largePool = new GJPool(LargeAsteroidsSpawnPrefab, PoolSize);
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
            GameObject obj = null;
            obj = GetAseteroid();
            obj.transform.position = m_spawnPointGenerator.GenerateSpawnPoint();
            obj.SetActive(true);
            obj.GetComponent<AGJAsteriod>().StartMovement();
            AliveCount ++;
        }

        yield return Spawn();
    }

    private GameObject GetAseteroid()
    {
        GameObject asteroid =null;
        float randomValue = Random.value;
        if(randomValue <= 0.4 ) //40% chance
        {            
            asteroid = m_smallPool.RetrieveNonActiveFromPool;
        }
        else if (randomValue > 0.65) //35% chance
        {
            asteroid = m_mediumPool.RetrieveNonActiveFromPool;
        }
        else //this is only a 25% of chance
        {
            asteroid = m_largePool.RetrieveNonActiveFromPool;
        }
        
        return asteroid;
    }
    #endregion
}
