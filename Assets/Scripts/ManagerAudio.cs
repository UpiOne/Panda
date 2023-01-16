using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ManagerAudio : MonoBehaviour
{
    [SerializeField] private AudioSource AudioNotes;
   
    [Header("������ ���")] // ����� ������ ��� �������� ������������ �������� "������ ���"
    [SerializeField] private AudioClip[] Notes = new AudioClip[10]; // ������

    void Start()
    {
       // ��������� AudioSource � �������
    }

    public void PlaySound(int numberNotes) // ����� � ����������, � ������� �������� ����� �������� ����
    {
        
        AudioNotes.PlayOneShot(Notes[numberNotes]); // �������������� ����� ��� ����������
    }

}