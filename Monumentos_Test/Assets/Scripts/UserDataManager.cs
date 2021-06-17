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
    //public InputField uiPasswordTextBox;
    public GameObject usernameInput;
    public GameObject passwordInput;
    public GameObject uiMessageBox; //Antes
    public GameObject uiMessageBox2; //Después
    public GameObject uiMessageBox3; //XML
    public GameObject uiMessageBox4; //Inicio Sesión

    //public string cadena;

    // Start is called before the first frame update
    void Start()
    {
        //TextAsset xmlTextAsset = Resources.Load<NombreArchivo>("Carpeta/Nombrearchivo");
        string data = xmlRawFile.text;
        //readXMLUser(data);
        logIn(data);
        parseXmlFile(data);
        //cargarInfo(data, uiUserTextBox.text, uiPasswordTextBox.text);
        //getUser(data);

    }

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

    public string getValuesFromUser()
    {
        string username = usernameInput.GetComponent<Text>().text;
        return username;
    }
    public void logIn(string data)
    {
        List<List<string>> usersXML = new List<List<string>>();
        usersXML = readXMLUser(data);
        int nodes = countUsers(data);
        //int i = 0;

        

        foreach (var v in usersXML)
        {
            string user = v[0];
            string password = v[1];

            uiMessageBox3.GetComponent<Text>().text = " XML:" + user + " " + password + " " + nodes.ToString();

            string username = getValuesFromUser();

            if (v[0].Contains(username))
            {
                uiMessageBox4.GetComponent<Text>().text = "Inicia Sesión" + v[0] + " " + username;
                break;
            }
            else
            {
                uiMessageBox4.GetComponent<Text>().text = "NOOOO Inicia Sesión " + v[0] + " " + username; ;
            }
        }
        /*for (i = 0; i<=nodes; i++)
        {
            string user = usersXML[i][0];
            string password = usersXML[i][1];

            uiMessageBox3.GetComponent<Text>().text = " XML:" + user + " " + password + " " + nodes.ToString();

            if (usersXML[i][0].Contains("icaldasr"))
            {
                uiMessageBox4.GetComponent<Text>().text = "Inicia Sesión" + usersXML[i][0];
                break;
            }
            else
            {
                uiMessageBox4.GetComponent<Text>().text = "Usuario o Contraseña incorrecta. Intente nuevamente" + usersXML[i][0];
            }


            /*if ("dgalarza" == user && "123456" == password)
            {
                uiMessageBox4.GetComponent<Text>().text = "Inicia Sesión";
            }
            else
            {
                //uiMessageBox4.text ="ERROR";
                if (user != "Dgalarza" && password == "123456")
                {
                    uiMessageBox4.GetComponent<Text>().text = "Usr DIf " + user + " Input";
                }

                else if (user == "dgalarga" && password != "12345")
                {
                    uiMessageBox4.GetComponent<Text>().text = "PSS DIf " + password + " Input";
                }
            }
        }*/
        //string user = usersXML[0][0];
        //string password = usersXML[0][1];
        /*uiMessageBox3.GetComponent<Text>().text = " XML:" + user + " " + password + " " + nodes.ToString();

        if ("dgalarza" == user && "123456" == password)
        {
            uiMessageBox4.GetComponent<Text>().text = "Inicia Sesión";
        }
        else
        {
            //uiMessageBox4.text ="ERROR";
            if (user != "Dgalarza" && password == "123456")
            {
                uiMessageBox4.GetComponent<Text>().text = "Usr DIf " + user + " Input";
            }

            else if (user == "dgalarga" && password != "12345")
            {
                uiMessageBox4.GetComponent<Text>().text = "PSS DIf " + password + " Input";
            }

            else
            {
                uiMessageBox4.text = "ERROR " + password + " Input" + uiPasswordTextBox.text + " " + user + " Input" + uiUserTextBox.text;
                uiMessageBox.text = "ERROR " + password + " Input" + uiPasswordTextBox.text + " " + user + " Input" + uiUserTextBox.text;
            }*/

            //string userInput = uiUserTextBox.text;
            //string psswdInput = uiPasswordTextBox.text;
            //uiMessageBox5.text = "INPUT1: " + userInput + " " + psswdInput;

            //string username = usernameInput.GetComponent<Text>().text;
            //uiMessageBox.GetComponent<Text>().text = "Usuario INPUT antes: " + username;
            /*XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(new StringReader(xmlData));
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("//users/profile");
            List<string> resultXML = new List<string>();
            foreach (XmlNode node in nodeList)
            {
                //uiMessageBox2.GetComponent<Text>().text = "Usuario INPUT después: " + username;
            //string userInput = uiUserTextBox.text.ToString();
            //string psswdInput = uiPasswordTextBox.text.ToString();

                string user = node.SelectSingleNode("user").InnerText;
                string password = node.SelectSingleNode("password").InnerText;
            resultXML.Insert(0,user);
            resultXML.Insert(1, password);
                //string username2 = usernameInput.GetComponent<Text>().text;

                uiMessageBox3.GetComponent<Text>().text = "XML: " + user + " " + password;
            //uiMessageBox2.text = "INPUT: " + userInput + " " + psswdInput;

            if (uiUserTextBox.text == user && uiPasswordTextBox.text == password)
            {
                uiMessageBox4.text = "Inicia Sesión";
                uiMessageBox.text = "Inicia Sesión";
            }
            else
            {
                //uiMessageBox4.text ="ERROR";
                if (user != uiUserTextBox.text && password == uiPasswordTextBox.text)
                {
                    uiMessageBox4.text = "Usr DIf " + user + " Input" + uiUserTextBox.text;
                }

                else if (user == uiUserTextBox.text && password != uiPasswordTextBox.text)
                {
                    uiMessageBox4.text = "PSS DIf " + password + " Input" + uiPasswordTextBox.text;
                }

                else
                {
                    uiMessageBox4.text = "ERROR " + password + " Input" + uiPasswordTextBox.text + " " + user + " Input" + uiUserTextBox.text;
                    uiMessageBox.text = "ERROR " + password + " Input" + uiPasswordTextBox.text + " " + user + " Input" + uiUserTextBox.text;
                }
            }
                //return (user, password);
            }
            //uiMessageBox2.GetComponent<Text>().text = "Usuario INPUT después: " + username + " XML:" + resultXML[0];*/
            //string username = usernameInput.GetComponent<Text>().text;
            //uiMessageBox.GetComponent<Text>().text = "Usuario INPUT antes: " + username;

        //}
    }
    
    public void parseXmlFile(string xmlData)
    {
        //string valEmail = "";
        string valName = "";
        string valGenre = "";
        string valAge = "";
        //string totVal = "";

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
