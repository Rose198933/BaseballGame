using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobParameter : MonoBehaviour
{
    // �I�薼
    private string name;
    // �|�W�V����
    private Dictionary<int, string> position = new Dictionary<int, string>()
    {
        {1, "����" },
        {2, "�ߎ�" },
        {3, "��ێ�" },
        {4, "��ێ�" },
        {5, "�O�ێ�" },
        {6, "�V����" },
        {7, "�O���" }
    };
    // ������
    private Dictionary<int, string> handedness = new Dictionary<int, string>()
    {
        {0, "�E�����E�ł�" },
        {1, "�E�������ł�" },
        {2, "�E�������ł�" },
        {3, "�������E�ł�" },
        {4, "���������ł�" },
        {5, "���������ł�" }
    };

    // ����
    private int speedBall;
    // �R���g���[��
    private int control;
    // �X�^�~�i
    private int stamina;

    // �p���[
    private int power;
    // �~�[�g
    private int contact;
    // ����
    private int speed;
    // ����
    private int throwing;
    // �����
    private int deffence;
    // �ߋ�
    private int catching;

    public MobParameter()
    {
        RandomParameterSet();
    }

    public void RandomParameterSet()
    {
        GetSetName = "�c��";
    }

    // �I�薼�̃Z�b�^�[�A�Q�b�^�[
    public string GetSetName
    {
        get; set;
    }

    // �|�W�V�����̃Q�b�^�[
    public string GetPosition(int key)
    {
        return position[key];
    }

    // ������̃Q�b�^�[
    public string GetHand(int key)
    {
        return handedness[key];
    }

    // �����̃Q�b�^�[�Z�b�^�[
    public int GetSetSpeedBall
    {
        get; set;
    }

    // �R���g���[���̃Q�b�^�[�Z�b�^�[
    public int GetSetControl
    {
        get; set;
    }

    // �X�^�~�i�̃Q�b�^�[�Z�b�^�[
    public int GetSetStamina
    {
        get; set;
    }

    // �p���[�̃Q�b�^�[�Z�b�^�[
    public int GetSetPower
    {
        get; set;
    }

    // �~�[�g�̃Q�b�^�[�Z�b�^�[
    public int GetSetContact
    {
        get; set;
    }

    // ���͂̃Q�b�^�[�Z�b�^�[
    public int GetSetSpeed
    {
        get; set;
    }

    // ���͂̃Q�b�^�[�Z�b�^�[
    public int GetSetThrowing
    {
        get; set;
    }

    // ����͂̃Q�b�^�[�Z�b�^�[
    public int GetSetDeffence
    {
        get; set;
    }

    // �ߋ��̃Q�b�^�[�Z�b�^�[
    public int GetSetCatching
    {
        get; set;
    }
}
