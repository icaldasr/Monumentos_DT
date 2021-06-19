using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;


public class UserDataManager : MonoBehaviour
{
    public TextAsset xmlRawFile;
    public Text uiEmail;
    public Text uiName;
    public Text uiGenre;
    public Text uiAge;
    public Text uiUser;
    public Text uiText;

    //public Text uiMessageBox;
    //public Text uiMessageBox2;
    //public Text uiMessageBox3;
    //public Text uiMessageBox4;
    public Text uiMessageBox5;
    //public InputField uiUserTextBox;
    public InputField passwordInput;
    public GameObject usernameInput;
    //public GameObject passwordInput;
    public GameObject uiMessageBox; //Antes
    public GameObject uiMessageBox2; //Después
    public GameObject uiMessageBox3; //XML
    public GameObject uiMessageBox4; //Inicio Sesión

    public GameObject uiAddComm; //Ventana agregar comentario
    public GameObject uiCommMenu; //Ventana ver cmments
    public GameObject uiAyudaMenu; //Ventana de ayuda
    public GameObject uiCreditosMenu; //Ventana de créditos
    public GameObject uiExplorar; //Ventana explorar
    public GameObject uiProfileMenu; //ventana Perfil
    public GameObject uiOptionsMenu; //ventana Opciones
    public GameObject uiStartMenu; //Menu inicio
    public GameObject uiTyC; //Ventana T&C
    public GameObject uiSignUp; //Ventana registro
    public GameObject uiInicioSesion; //Ventana Inicio de Sesión


    //public string cadena;

    // Start is called before the first frame update
    public static int countUsers(string xmlData)
    {
        List<List<string>> usersXML = new List<List<string>>();

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(new StringReader(xmlData));
        XmlNodeList xmlTag = xmlDoc.GetElementsByTagName("profile");
        int count = xmlTag.Count;
        return count;
    }
    public static List<List<string>> readXMLUser(string xmlData)
    {
        List<List<string>> usersXML = new List<List<string>>();

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(new StringReader(xmlData));
        XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("//users/profile");

        foreach (XmlNode node in nodeList)
        {
            List<string> user = new List<string>();
            string username = node.SelectSingleNode("user").InnerText;
            string password = node.SelectSingleNode("password").InnerText;
            user.Insert(0, username);
            user.Insert(1, password);

            usersXML.Add(user);
        }

        return usersXML;
    }

    public void logIn2(string uname)
    {
        string data = xmlRawFile.text;

        string userInput = usernameInput.GetComponent<Text>().text.ToString();
        string passInput = passwordInput.text;

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(new StringReader(data));
        XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("//users/profile");

        foreach (XmlNode node in nodeList)
        {
            string username = node.SelectSingleNode("user").InnerText;
            string password = node.SelectSingleNode("password").InnerText;

            if (username == userInput && password == passInput)
            {
                uiAddComm.SetActive(false); //Ventana agregar comentario
                uiCommMenu.SetActive(false); //Ventana ver cmments
                uiAyudaMenu.SetActive(false);//Ventana de ayuda
                uiCreditosMenu.SetActive(false); //Ventana de créditos
                uiExplorar.SetActive(false); //Ventana explorar
                uiProfileMenu.SetActive(false); //ventana Perfil
                uiOptionsMenu.SetActive(false); //ventana Opciones
                uiTyC.SetActive(false); //Ventana T&C
                uiSignUp.SetActive(false);//Ventana registro
                uiInicioSesion.SetActive(false);

                uiStartMenu.SetActive(true);
                break;
            }
            else if (userInput == "" || passInput == "")
            {
                uiMessageBox4.GetComponent<Text>().text = "Usuario o Contraseña Incorrectos, Intente nuevamente";
            }
            else
            {
                uiMessageBox4.GetComponent<Text>().text = "Usuario o Contraseña Incorrectos, Intente nuevamente";
            }
        }
    }

    public void signUp(string strn)
    {

    }
    public void parseXmlFile(string xmlData)
    {
        string valName = "";
        string valGenre = "";
        string valAge = "";

        //Inicializa el xml
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(new StringReader(xmlData));

        string xmlPathPattern = "//users/profile";
        XmlNodeList myNodeList = xmlDoc.SelectNodes(xmlPathPattern);
        foreach (XmlNode node in myNodeList)
        {
            XmlNode email = node.FirstChild;
            XmlNode name = email.NextSibling;
            XmlNode genre = name.NextSibling;
            XmlNode age = genre.NextSibling;

            valName += name.InnerXml;
            uiName.text = valName;
            valGenre += genre.InnerXml;
            uiGenre.text = valGenre;
            valAge += age.InnerXml;
            uiAge.text = valAge;
            //totVal += "Email: " + email.InnerXml + "\n Name: " + name.InnerXml + "\n User: " + age.InnerXml + "\n\n";
            //uiText.text = totVal;
        }
    }
}
