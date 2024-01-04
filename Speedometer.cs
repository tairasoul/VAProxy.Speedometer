using BepInEx;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace Speedometer
{
    internal class Speedometer : MonoBehaviour
    {
        Text speedText;

        void Awake()
        {
            SceneManager.activeSceneChanged += SceneLoad;
        }

        internal void SceneLoad(Scene old, Scene newS)
        {
            if (newS.name != "Intro" && newS.name != "Menu")
            {
                GameObject Area = GameObject.Find("UI/ui/Area");
                GameObject Pos = GameObject.Instantiate(Area);
                Pos.name = "Speed";
                Pos.transform.SetParent(Area.transform.parent);
                Destroy(Pos.GetComponent<Locations>());
                Pos.GetComponent<RectTransform>().anchoredPosition = new Vector2(-806.1818f, -550.7941f);
                speedText = Pos.GetComponent<Text>();
                speedText.alignment = TextAnchor.UpperLeft;
            }
        }

        internal void Update()
        {
            if (speedText != null)
            {
                GameObject sen = GameObject.Find("S-105");
                Rigidbody rigid = sen.GetComponent<Rigidbody>();
                speedText.text = $"{Mathf.Round(rigid.velocity.x)} {Mathf.Round(rigid.velocity.y)} {Mathf.Round(rigid.velocity.z)}";
            }
        }
    }
}
