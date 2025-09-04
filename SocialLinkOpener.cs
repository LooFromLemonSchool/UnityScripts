using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialLinkOpener : MonoBehaviour
{
    public void OpenInstagram()
    {
        string url = "https://www.instagram.com/loo_lemon_games/";
        Application.OpenURL(url);
    }
}
