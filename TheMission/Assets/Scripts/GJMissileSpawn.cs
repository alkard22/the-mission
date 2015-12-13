using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets
{
    public class GJMissileSpawn : MonoBehaviour
    {
        public int maxMissiles = 10;
        public List<GameObject> missileColletion = new List<GameObject>();
        public GameObject missilePrefab;
        public float missileSpeedSliderValue = 0.35f;
        public float missileProportionalConstSliderValue = 0.55f;
        public float targetChangeSpeed = 1.5f;

        private readonly float gameSpeed = 1.0f;

        // Use this for initialization
        private void Start()
        {
        }


        // Update is called once per frame
        private void Update()
        {
            /*if (Input.GetMouseButtonDown(0))
            {
                var earthPosition = transform.parent.localPosition;
                Debug.Log(earthPosition);
                //var newMissile = (GameObject)Instantiate(missilePrefab, new Vector3(earthPosition.x, earthPosition.y, earthPosition.z), Quaternion.identity);
            }*/

                Time.timeScale = gameSpeed;

                // Ensure the user is not clicking a GUI control - if not, then add the missile.
                if (Input.GetMouseButtonDown(0) && GUIUtility.hotControl == 0)
                {
                    var targets = GameObject.FindGameObjectsWithTag("Targets").ToList();
                    Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                    // Note, you should ideally use Object Pooling rather than instantiation for mass missile use!
                    if (missileColletion.Count < maxMissiles)
                    {
                        // We modify the position of instantiation here to ensure the Z-ordering is correct in the demo scene. Normally we would use the 2D layer sorting order for this, but there is an issue with Unity 4.3 where
                        // exported assets do not retain layer sort ordering, and therefore we have to use Z depth for ordering here instead.
                        var newMissile =
                            (GameObject)
                                Instantiate(missilePrefab, new Vector3(clickPosition.x, clickPosition.y, -3f),
                                    Quaternion.identity);

                        // Adjust missile main performance properties based on scene slider values
                        var missileScriptReference = newMissile.GetComponent<MissileController3D>();
                        missileScriptReference.kProportionalConst = missileProportionalConstSliderValue;
                        missileScriptReference.maxSpeed = missileSpeedSliderValue;

                        // Target a random gameobject tagged with "Targets" found in the scene.
                        missileScriptReference.target = targets[Random.Range(0, targets.Count - 1)];
                        missileColletion.Add(newMissile);

                        // Update missile cam to follow the newest missile added
                        //CameraFollowCSharp.target = newMissile.transform;
                    }
                }

                // Clean up old missiles so we can fire more (depends on maxMissiles)
                for (var index = 0; index < missileColletion.Count; index++)
                {
                    var missile = missileColletion[index];
                    if (missile == null)
                    {
                        missileColletion.RemoveAt(index);
                    }
                }
            }
        }
    }

