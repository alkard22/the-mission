using UnityEngine;
using System.Collections;


    public abstract class AGJAsteriod : MonoBehaviour
    {
        #region members
        private Vector3 m_target;
        private Transform m_transform;
        private float m_minSpeed;
        private float m_maxSpeed;
        #endregion

        #region mono functions
        // Use this for initialization
        void Awake()
        {

            m_transform = this.gameObject.transform;

        }
        public void Start()
        {
            m_target = GJSpawnManager.Instance.Target;
            StartCoroutine(moveFoward());
        }
        // Update is called once per frame
        void Update()
        {

        }
        void OnTriggerEnter(Collider other)
        {
            //Debug.Log("collided with " + other.name);
            if (other.name == "EarthContainer")
            {
                destroy();
            }
            else
            {
                other.GetComponent<AGJAsteriod>().destroy();
            }

        }
        #endregion
        #region public functions

        public void destroy()
        {

            this.gameObject.SetActive(false);
            GJSpawnManager.Instance.AliveCount--;
        }

        public void startMovement()
        {
            StartCoroutine(moveFoward());
        }
        #endregion

        #region private functions

        private IEnumerator moveFoward()
        {
            Vector3 targetMovePosition = m_target;
            float distance = 0;

            distance = Vector3.Distance(m_transform.position, targetMovePosition);
            float speed = Random.Range(m_minSpeed, m_maxSpeed);
            m_transform.LookAt(m_target);            
            Vector3 moveto = m_transform.forward * 2f;
            while (true)
            {
                moveto = m_transform.position + (m_transform.forward * 2f);
                m_transform.position = Vector3.MoveTowards(m_transform.position, moveto, Time.deltaTime * speed);               
                yield return null;
            }

            //destroy();
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

        public float MinSpeed
        {
            get
            {
                return m_minSpeed;
            }
            set
            {
                m_minSpeed = value;
            }
        }

        public float MaxSpeed
        {
            get
            {
                return m_maxSpeed;
            }
            set
            {
                m_maxSpeed = value;
            }
        }
        #endregion
    }

