using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendEmail : MonoBehaviour
{
    public void SendEmails()
    {
        string email = "loolischooli@gmail.com";
        string subject = EscapeURL("Hello from a friend");
        string body = EscapeURL("Hi Loo, \n\nI have a question to ask...");

        string mailto = $"mailto:{email}?subject={subject}&body={body}";
        Application.OpenURL(mailto);
    }
    
    
    private string EscapeURL(string text)
    {
        return WWW.EscapeURL(text).Replace("+", "%20");
    }
}
