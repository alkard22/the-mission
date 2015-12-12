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
    private GJPool pool;

    //public Transform TargetsPrefab;
    //public int TargetsAmount;
    //public int TargetsRadius;
    public GameObject spawnPrefab;
    public int spawnAmount;
    public int spawnRadius;
    public float maxHeightLimit;
    public float minHeightLimit;
    public Transform targetPostion;
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
       
        //m_targetsGenerator = new GJTargets(TargetsRadius, transform.position, TargetsAmount);
        //_targets = m_targetsGenerator.generateTargets();
        //foreach(var target in _targets)
        //{
        //    //Debug.Log(target);
        //    Instantiate(TargetsPrefab, target, Quaternion.identity);
        //}
        pool = new GJPool(spawnPrefab);
        List<GameObject> astoids = new List<GameObject>();
        m_spawnPointGenerator = new GJSpawnPoints(spawnRadius, transform.position, spawnAmount, maxHeightLimit, minHeightLimit);
        m_spawnPoints = m_spawnPointGenerator.generateSpawnPoints();
        foreach (Vector3 spawn in m_spawnPoints)
        {
            Debug.Log("this is the spawprefab" + spawnPrefab);
            GJMeteor asteroid = pool.retrieveNonActiveFromPool.GetComponent<GJMeteor>();
            asteroid.Target = Target;
            asteroid.gameObject.transform.position = spawn;
            asteroid.gameObject.SetActive(true);

            //metiors.Add(add);
        }
        //Metiors = metiors.ToArray();
       

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

    public static bool isAwake
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
    #endregion

    #region private functions
    #endregion
}
