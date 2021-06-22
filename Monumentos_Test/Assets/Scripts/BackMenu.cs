using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackMenu : MonoBehaviour
{
    public GameObject uiAddComm; //Ventana agregar comentario
    public GameObject uiCommMenu; //Ventana ver cmments
    public GameObject uiAyudaMenu; //Ventana de ayuda
    public GameObject uiCreditosMenu; //Ventana de créditos
    public GameObject uiExplorar; //Ventana explorar
    public GameObject uiProfileMenu; //ventana Perfil
    public GameObject uiEditarProfMenu; //ventana Editar
    public GameObject uiOptionsMenu; //ventana Opciones
    public GameObject uiStartMenu; //Menu inicio
    public GameObject uiTyC; //Ventana T&C
    public GameObject uiSignUp; //Ventana registro
    public GameObject uiInicioSesion; //Ventana Inicio de Sesión
    public void ReturnToMenus()
    {
        SceneManager.LoadScene("Menus_SCENE");
        uiAddComm.SetActive(false); //Ventana agregar comentario
        uiCommMenu.SetActive(false); //Ventana ver cmments
        uiAyudaMenu.SetActive(false);//Ventana de ayuda
        uiCreditosMenu.SetActive(false); //Ventana de créditos
        uiExplorar.SetActive(true); //Ventana explorar
        uiProfileMenu.SetActive(false); //ventana Perfil
        uiOptionsMenu.SetActive(false); //ventana Opciones
        uiTyC.SetActive(false); //Ventana T&C
        uiSignUp.SetActive(false);//Ventana registro
        uiInicioSesion.SetActive(false);
        uiStartMenu.SetActive(false);
        uiEditarProfMenu.SetActive(false);
    }

    public void GoToComments()
    {
        SceneManager.LoadScene("Menus_SCENE");
        uiAddComm.SetActive(false); //Ventana agregar comentario
        uiCommMenu.SetActive(true); //Ventana ver cmments
        uiAyudaMenu.SetActive(false);//Ventana de ayuda
        uiCreditosMenu.SetActive(false); //Ventana de créditos
        uiExplorar.SetActive(false); //Ventana explorar
        uiProfileMenu.SetActive(false); //ventana Perfil
        uiOptionsMenu.SetActive(false); //ventana Opciones
        uiTyC.SetActive(false); //Ventana T&C
        uiSignUp.SetActive(false);//Ventana registro
        uiInicioSesion.SetActive(false);
        uiStartMenu.SetActive(false);
        uiEditarProfMenu.SetActive(false);
    }

    public void GoToAddComment()
    {
        SceneManager.LoadScene("Menus_SCENE");
        uiAddComm.SetActive(true); //Ventana agregar comentario
        uiCommMenu.SetActive(false); //Ventana ver cmments
        uiAyudaMenu.SetActive(false);//Ventana de ayuda
        uiCreditosMenu.SetActive(false); //Ventana de créditos
        uiExplorar.SetActive(false); //Ventana explorar
        uiProfileMenu.SetActive(false); //ventana Perfil
        uiOptionsMenu.SetActive(false); //ventana Opciones
        uiTyC.SetActive(false); //Ventana T&C
        uiSignUp.SetActive(false);//Ventana registro
        uiInicioSesion.SetActive(false);
        uiStartMenu.SetActive(false);
        uiEditarProfMenu.SetActive(false);
    }

    public void GoToHelp()
    {
        SceneManager.LoadScene("Menus_SCENE");
        uiAddComm.SetActive(false); //Ventana agregar comentario
        uiCommMenu.SetActive(false); //Ventana ver cmments
        uiAyudaMenu.SetActive(true);//Ventana de ayuda
        uiCreditosMenu.SetActive(false); //Ventana de créditos
        uiExplorar.SetActive(false); //Ventana explorar
        uiProfileMenu.SetActive(false); //ventana Perfil
        uiOptionsMenu.SetActive(false); //ventana Opciones
        uiTyC.SetActive(false); //Ventana T&C
        uiSignUp.SetActive(false);//Ventana registro
        uiInicioSesion.SetActive(false);
        uiStartMenu.SetActive(false);
        uiEditarProfMenu.SetActive(false);
    }


}
