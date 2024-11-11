using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class deplacement : MonoBehaviour
{
    [SerializeField] private float vitesseMarcher = 10f;
    [SerializeField] private float vitesseTourner = 120f;

    private CharacterController cPersonnage;
    private Animator animation;
    public GameObject[] targets = new GameObject[4];
    public float detectionDistance = 5f;
    public float detectionAngle = 40f;
    public float faintDuration = 5f;
    private bool isFainting = false;
    [SerializeField] private TMP_Text timerText;
    public float countdownTime = 120f;
    private float currentTime;
    [SerializeField] private TMP_Text defaite;
    [SerializeField] private TMP_Text victoire;
    [SerializeField] private Vector3 targetPosition = new Vector3(-2.5f, 0, 18.61f);
    [SerializeField] private TMP_Text detectionbattery;
    [SerializeField] private TMP_Text batterierestante;
    public float nombre;
    public KeyCode key = KeyCode.P;
    public bool desactivationbattery;
    private GameObject batterypanier;
    private AudioSource audioSource;
    private bool detectionEnabled = true;
    private GameObject porteEntree;








    void Start()
    {
        cPersonnage = GetComponent<CharacterController>();
        animation = GetComponent<Animator>();
        currentTime = countdownTime;
        audioSource = GetComponent<AudioSource>();
        porteEntree = GameObject.FindGameObjectWithTag("PorteEntree");
        porteEntree.SetActive(false);



    }

    void Update()
    {
        if (batterypanier != null && Input.GetKeyDown(KeyCode.Space))
        {
            nombre -= 1;
            Destroy(batterypanier);
            detectionbattery.text = "AUCUNE BATTÉRIE DÉSACTIVABLE";
            batterypanier = null;

            GameObject fermeturelumiere = trouverfermeturelumiere();
            if (fermeturelumiere != null)
            {
                Destroy(fermeturelumiere);
            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            detectionEnabled = !detectionEnabled;
        }

        if (detectionEnabled)
        {
            foreach (GameObject target in targets)
            {
                if (target != null)
                {
                    DetectTarget(target);
                }
            }
        }


        currentTime -= Time.deltaTime;
        batterierestante.text = "Batterie(s) Restante(s) :" + nombre;

        if (currentTime <= 0f && nombre > 0f)
        {
            currentTime = 0f;
            defaite.text = "VOUS AVEZ PERDU";
            animation.enabled = false;
            transform.position = targetPosition;
            porteEntree.SetActive(true);
            return;


        }

        int minutes = (int)(currentTime / 60);
        int seconds = (int)(currentTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);


        if (!isFainting)
        {
            float rotation = Input.GetAxis("Horizontal") * vitesseTourner * Time.deltaTime;
            transform.Rotate(Vector3.up, rotation);

            float vertical = Input.GetAxis("Vertical") * vitesseMarcher * Time.deltaTime;
            Vector3 deplacement = new Vector3(0, 0, vertical);
            deplacement = transform.TransformDirection(deplacement);
            cPersonnage.Move(deplacement);

            bool entreeAxeVertical = !Mathf.Approximately(vertical, 0f);
            bool move = entreeAxeVertical;
            if (move)
            {
                animation.SetBool("move", true);
            }
            else
            {
                animation.SetBool("move", false);
            }
        }

        GameObject[] drones = GameObject.FindGameObjectsWithTag("drone");

        if (nombre <= 0f)
        {
            nombre = 0f;
            victoire.text = "VOUS AVEZ GAGNÉ";
            foreach (GameObject drone in drones)
            {
                Destroy(drone);
            }



        }
    }

    void DetectTarget(GameObject target)
    {
        Vector3 directionToTarget = target.transform.position - transform.position;
        float distanceToTarget = directionToTarget.magnitude;

        if (distanceToTarget <= detectionDistance)
        {
            float angleToTarget = Vector3.Angle(transform.forward, directionToTarget.normalized);

            if (angleToTarget <= detectionAngle)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, directionToTarget, out hit, detectionDistance))
                {
                    if (!isFainting)
                    {
                        StartCoroutine(Faint());
                    }
                }
            }
        }
    }

    IEnumerator Faint()
    {
        isFainting = true;
        animation.SetBool("faint", false);

        yield return new WaitForSeconds(faintDuration);

        isFainting = false;
        animation.SetBool("faint", true);
        animation.SetBool("move", false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cubes"))
        {
            currentTime += 10;
            Destroy(other.gameObject);
            audioSource.Play();
        }

        if (other.gameObject.tag == "battery")
        {
            batterypanier = other.gameObject;
            detectionbattery.text = "BATTÉRIE DÉSACTIVABLE";
        }
        else
        {
            detectionbattery.text = "AUCUNE BATTÉRIE DÉSACTIVABLE";
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "battery")
        {
            detectionbattery.text = "AUCUNE BATTÉRIE DÉSACTIVABLE";
            batterypanier = null;
        }
    }

    private GameObject trouverfermeturelumiere()  //pour cette methode,j'ai utilisé stackoverflow et je l'ai adapté
    {
        GameObject[] lumieres;
        lumieres = GameObject.FindGameObjectsWithTag("lumiere");
        GameObject fermer = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in lumieres)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                fermer = go;
                distance = curDistance;
            }
        }
        return fermer;
    }

}
