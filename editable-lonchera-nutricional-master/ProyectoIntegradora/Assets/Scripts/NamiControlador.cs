using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using System;

public class NamiControlador : MonoBehaviour {
    public ControladorTiempo tiempo;
    public ControladorVidas vidas;
    public ControladorPuntaje puntaje;
    public ContadorAlimentos contAli;
    public Controladorlonchera lonchera;
    [SerializeField] private Transform nami;
    [SerializeField] private Transform constructor;
    public Vector3 initialPosition;
    public Vector2 mousepostion;
    public float deltaX, deltaY;
    public static bool locked;
    public Animator anim,anim2;
    public float manzana;
    public GameObject poptext;
    public AudioSource audioNamiFeliz;
    public new ControladorAudio audio;
    public ControladorBandera bandera;
    public GameObject explosioneffect,estrellaeffect;
    //public Animation anim;

    // Use this for initialization
    void Start () {
        bandera = FindObjectOfType<ControladorBandera>();
        audio = FindObjectOfType<ControladorAudio>();
        if (SceneManager.GetSceneByName("Lonchera").isLoaded)
        {
            contAli = FindObjectOfType<ContadorAlimentos>();
            lonchera = FindObjectOfType<Controladorlonchera>();
            vidas = FindObjectOfType<ControladorVidas>();
            
            GameObject.Find("Reguladores-seleccionado").GetComponent<Renderer>().enabled = false;
            GameObject.Find("Constructores-seleccionado").GetComponent<Renderer>().enabled = false;
            GameObject.Find("Energeticos-seleccionado").GetComponent<Renderer>().enabled = false;

        }

    }

    private void Awake()
    {
     
    }

    private void OnMouseDown()
    {
      // print("tocar");
        if (!locked)
        {
            //print(gameObject.transform.position);
            initialPosition = gameObject.transform.position;
            // initialPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;

          

        }
    }

    private void OnMouseDrag()
    {
       
            //print("cojiendo");
            if (!locked)
        {

            // SceneManager.GetSceneByName("Juego");

            //if (SceneManager.GetSceneByName(bandera.tempNombre).isLoaded)
            if (SceneManager.GetSceneByName("juego").isLoaded || SceneManager.GetSceneByName("juego2").isLoaded || SceneManager.GetSceneByName("juego3").isLoaded)
            {
                mousepostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = new Vector2(mousepostion.x - deltaX, mousepostion.y - deltaY);
            }

            else if (SceneManager.GetSceneByName("Lonchera").isLoaded)
            {


                if ((lonchera.regulador >= 100 && lonchera.energetico >= 100 && lonchera.constructor >= 100)|| vidas.contVidas==0)
                {
                    print("desactivando ayuda");
                }
                else
                {
                    mousepostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    transform.position = new Vector2(mousepostion.x - deltaX, mousepostion.y - deltaY);
                    if (gameObject.tag == "manzana" || gameObject.tag == "frutilla" || gameObject.tag == "guineo" || gameObject.tag == "mandarina" || gameObject.tag == "uva" || gameObject.tag == "zanahoria" || gameObject.tag == "brocoli" || gameObject.tag == "tomate" || gameObject.tag == "pepino" || gameObject.tag == "aguacate")
                    {
                        GameObject.Find("Reguladores").GetComponent<Renderer>().enabled = false;
                        GameObject.Find("Reguladores-seleccionado").GetComponent<Renderer>().enabled = true;
                        GameObject.Find("Reguladores-parte1").GetComponent<Renderer>().enabled = false;
                        GameObject.Find("Reguladores-parte2").GetComponent<Renderer>().enabled = false;
                        GameObject.Find("Reguladores-parte3").GetComponent<Renderer>().enabled = false;



                    }

                    if (gameObject.tag == "maduroasado" || gameObject.tag == "sanduche" || gameObject.tag == "tortillaverde")
                    {
                        GameObject.Find("Energeticos").GetComponent<Renderer>().enabled = false;
                        GameObject.Find("Energeticos-seleccionado").GetComponent<Renderer>().enabled = true;

                        GameObject.Find("Energeticos-parte1").GetComponent<Renderer>().enabled = false;
                        GameObject.Find("Energeticos-parte2").GetComponent<Renderer>().enabled = false;


                    }

                    if (gameObject.tag == "queso" || gameObject.tag == "huevodeoro" || gameObject.tag == "leche")
                    {
                        GameObject.Find("Constructores").GetComponent<Renderer>().enabled = false;
                        GameObject.Find("Constructores-seleccionado").GetComponent<Renderer>().enabled = true;
                        GameObject.Find("Constructores-parte1").GetComponent<Renderer>().enabled = false;
                        GameObject.Find("Constructores-parte2").GetComponent<Renderer>().enabled = false;



                    }
                }
            }
        }
    
    }
    private void OnMouseUp()
    {
        //print("soltando");
        //print(gameObject.transform.position);
        if (SceneManager.GetSceneByName("Lonchera").isLoaded )
        {

            if ((lonchera.regulador >= 100 && lonchera.energetico >= 100 && lonchera.constructor >= 100) || vidas.contVidas == 0)
            {
                print("desactivando ayuda");
            }
            else
            {
                if (gameObject.tag == "manzana" || gameObject.tag == "frutilla" || gameObject.tag == "guineo" || gameObject.tag == "mandarina" || gameObject.tag == "uva" || gameObject.tag == "zanahoria" || gameObject.tag == "brocoli" || gameObject.tag == "tomate" || gameObject.tag == "pepino" || gameObject.tag == "aguacate")
                {
                    GameObject.Find("Reguladores").GetComponent<Renderer>().enabled = true;
                    GameObject.Find("Reguladores-seleccionado").GetComponent<Renderer>().enabled = false;


                }

                if (gameObject.tag == "maduroasado" || gameObject.tag == "sanduche" || gameObject.tag == "tortillaverde")
                {
                    GameObject.Find("Energeticos").GetComponent<Renderer>().enabled = true;
                    GameObject.Find("Energeticos-seleccionado").GetComponent<Renderer>().enabled = false;
                }

                if (gameObject.tag == "queso" || gameObject.tag == "huevodeoro" || gameObject.tag == "leche")
                {
                    GameObject.Find("Constructores").GetComponent<Renderer>().enabled = true;
                    GameObject.Find("Constructores-seleccionado").GetComponent<Renderer>().enabled = false;
                }


                lonchera = FindObjectOfType<Controladorlonchera>();
                if (lonchera.regulador >= 25 && lonchera.regulador <= 74)
                {
                    GameObject.Find("Reguladores-parte1").GetComponent<Renderer>().enabled = true;
                }
                if (lonchera.regulador >= 75 && lonchera.regulador <= 99)
                {
                    GameObject.Find("Reguladores-parte2").GetComponent<Renderer>().enabled = true;
                }

                if (lonchera.regulador >= 100)
                {
                    GameObject.Find("Reguladores-parte3").GetComponent<Renderer>().enabled = true;
                }


                if (lonchera.energetico >= 50 && lonchera.energetico <= 74)
                {
                    GameObject.Find("Energeticos-parte1").GetComponent<Renderer>().enabled = true;
                }
                if (lonchera.energetico >= 75 && lonchera.energetico <= 100)
                {
                    GameObject.Find("Energeticos-parte2").GetComponent<Renderer>().enabled = true;
                }

                if (lonchera.constructor >= 50 && lonchera.constructor <= 74)
                {
                    GameObject.Find("Constructores-parte1").GetComponent<Renderer>().enabled = true;
                }
                if (lonchera.constructor >= 75 && lonchera.constructor <= 100)
                {
                    GameObject.Find("Constructores-parte2").GetComponent<Renderer>().enabled = true;
                }
            }
              

            

         

            transform.position = initialPosition;
            
        }
       
       /* if (gameObject.name == "manzanalonchera(Clone)")
        {

        }*/


    }

  
   public void efectoExplosion()
    {
        Instantiate(explosioneffect, transform.position, Quaternion.identity);//Instanciar en el lugar de la destruccion
    }

    public void efectoEstrella()
    {
        Instantiate(estrellaeffect, transform.position, Quaternion.identity);//Instanciar en el lugar de la destruccion
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //ESCENA JUEGO

        if (col.gameObject.tag == "nami")
        {
           // tiempo = FindObjectOfType<ControladorTiempo>();
            puntaje = FindObjectOfType<ControladorPuntaje>();
            contAli = FindObjectOfType<ContadorAlimentos>();
            vidas = FindObjectOfType<ControladorVidas>();

           // puntaje.IncrementarPuntaje(gameObject.tag);


            anim = col.gameObject.GetComponent<Animator>();

            //instruction =  GameObject.Find("poptext").GetComponent<Text>();
            poptext = GameObject.Find("poptext");
      
            anim2 = poptext.GetComponent<Animator>();

           
            anim2.SetTrigger("puntos");
           
            //print(gameObject);

            if (gameObject.tag == "manzana")
            {
                puntaje.IncrementarPuntaje(gameObject.tag);
                contAli.IncrementarAlimentos("manzana");
                audio.playNamiFeliz();
                anim.SetTrigger("salto");
                efectoEstrella();
                //  print("manzana: " + contAli.manzana);

            }

            if (gameObject.tag == "frutilla")
            {
                puntaje.IncrementarPuntaje(gameObject.tag);
                contAli.IncrementarAlimentos("frutilla");
                audio.playNamiFeliz();
                anim.SetTrigger("salto");
                efectoEstrella();
                //  print("frutilla: " + contAli.frutilla);

            }

            if (gameObject.tag == "guineo")
            {
                puntaje.IncrementarPuntaje(gameObject.tag);
                contAli.IncrementarAlimentos("guineo");
                audio.playNamiFeliz();
                anim.SetTrigger("salto");
                efectoEstrella();
                //  print("guineo: " + contAli.guineo);

            }

            if (gameObject.tag == "mandarina")
            {
                puntaje.IncrementarPuntaje(gameObject.tag);
                contAli.IncrementarAlimentos("mandarina");
                audio.playNamiFeliz();
                anim.SetTrigger("salto");
                efectoEstrella();
                // print("mandarina: " + contAli.mandarina);

            }

            if (gameObject.tag == "uva")
            {
                puntaje.IncrementarPuntaje(gameObject.tag);
                contAli.IncrementarAlimentos("uva");
                audio.playNamiFeliz();
                anim.SetTrigger("salto");
                efectoEstrella();
                // print("uva: " + contAli.uva);

            }

            if (gameObject.tag == "zanahoria")
            {
                puntaje.IncrementarPuntaje(gameObject.tag);
                contAli.IncrementarAlimentos("zanahoria");
                audio.playNamiFeliz();
                anim.SetTrigger("salto");
                efectoEstrella();
                // print("zanahoria: " + contAli.zanahoria);

            }

            if (gameObject.tag == "sanduche")
            {
                puntaje.IncrementarPuntaje(gameObject.tag);
                contAli.IncrementarAlimentos("sanduche");
                audio.playNamiFeliz();
                anim.SetTrigger("salto");
                efectoEstrella();
                //  print("sanduche: " + contAli.sanduche);

            }

            if (gameObject.tag == "tortillaverde")
            {
                puntaje.IncrementarPuntaje(gameObject.tag);
                contAli.IncrementarAlimentos("tortillaverde");
                audio.playNamiFeliz();
                anim.SetTrigger("salto");
                efectoEstrella();
                //  print("tortillaverde: " + contAli.tortillaverde);

            }

            if (gameObject.tag == "maduroasado")
            {
                puntaje.IncrementarPuntaje(gameObject.tag);
                contAli.IncrementarAlimentos("maduroasado");
                audio.playNamiFeliz();
                anim.SetTrigger("salto");
                efectoEstrella();
                // print("maduroasado: " + contAli.maduroasado);

            }

            if (gameObject.tag == "huevodeoro")
            {
                puntaje.IncrementarPuntaje(gameObject.tag);
                contAli.IncrementarAlimentos("huevodeoro");
                audio.playNamiFeliz();
                anim.SetTrigger("salto");
                efectoEstrella();
                //  print("huevodeoro: " + contAli.huevodeoro);

            }

            if (gameObject.tag == "queso")
            {
                puntaje.IncrementarPuntaje(gameObject.tag);
                contAli.IncrementarAlimentos("queso");
                audio.playNamiFeliz();
                anim.SetTrigger("salto");
                efectoEstrella();
                //   print("queso: " + contAli.queso);

            }

            if (gameObject.tag == "brocoli")
            {
                puntaje.IncrementarPuntaje(gameObject.tag);
                contAli.IncrementarAlimentos("brocoli");
                audio.playNamiFeliz();
                anim.SetTrigger("salto");
                efectoEstrella();
                //  print("brocoli: " + contAli.brocoli);

            }

            if (gameObject.tag == "pepino")
            {
                puntaje.IncrementarPuntaje(gameObject.tag);
                contAli.IncrementarAlimentos("pepino");
                audio.playNamiFeliz();
                anim.SetTrigger("salto");
                efectoEstrella();
                //  print("pepino: " + contAli.pepino);

            }

            if (gameObject.tag == "tomate")
            {
                puntaje.IncrementarPuntaje(gameObject.tag);
                contAli.IncrementarAlimentos("tomate");
                audio.playNamiFeliz();
                anim.SetTrigger("salto");
                efectoEstrella();
                //  print("tomate: " + contAli.tomate);

            }

            if (gameObject.tag == "leche")
            {
                puntaje.IncrementarPuntaje(gameObject.tag);
                contAli.IncrementarAlimentos("leche");
                audio.playNamiFeliz();
                anim.SetTrigger("salto");
                efectoEstrella();
                //  print("leche: " + contAli.leche);

            }

            if (gameObject.tag == "aguacate")
            {
                puntaje.IncrementarPuntaje(gameObject.tag);
                contAli.IncrementarAlimentos("aguacate");
                audio.playNamiFeliz();
                anim.SetTrigger("salto");
                efectoEstrella();
                // print("aguacate: " + contAli.aguacate);

            }

            if (gameObject.tag == "chatarra")
            {
                anim.SetTrigger("triste");
                // contAli.IncrementarAlimentos("chatarra");
                if (SceneManager.GetSceneByName("Juego2").isLoaded || SceneManager.GetSceneByName("Juego3").isLoaded)
                {
                    vidas.RestarVidas();
                }
                efectoExplosion();
                audio.playDestruir();
                puntaje.RestarPuntaje(gameObject.tag);
                audio.playNamiTriste();
            }


            Destroy(gameObject);
           
            //print("Animacion ");
        }
        if (col.gameObject.tag == "colector")
        {
            efectoExplosion();
            audio.playDestruir();
        }

            if (SceneManager.GetSceneByName("Lonchera").isLoaded)
        {
            //ESCENA LONCHERA
            GameObject.Find("Reguladores").GetComponent<Renderer>().enabled = true;
            GameObject.Find("Energeticos").GetComponent<Renderer>().enabled = true;
            GameObject.Find("Constructores").GetComponent<Renderer>().enabled = true;
            GameObject.Find("Reguladores-seleccionado").GetComponent<Renderer>().enabled = false;
            GameObject.Find("Constructores-seleccionado").GetComponent<Renderer>().enabled = false;
            GameObject.Find("Energeticos-seleccionado").GetComponent<Renderer>().enabled = false;
            //lonchera.verificarLonchera();
            //REGULADORES
            if (col.gameObject.tag == "reguladores")
            {
                
            //    contAli = FindObjectOfType<ContadorAlimentos>();
              //  lonchera = FindObjectOfType<Controladorlonchera>();

                //50% - 1 UNIDAD
                if (gameObject.tag == "manzana")
                {
                    lonchera.temp = lonchera.regulador;
                   
                    if (lonchera.regulador < 100)
                    {
                        if (contAli.manzana > 1)
                        {
                            contAli.manzana--;
                            print(contAli.manzana + "");
                            Destroy(gameObject);
                            lonchera.crearManzana();
                        }
                        else if (contAli.manzana <= 1)
                        {
                            contAli.manzana--;
                            Destroy(gameObject);
                            print("destruyendo :)");
                        }
                        lonchera.regulador = lonchera.regulador + 50;
                        lonchera.manzanaLon++;
                        lonchera.milonchera[0] = (lonchera.manzanaLon);
                    }
                    else if (gameObject.tag == "manzana" && lonchera.regulador >= 100)
                    {
                        //lonchera.verificarLonchera();
                        lonchera.regulador = lonchera.temp;
                        print("Ya tienes el 100% de reguladores:" + lonchera.regulador);
                    }


                }

               

                ///////////////////////////////////////////////////////////////////////////////////////////

                //50% - 9 UNIDADES
                else if (gameObject.tag == "frutilla")
                {
                    lonchera.temp = lonchera.regulador;
                   
                    if (lonchera.regulador < 100)
                    {
                        if (contAli.frutilla > 1)
                        {
                            contAli.frutilla--;
                            print(contAli.frutilla + "");
                            Destroy(gameObject);
                            lonchera.crearFrutilla();
                        }
                        else if (contAli.frutilla <= 1)
                        {
                            contAli.frutilla--;
                            Destroy(gameObject);
                            print("destruyendo :)");
                        }
                        lonchera.regulador = lonchera.regulador + 25;
                        lonchera.frutillaLon= lonchera.frutillaLon+9;
                        lonchera.milonchera[1] = (lonchera.frutillaLon);
                    }
                    else if (gameObject.tag == "frutilla" && lonchera.regulador >= 100)
                    {
                        //lonchera.verificarLonchera();
                        lonchera.regulador = lonchera.temp;
                        print("Ya tienes el 100% de reguladores:" + lonchera.regulador);
                    }



                }

              
                ///////////////////////////////////////////////////////////////////////////////////////////

                //50% - 1 UNIDAD
                else if (gameObject.tag == "guineo")
                {
                    lonchera.temp = lonchera.regulador;
                    
                    if (lonchera.regulador < 100)
                    {
                        if (contAli.guineo > 1)
                        {

                            contAli.guineo--;
                            Destroy(gameObject);
                            lonchera.crearPlatano();
                        }
                        else if (contAli.guineo <= 1)
                        {
                            contAli.guineo--;
                            Destroy(gameObject);
                        }
                        lonchera.regulador = lonchera.regulador + 50;
                        lonchera.guineoLon++;
                        lonchera.milonchera[2] = (lonchera.guineoLon);
                    }
                    else if (gameObject.tag == "guineo" && lonchera.regulador >= 100)
                    {
                        lonchera.regulador = lonchera.temp;
                        print("Ya tienes el 100% de reguladores:" + lonchera.regulador);
                    }

                }

                

                ///////////////////////////////////////////////////////////////////////////////////////////

                //25% - 1 UNIDAD
                else if (gameObject.tag == "mandarina")
                {
                    lonchera.temp = lonchera.regulador;
                   
                    if (lonchera.regulador < 100)
                    {
                        if (contAli.mandarina > 1)
                        {

                            contAli.mandarina--;
                            Destroy(gameObject);
                            lonchera.crearMandarina();
                        }
                        else if (contAli.mandarina <= 1)
                        {
                            contAli.mandarina--;
                            Destroy(gameObject);
                        }
                        lonchera.regulador = lonchera.regulador + 50;
                        lonchera.mandarinaLon++;
                        lonchera.milonchera[3] = (lonchera.mandarinaLon);
                    }
                    else if (gameObject.tag == "mandarina" && lonchera.regulador >= 100)
                    {
                        lonchera.regulador = lonchera.temp;
                        print("Ya tienes el 100% de reguladores:" + lonchera.regulador);
                    }


                }

              

                ///////////////////////////////////////////////////////////////////////////////////////////

                //25% - 6 UNIDADES
                else if (gameObject.tag == "uva")
                {
                    lonchera.temp = lonchera.regulador;
                  
                    if (lonchera.regulador < 100)
                    {
                        if (contAli.uva > 1)
                        {

                            contAli.uva--;
                            Destroy(gameObject);
                            lonchera.crearUva();
                        }
                        else if (contAli.uva <= 1)
                        {
                            contAli.uva--;
                            Destroy(gameObject);
                        }
                        lonchera.regulador = lonchera.regulador + 25;
                        lonchera.uvaLon= lonchera.uvaLon+12;
                        lonchera.milonchera[4] = (lonchera.uvaLon);
                    }
                    else if (gameObject.tag == "uva" && lonchera.regulador >= 100)
                    {
                        lonchera.regulador = lonchera.temp;
                        print("Ya tienes el 100% de reguladores:" + lonchera.regulador);
                    }

                }

               

                ///////////////////////////////////////////////////////////////////////////////////////////

                //25% - 1 UNIDAD
                else if (gameObject.tag == "zanahoria")
                {
                    lonchera.temp = lonchera.regulador;
                   
                    if (lonchera.regulador < 100)
                    {
                        if (contAli.zanahoria > 1)
                        {

                            contAli.zanahoria--;
                            Destroy(gameObject);
                            lonchera.crearZanahoria();
                        }
                        else if (contAli.zanahoria <= 1)
                        {
                            contAli.zanahoria--;
                            Destroy(gameObject);
                        }
                        lonchera.regulador = lonchera.regulador + 50;
                        lonchera.zanahoriaLon++;
                        lonchera.milonchera[5] = (lonchera.zanahoriaLon);
                    }
                    else if (gameObject.tag == "zanahoria" && lonchera.regulador >= 100)
                    {
                        lonchera.regulador = lonchera.temp;
                        print("Ya tienes el 100% de reguladores:" + lonchera.regulador);
                    }

                }

                ///////////////////////////////////////////////////////////////////////////////////////////

                //25% - 1 UNIDAD
                else if (gameObject.tag == "brocoli")
                {
                    lonchera.temp = lonchera.regulador;
                   
                    if (lonchera.regulador < 100)
                    {
                        if (contAli.brocoli > 1)
                        {

                            contAli.brocoli--;
                            Destroy(gameObject);
                            lonchera.crearBrocoli();
                        }
                        else if (contAli.brocoli <= 1)
                        {
                            contAli.brocoli--;
                            Destroy(gameObject);
                        }
                        lonchera.regulador = lonchera.regulador + 25;
                        lonchera.brocoliLon++;
                        lonchera.milonchera[11] = (lonchera.brocoliLon);
                    }
                    else if (gameObject.tag == "brocoli" && lonchera.regulador >= 100)
                    {
                        lonchera.regulador = lonchera.temp;
                        print("Ya tienes el 100% de reguladores:" + lonchera.regulador);
                    }

                }

                ///////////////////////////////////////////////////////////////////////////////////////////

                //25% - 1 UNIDAD
                else if (gameObject.tag == "pepino")
                {
                    lonchera.temp = lonchera.regulador;
                  
                    if (lonchera.regulador < 100)
                    {
                        if (contAli.pepino > 1)
                        {

                            contAli.pepino--;
                            Destroy(gameObject);
                            lonchera.crearPepino();
                        }
                        else if (contAli.pepino <= 1)
                        {
                            contAli.pepino--;
                            Destroy(gameObject);
                        }
                        lonchera.regulador = lonchera.regulador + 50;
                        lonchera.pepinoLon++;
                        lonchera.milonchera[12] = (lonchera.pepinoLon);
                    }
                    else if (gameObject.tag == "pepino" && lonchera.regulador >= 100)
                    {
                        lonchera.regulador = lonchera.temp;
                        print("Ya tienes el 100% de reguladores:" + lonchera.regulador);
                    }

                }

                else if (gameObject.tag == "tomate")
                {
                    lonchera.temp = lonchera.regulador;
                  
                    if (lonchera.regulador < 100)
                    {
                        if (contAli.tomate > 1)
                        {

                            contAli.tomate--;
                            Destroy(gameObject);
                            lonchera.crearTomate();
                        }
                        else if (contAli.tomate <= 1)
                        {
                            contAli.tomate--;
                            Destroy(gameObject);
                        }
                        lonchera.regulador = lonchera.regulador + 50;
                        lonchera.tomateLon++;
                        lonchera.milonchera[13] = (lonchera.tomateLon);
                    }
                    else if (gameObject.tag == "tomate" && lonchera.regulador >= 100)
                    {
                        lonchera.regulador = lonchera.temp;
                        print("Ya tienes el 100% de reguladores:" + lonchera.regulador);
                    }

                }

                else if (gameObject.tag == "aguacate")
                {
                    lonchera.temp = lonchera.regulador;
                   
                    if (lonchera.regulador < 100)
                    {
                        if (contAli.aguacate > 1)
                        {

                            contAli.aguacate--;
                            Destroy(gameObject);
                            lonchera.crearAguacate();
                        }
                        else if (contAli.aguacate <= 1)
                        {
                            contAli.aguacate--;
                            Destroy(gameObject);
                        }
                        lonchera.regulador = lonchera.regulador + 50;
                        lonchera.aguacateLon++;
                        lonchera.milonchera[14] = (lonchera.aguacateLon);
                    }
                    else if (gameObject.tag == "aguacate" && lonchera.regulador >= 100)
                    {
                        lonchera.regulador = lonchera.temp;
                        print("Ya tienes el 100% de reguladores:" + lonchera.regulador);
                    }

                }

              /*  else
                {
                    //REGULADORES INCORRECTOS

                    if (lonchera.regulador < 100)
                    {
                        if (gameObject.tag == "queso")
                        {
                            if (contAli.queso > 1)
                            {

                                contAli.queso--;
                                Destroy(gameObject);
                                lonchera.crearQueso();
                            }
                            else if (contAli.queso <= 1)
                            {
                                contAli.queso--;
                                Destroy(gameObject);
                            }
                        }

                        if (gameObject.tag == "huevodeoro")
                        {
                            if (contAli.huevodeoro > 1)
                            {

                                contAli.huevodeoro--;
                                Destroy(gameObject);
                                lonchera.crearHuevo();
                            }
                            else if (contAli.huevodeoro <= 1)
                            {
                                contAli.huevodeoro--;
                                Destroy(gameObject);
                            }
                        }

                        if (gameObject.tag == "leche")
                        {
                            if (contAli.leche > 1)
                            {

                                contAli.leche--;
                                Destroy(gameObject);
                                lonchera.crearLeche();
                            }
                            else if (contAli.leche <= 1)
                            {
                                contAli.leche--;
                                Destroy(gameObject);
                            }
                        }

                        if (gameObject.tag == "maduroasado")
                        {
                            if (contAli.maduroasado > 1)
                            {
                                contAli.maduroasado--;
                                Destroy(gameObject);
                                lonchera.crearMaduro();
                            }
                            else if (contAli.maduroasado <= 1)
                            {
                                contAli.maduroasado--;
                                Destroy(gameObject);
                            }
                        }

                        if (gameObject.tag == "sanduche")
                        {
                            if (contAli.sanduche > 1)
                            {

                                contAli.sanduche--;
                                Destroy(gameObject);
                                lonchera.crearSanduche();
                            }
                            else if (contAli.sanduche <= 1)
                            {
                                contAli.sanduche--;
                                Destroy(gameObject);
                            }
                        }

                        if (gameObject.tag == "tortillaverde")
                        {
                            if (contAli.tortillaverde > 1)
                            {

                                contAli.tortillaverde--;
                                Destroy(gameObject);
                                lonchera.crearTortilla();
                            }
                            else if (contAli.tortillaverde <= 1)
                            {
                                contAli.tortillaverde--;
                                Destroy(gameObject);
                            }
                        }

                        vidas.RestarVidasLonchera();
                    }

                }*/




                ///////////////////////////////////////////////////////////////////////////////////////////
                if (lonchera.regulador >= 25 && lonchera.regulador <= 74)
                {
                    GameObject.Find("Reguladores-parte1").GetComponent<Renderer>().enabled = true;
                }
                if (lonchera.regulador >= 75 && lonchera.regulador <= 99)
                {
                    GameObject.Find("Reguladores-parte2").GetComponent<Renderer>().enabled = true;
                }

                if (lonchera.regulador >= 100)
                {
                    GameObject.Find("Reguladores-parte3").GetComponent<Renderer>().enabled = true;
                }

                lonchera.verificarLonchera();
            }


            //ENERGETICOS
            if (col.gameObject.tag == "energeticos")
            {
               
            //    contAli = FindObjectOfType<ContadorAlimentos>();
              //  lonchera = FindObjectOfType<Controladorlonchera>();



                //30% - 1 UNIDAD
                if (gameObject.tag == "maduroasado")
                {
                    lonchera.temp = lonchera.energetico;
                   
                    if (lonchera.energetico < 100)
                    {
                        if (contAli.maduroasado > 1)
                        {
                            contAli.maduroasado--;
                            Destroy(gameObject);
                            lonchera.crearMaduro();
                        }
                        else if (contAli.maduroasado <= 1)
                        {
                            contAli.maduroasado--;
                            Destroy(gameObject);
                        }
                        lonchera.energetico = lonchera.energetico + 50;
                        lonchera.maduroLon++;
                        //print("espacios: "+lonchera.milonchera.Length);
                        lonchera.milonchera[6] = (lonchera.maduroLon);
                    }
                    else if (gameObject.tag == "maduroasado" && lonchera.energetico >= 100)
                    {
                        lonchera.energetico = lonchera.temp;
                        print("Ya tienes el 30% de energeticos:" + lonchera.energetico);
                    }


                }

             

                ///////////////////////////////////////////////////////////////////////////////////////////

                //30% - 1 UNIDAD
                else if (gameObject.tag == "sanduche")
                {
                    lonchera.temp = lonchera.energetico;
                   
                    if (lonchera.energetico < 100)
                    {
                        if (contAli.sanduche > 1)
                        {

                            contAli.sanduche--;
                            Destroy(gameObject);
                            lonchera.crearSanduche();
                        }
                        else if (contAli.sanduche <= 1)
                        {
                            contAli.sanduche--;
                            Destroy(gameObject);
                        }
                        lonchera.energetico = lonchera.energetico + 50;
                        lonchera.sanducheLon++;
                        // print("espacios: " + lonchera.milonchera.Length);
                        lonchera.milonchera[7] = (lonchera.sanducheLon);
                    }
                    else if (gameObject.tag == "sanduche" && lonchera.energetico >= 100)
                    {
                        lonchera.energetico = lonchera.temp;
                        print("Ya tienes el 30% de energeticos:" + lonchera.energetico);
                    }

                }

            

                ///////////////////////////////////////////////////////////////////////////////////////////

                //30% - 1 UNIDAD
                else if (gameObject.tag == "tortillaverde")
                {
                    lonchera.temp = lonchera.energetico;
                  
                    if (lonchera.energetico < 100)
                    {
                        if (contAli.tortillaverde > 1)
                        {

                            contAli.tortillaverde--;
                            Destroy(gameObject);
                            lonchera.crearTortilla();
                        }
                        else if (contAli.tortillaverde <= 1)
                        {
                            contAli.tortillaverde--;
                            Destroy(gameObject);
                        }
                        lonchera.energetico = lonchera.energetico + 50;
                        lonchera.tortillaLon++;
                        lonchera.milonchera[8] = (lonchera.tortillaLon);
                    }
                    else if (gameObject.tag == "tortillaverde" && lonchera.energetico >= 100)
                    {
                        lonchera.energetico = lonchera.temp;
                        print("Ya tienes el 30% de energeticos:" + lonchera.energetico);
                    }

                }

                //ENERGETICOS INCORRECTOS
/*
                else
                {
                    if (lonchera.energetico < 100)
                    {
                        if (gameObject.tag == "manzana")
                        {
                            if (contAli.manzana > 1)
                            {
                                contAli.manzana--;
                                print(contAli.manzana + "");
                                Destroy(gameObject);
                                lonchera.crearManzana();
                            }
                            else if (contAli.manzana <= 1)
                            {
                                contAli.manzana--;
                                Destroy(gameObject);
                                print("destruyendo :)");
                            }

                        }

                        if (gameObject.tag == "frutilla")
                        {
                            if (contAli.frutilla > 1)
                            {
                                contAli.frutilla--;
                                print(contAli.frutilla + "");
                                Destroy(gameObject);
                                lonchera.crearFrutilla();
                            }
                            else if (contAli.frutilla <= 1)
                            {
                                contAli.frutilla--;
                                Destroy(gameObject);
                                print("destruyendo :)");
                            }

                        }

                        if (gameObject.tag == "guineo")
                        {
                            if (contAli.guineo > 1)
                            {

                                contAli.guineo--;
                                Destroy(gameObject);
                                lonchera.crearPlatano();
                            }
                            else if (contAli.guineo <= 1)
                            {
                                contAli.guineo--;
                                Destroy(gameObject);
                            }
                        }

                        if (gameObject.tag == "mandarina")
                        {
                            if (contAli.mandarina > 1)
                            {

                                contAli.mandarina--;
                                Destroy(gameObject);
                                lonchera.crearMandarina();
                            }
                            else if (contAli.mandarina <= 1)
                            {
                                contAli.mandarina--;
                                Destroy(gameObject);
                            }
                        }

                        if (gameObject.tag == "uva")
                        {
                            if (contAli.uva > 1)
                            {

                                contAli.uva--;
                                Destroy(gameObject);
                                lonchera.crearUva();
                            }
                            else if (contAli.uva <= 1)
                            {
                                contAli.uva--;
                                Destroy(gameObject);
                            }
                        }

                        if (gameObject.tag == "zanahoria")
                        {
                            if (contAli.zanahoria > 1)
                            {

                                contAli.zanahoria--;
                                Destroy(gameObject);
                                lonchera.crearZanahoria();
                            }
                            else if (contAli.zanahoria <= 1)
                            {
                                contAli.zanahoria--;
                                Destroy(gameObject);
                            }
                        }

                        if (gameObject.tag == "brocoli")
                        {
                            if (contAli.brocoli > 1)
                            {

                                contAli.brocoli--;
                                Destroy(gameObject);
                                lonchera.crearBrocoli();
                            }
                            else if (contAli.brocoli <= 1)
                            {
                                contAli.brocoli--;
                                Destroy(gameObject);
                            }
                        }

                        if (gameObject.tag == "pepino")
                        {
                            if (contAli.pepino > 1)
                            {

                                contAli.pepino--;
                                Destroy(gameObject);
                                lonchera.crearPepino();
                            }
                            else if (contAli.pepino <= 1)
                            {
                                contAli.pepino--;
                                Destroy(gameObject);
                            }
                        }

                        if (gameObject.tag == "tomate")
                        {
                            if (contAli.tomate > 1)
                            {

                                contAli.tomate--;
                                Destroy(gameObject);
                                lonchera.crearTomate();
                            }
                            else if (contAli.tomate <= 1)
                            {
                                contAli.tomate--;
                                Destroy(gameObject);
                            }
                        }

                        if (gameObject.tag == "aguacate")
                        {
                            if (contAli.aguacate > 1)
                            {

                                contAli.aguacate--;
                                Destroy(gameObject);
                                lonchera.crearAguacate();
                            }
                            else if (contAli.aguacate <= 1)
                            {
                                contAli.aguacate--;
                                Destroy(gameObject);
                            }
                        }

                        if (gameObject.tag == "queso")
                        {
                            if (contAli.queso > 1)
                            {

                                contAli.queso--;
                                Destroy(gameObject);
                                lonchera.crearQueso();
                            }
                            else if (contAli.queso <= 1)
                            {
                                contAli.queso--;
                                Destroy(gameObject);
                            }
                        }

                        if (gameObject.tag == "huevodeoro")
                        {
                            if (contAli.huevodeoro > 1)
                            {

                                contAli.huevodeoro--;
                                Destroy(gameObject);
                                lonchera.crearHuevo();
                            }
                            else if (contAli.huevodeoro <= 1)
                            {
                                contAli.huevodeoro--;
                                Destroy(gameObject);
                            }
                        }

                        if (gameObject.tag == "leche")
                        {
                            if (contAli.leche > 1)
                            {

                                contAli.leche--;
                                Destroy(gameObject);
                                lonchera.crearLeche();
                            }
                            else if (contAli.leche <= 1)
                            {
                                contAli.leche--;
                                Destroy(gameObject);
                            }
                        }


                            vidas.RestarVidasLonchera();
                    }
                  

                }*/

               
                if (lonchera.energetico >= 50 && lonchera.energetico <= 74)
                {
                    GameObject.Find("Energeticos-parte1").GetComponent<Renderer>().enabled = true;
                }
                if (lonchera.energetico >= 75 && lonchera.energetico <= 100)
                {
                    GameObject.Find("Energeticos-parte2").GetComponent<Renderer>().enabled = true;
                }

                ///////////////////////////////////////////////////////////////////////////////////////////
                lonchera.verificarLonchera();
            }

            //CONSTRUCTORES
            if (col.gameObject.tag == "constructores")
            {
                
             //   contAli = FindObjectOfType<ContadorAlimentos>();
               // lonchera = FindObjectOfType<Controladorlonchera>();

                //20% - 1 UNIDAD
                if (gameObject.tag == "queso")
                {
                    lonchera.temp = lonchera.constructor;
                 
                    if (lonchera.constructor < 100)
                    {
                        if (contAli.queso > 1)
                        {

                            contAli.queso--;
                            Destroy(gameObject);
                            lonchera.crearQueso();
                        }
                        else if (contAli.queso <= 1)
                        {
                            contAli.queso--;
                            Destroy(gameObject);
                        }
                        lonchera.constructor = lonchera.constructor + 50;
                        lonchera.quesoLon++;
                        lonchera.milonchera[9] = (lonchera.quesoLon);
                    }
                    else if (gameObject.tag == "queso" && lonchera.constructor >= 100)
                    {
                        lonchera.constructor = lonchera.temp;
                        print("Ya tienes el 20% de constructores:" + lonchera.constructor);
                    }

                }

           

                ///////////////////////////////////////////////////////////////////////////////////////////

                //20% - 1 UNIDAD
                else if (gameObject.tag == "huevodeoro")
                {
                    lonchera.temp = lonchera.constructor;
                   
                    if (lonchera.constructor < 100)
                    {
                        if (contAli.huevodeoro > 1)
                        {

                            contAli.huevodeoro--;
                            Destroy(gameObject);
                            lonchera.crearHuevo();
                        }
                        else if (contAli.huevodeoro <= 1)
                        {
                            contAli.huevodeoro--;
                            Destroy(gameObject);
                        }
                        lonchera.constructor = lonchera.constructor + 50;
                        lonchera.huevoLon++;
                        lonchera.milonchera[10] = (lonchera.huevoLon);
                    }
                    else if (gameObject.tag == "huevodeoro" && lonchera.constructor >= 100)
                    {
                        lonchera.constructor = lonchera.temp;
                        print("Ya tienes el 20% de constructores:" + lonchera.constructor);
                    }

                }

                ///////////////////////////////////////////////////////////////////////////////////////////

                //20% - 1 UNIDAD
                else if (gameObject.tag == "leche")
                {
                    lonchera.temp = lonchera.constructor;
                    
                    if (lonchera.constructor < 100)
                    {
                        if (contAli.leche > 1)
                        {

                            contAli.leche--;
                            Destroy(gameObject);
                            lonchera.crearLeche();
                        }
                        else if (contAli.leche <= 1)
                        {
                            contAli.leche--;
                            Destroy(gameObject);
                        }
                        lonchera.constructor = lonchera.constructor + 50;
                        lonchera.lecheLon++;
                        lonchera.milonchera[15] = (lonchera.lecheLon);
                    }
                    else if (gameObject.tag == "leche" && lonchera.constructor >= 100)
                    {
                        lonchera.constructor = lonchera.temp;
                        print("Ya tienes el 20% de constructores:" + lonchera.constructor);
                    }

                }
        /*        else
                {
                    //CONSTRUCTORES INCORRECTOS

                    if (lonchera.constructor < 100)
                    {
                        if (gameObject.tag == "manzana")
                        {
                            if (contAli.manzana > 1)
                            {
                                contAli.manzana--;
                                print(contAli.manzana + "");
                                Destroy(gameObject);
                                lonchera.crearManzana();
                            }
                            else if (contAli.manzana <= 1)
                            {
                                contAli.manzana--;
                                Destroy(gameObject);
                                print("destruyendo :)");
                            }

                        }

                        if (gameObject.tag == "frutilla")
                        {
                            if (contAli.frutilla > 1)
                            {
                                contAli.frutilla--;
                                print(contAli.frutilla + "");
                                Destroy(gameObject);
                                lonchera.crearFrutilla();
                            }
                            else if (contAli.frutilla <= 1)
                            {
                                contAli.frutilla--;
                                Destroy(gameObject);
                                print("destruyendo :)");
                            }

                        }

                        if (gameObject.tag == "guineo")
                        {
                            if (contAli.guineo > 1)
                            {

                                contAli.guineo--;
                                Destroy(gameObject);
                                lonchera.crearPlatano();
                            }
                            else if (contAli.guineo <= 1)
                            {
                                contAli.guineo--;
                                Destroy(gameObject);
                            }
                        }

                        if (gameObject.tag == "mandarina")
                        {
                            if (contAli.mandarina > 1)
                            {

                                contAli.mandarina--;
                                Destroy(gameObject);
                                lonchera.crearMandarina();
                            }
                            else if (contAli.mandarina <= 1)
                            {
                                contAli.mandarina--;
                                Destroy(gameObject);
                            }
                        }

                        if (gameObject.tag == "uva")
                        {
                            if (contAli.uva > 1)
                            {

                                contAli.uva--;
                                Destroy(gameObject);
                                lonchera.crearUva();
                            }
                            else if (contAli.uva <= 1)
                            {
                                contAli.uva--;
                                Destroy(gameObject);
                            }
                        }

                        if (gameObject.tag == "zanahoria")
                        {
                            if (contAli.zanahoria > 1)
                            {

                                contAli.zanahoria--;
                                Destroy(gameObject);
                                lonchera.crearZanahoria();
                            }
                            else if (contAli.zanahoria <= 1)
                            {
                                contAli.zanahoria--;
                                Destroy(gameObject);
                            }
                        }

                        if (gameObject.tag == "brocoli")
                        {
                            if (contAli.brocoli > 1)
                            {

                                contAli.brocoli--;
                                Destroy(gameObject);
                                lonchera.crearBrocoli();
                            }
                            else if (contAli.brocoli <= 1)
                            {
                                contAli.brocoli--;
                                Destroy(gameObject);
                            }
                        }

                        if (gameObject.tag == "pepino")
                        {
                            if (contAli.pepino > 1)
                            {

                                contAli.pepino--;
                                Destroy(gameObject);
                                lonchera.crearPepino();
                            }
                            else if (contAli.pepino <= 1)
                            {
                                contAli.pepino--;
                                Destroy(gameObject);
                            }
                        }

                        if (gameObject.tag == "tomate")
                        {
                            if (contAli.tomate > 1)
                            {

                                contAli.tomate--;
                                Destroy(gameObject);
                                lonchera.crearTomate();
                            }
                            else if (contAli.tomate <= 1)
                            {
                                contAli.tomate--;
                                Destroy(gameObject);
                            }
                        }

                        if (gameObject.tag == "aguacate")
                        {
                            if (contAli.aguacate > 1)
                            {

                                contAli.aguacate--;
                                Destroy(gameObject);
                                lonchera.crearAguacate();
                            }
                            else if (contAli.aguacate <= 1)
                            {
                                contAli.aguacate--;
                                Destroy(gameObject);
                            }
                        }

                        if (gameObject.tag == "maduroasado")
                        {
                            if (contAli.maduroasado > 1)
                            {
                                contAli.maduroasado--;
                                Destroy(gameObject);
                                lonchera.crearMaduro();
                            }
                            else if (contAli.maduroasado <= 1)
                            {
                                contAli.maduroasado--;
                                Destroy(gameObject);
                            }
                        }

                        if (gameObject.tag == "sanduche")
                        {
                            if (contAli.sanduche > 1)
                            {

                                contAli.sanduche--;
                                Destroy(gameObject);
                                lonchera.crearSanduche();
                            }
                            else if (contAli.sanduche <= 1)
                            {
                                contAli.sanduche--;
                                Destroy(gameObject);
                            }
                        }

                        if (gameObject.tag == "tortillaverde")
                        {
                            if (contAli.tortillaverde > 1)
                            {

                                contAli.tortillaverde--;
                                Destroy(gameObject);
                                lonchera.crearTortilla();
                            }
                            else if (contAli.tortillaverde <= 1)
                            {
                                contAli.tortillaverde--;
                                Destroy(gameObject);
                            }
                        }

                        vidas.RestarVidasLonchera();
                    }
                }
                */
                if (lonchera.constructor >= 50 && lonchera.constructor <= 74)
                {
                    GameObject.Find("Constructores-parte1").GetComponent<Renderer>().enabled = true;
                }
                if (lonchera.constructor >= 75 && lonchera.constructor <= 100)
                {
                    GameObject.Find("Constructores-parte2").GetComponent<Renderer>().enabled = true;
                }

                ///////////////////////////////////////////////////////////////////////////////////////////
                lonchera.verificarLonchera();
            }
           
        }
    }
    // Update is called once per frame
    void Update () {
      
	}
}
