using Firebase;
using Firebase.Database;
using Firebase.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using TMPro;

public class AuthManager : MonoBehaviour
{
    DatabaseReference reference;


    //Firebase variables

    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser User;

    //Login variables
    [Header("Login")]
    public TMP_InputField emailLoginField;
    public TMP_InputField passwordLoginField;
    public TMP_Text warningLoginText;
    public TMP_Text confirmLoginText;

    //Register variables
    [Header("Register")]
    public TMP_InputField nameRegisterField;
    public TMP_InputField emailRegisterField;
    public TMP_InputField passwordRegisterField;
    public TMP_InputField passwordRegisterVerifyField;
    public TMP_Text warningRegisterText;

    [Header("Profile")]
    //public TMP_InputField emailLoginField;
    //public TMP_InputField passwordLoginField;
    public Text NameText;
    public Text EmailText;

    void Start()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
    }

    void Update()
    {
        
    }

    public void signUp()
    {
        auth.CreateUserWithEmailAndPasswordAsync(emailRegisterField.text.ToString(), passwordRegisterField.text.ToString()).ContinueWith(task =>
         {
             if (task.IsCanceled)
             {
                 Debug.LogError("Create user was canceled.");
                 return;
             }
             if (task.IsFaulted)
             {
                 Debug.LogError("Create User encountered an error: " + task.Exception);
                 return;
             }

             //If user was created
             warningRegisterText.text = "Usuario registrado";
            Firebase.Auth.FirebaseUser newUser = task.Result;
             Debug.LogFormat("Firebase user created!: {0} ({1})",
                 newUser.DisplayName, newUser.UserId);
             reference.Child("users").Child(newUser.UserId).Child("email").SetValueAsync(emailRegisterField.text.ToString());
             reference.Child("users").Child(newUser.UserId).Child("password").SetValueAsync(passwordRegisterField.text.ToString());
             reference.Child("users").Child(newUser.UserId).Child("name").SetValueAsync(nameRegisterField.text.ToString());
         });
    }

    public void SignIn()
    {
        auth.SignInWithEmailAndPasswordAsync(emailLoginField.text.ToString(), passwordLoginField.text.ToString()).ContinueWith(task =>
         {
             if (task.IsCanceled)
             {
                 Debug.LogError("Sign In was canceled.");
                 return;
             }
             if (task.IsFaulted)
             {
                 Debug.LogError("Sign In encountered an error: " + task.Exception);
                 return;
             }
             //If user was created
             confirmLoginText.text = "Inicio Sesion";
             Firebase.Auth.FirebaseUser newUser = task.Result;
             Debug.LogFormat("Inicio de sesión satisfactorio: {0} ({1})",
                 newUser.DisplayName, newUser.UserId);
         });
    }

    public void showProfile()
    {

        NameText.text = FirebaseDatabase
                .DefaultInstance
                .GetReference("test-monumentos-default-rtdb")
                .OrderByChild("users")
                .EqualTo("name")
                .GetValueAsync()
                .Result // wait for the result of asynchronous operation
                .ToString();

        EmailText.text = FirebaseDatabase
                    .DefaultInstance
                    .GetReference("test-monumentos-default-rtdb")
                    .OrderByChild("users")
                    .EqualTo("email")
                    .GetValueAsync()
                    .Result // wait for the result of asynchronous operation
                    .ToString();
    }
}
//Tomado de: https://github.com/xzippyzachx/UnityFirebaseAuthTutorial/blob/master/FirebaseAuthTutorialCompleteProject/Assets/Scripts/AuthManager.cs