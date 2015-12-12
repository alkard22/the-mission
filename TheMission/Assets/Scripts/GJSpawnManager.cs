using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets;

public class GJSpawnManager : MonoBehaviour {

    #region members
    private GJTargets m_targetsGenerator;
    private IList<Vector3> m_spawnPoints;
    
    private GJSpawnPoints m_spawnPointGenerator;
    private static GJSpawnManager m_instance;

    //public Transform TargetsPrefab;
    //public int TargetsAmount;
    //public int TargetsRadius;
    public Transform SpawnPrefab;
    public int SpawnAmount;
    public int SpawnRadius;
    public float MaxHeightLimit;
    public float MinHeightLimit;
    public Transform[] Targets  ;
    public Transform[] Metiors;
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
        var _metiors = new List<Transform>();
        m_spawnPointGenerator = new GJSpawnPoints(SpawnRadius, transform.position, SpawnAmount, MaxHeightLimit,MinHeightLimit);
        m_spawnPoints = m_spawnPointGenerator.generateSpawnPoints();
        foreach (var spawn in m_spawnPoints)
        {
            //Debug.Log(spawn);
            Transform add = Instantiate(SpawnPrefab, spawn, Quaternion.identity) as Transform;
            add.gameObject.AddComponent<GJMeteor>().Target = Target;     
            _metiors.Add(add);
        }
        Metiors = _metiors.ToArray();
       

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
            int index = Random.Range(0, Targets.Length);
            return Targets[index].position;
        }
    }
    #endregion

    #region private functions
    #endregion
}
