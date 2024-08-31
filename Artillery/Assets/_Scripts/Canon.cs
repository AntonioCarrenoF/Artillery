using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Canon : MonoBehaviour
{
    public static bool Bloqueado;

    public AudioClip clipDisparo;
    private GameObject SonidoDisparo;
    private AudioSource SourceDisparo;

    [SerializeField] private GameObject BalaPrefab;
    private GameObject puntaCanon;
    public GameObject ParticulasDisparo;
    private float rotacion;
    private int disparos=0;
    private float fuerza;
    public Slider slider;

    public CanonControls canonControls;
    private InputAction apuntar;
    private InputAction modificarFuerza;
    private InputAction disparar;

    private void Awake()
    {
        canonControls = new CanonControls();
    }

    private void OnEnable()
    {
        apuntar = canonControls.Canon.Apuntar;
        modificarFuerza = canonControls.Canon.ModificarFuerza;
        disparar = canonControls.Canon.Disparar;
        disparar.Enable();
        modificarFuerza.Enable();
        apuntar.Enable();
        disparar.performed += Disparar;
    }

    private void OnDisable()
    {
        disparar.Disable();
        modificarFuerza.Disable();
        apuntar.Disable();
    }


    // Start is called before the first frame update
    private void Start()
    {
        puntaCanon = transform.Find("PuntaCanon").gameObject;
        SonidoDisparo = GameObject.Find("SonidoDisparo");
        SourceDisparo = SonidoDisparo.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rotacion += apuntar.ReadValue<float>() * AdministradorJuego.VelocidadRotacion;
        if (rotacion <= 90 && rotacion >= 0)
        {
            transform.eulerAngles = new Vector3(rotacion, 90, 0.0f);
        }
        if (rotacion > 90) rotacion = 90;
        if (rotacion < 0) rotacion = 0;

        //AdministradorJuego.VelocidadBala= (int)modificarFuerza.ReadValue<float>();
        //slider.value = AdministradorJuego.VelocidadBala;


    }

    private void Disparar(InputAction.CallbackContext context)
    {
        if (AdministradorJuego.DisparosPorJuego>0 && Bloqueado==false)
        {
            disparos++;
            GameObject temp = Instantiate(BalaPrefab, puntaCanon.transform.position, transform.rotation);
            Rigidbody tempRB = temp.GetComponent<Rigidbody>();
            SeguirCamara.objetivo = temp;
            Vector3 direccionDisparo = transform.rotation.eulerAngles;
            direccionDisparo.y = 90 - direccionDisparo.x;
            Vector3 direccionParticulas = new Vector3(-90 + direccionDisparo.x, 90, 0);
            GameObject Particulas = Instantiate(ParticulasDisparo, puntaCanon.transform.position, Quaternion.Euler(direccionParticulas), transform);
            tempRB.velocity = direccionDisparo.normalized * AdministradorJuego.VelocidadBala;
            AdministradorJuego.DisparosPorJuego--;
            SourceDisparo.Play();
            Bloqueado = true;

        }

    }
}
