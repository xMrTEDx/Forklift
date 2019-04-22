using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SterowanieDzwigniami : MonoBehaviour
{

    public GameObject dzwigniaBiegi;
    public Quaternion dzwigniaBiegiStandardowePolozenie;
    public GameObject dzwignia1;
    public Quaternion dzwignia1StandardowePolozenie;
    public GameObject dzwignia2;
    public Quaternion dzwignia2StandardowePolozenie;
    public GameObject dzwignia3;
    public Quaternion dzwignia3StandardowePolozenie;
    public float katPochyleniaBiegi;
    public float katPochyleniaDzwignie;

    void Start()
    {
        dzwigniaBiegiStandardowePolozenie = dzwigniaBiegi.transform.localRotation;
        dzwignia1StandardowePolozenie = dzwignia1.transform.localRotation;
        dzwignia2StandardowePolozenie = dzwignia2.transform.localRotation;
        dzwignia3StandardowePolozenie = dzwignia3.transform.localRotation;
    }

    public void UstawPolozenieDzwigni(float dzwigniaB)
    {
        dzwigniaBiegi.transform.localRotation = Quaternion.Lerp(dzwigniaBiegi.transform.localRotation, Quaternion.Euler(0, dzwigniaBiegiStandardowePolozenie.y + katPochyleniaBiegi * dzwigniaB, 0),0.1f);
        dzwignia1.transform.localRotation = Quaternion.Lerp(dzwignia1.transform.localRotation, Quaternion.Euler(dzwignia1StandardowePolozenie.x + katPochyleniaDzwignie * Input.GetAxisRaw("KaretkaGoraDol"), 0, 0),0.1f);
        dzwignia2.transform.localRotation = Quaternion.Lerp(dzwignia2.transform.localRotation,Quaternion.Euler(dzwignia2StandardowePolozenie.x + katPochyleniaDzwignie * Input.GetAxisRaw("MasztPochylenie"), 0, 0),0.1f);
        dzwignia3.transform.localRotation = Quaternion.Lerp(dzwignia3.transform.localRotation,Quaternion.Euler(dzwignia3StandardowePolozenie.x + katPochyleniaDzwignie * Input.GetAxisRaw("KaretkaLewoPrawo"), 0, 0),0.1f);

    }
}
