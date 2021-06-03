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

    // Start is called before the first frame update
    void Start()
    {
        //TextAsset xmlTextAsset = Resources.Load<NombreArchivo>("Carpeta/Nombrearchivo");
        string data = xmlRawFile.text;
        parseXmlFile(data);
    }

    // Update is called once per frame

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
        foreach(XmlNode node in myNodeList)
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
