using TMPro;
using UnityEngine;

public class QuestionSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questionNumber;
    [SerializeField] private TextMeshProUGUI question;

    [SerializeField] private TextMeshProUGUI answerOption1;
    [SerializeField] private TextMeshProUGUI answerOption2;
    [SerializeField] private TextMeshProUGUI answerOption3;
    [SerializeField] private TextMeshProUGUI answerOption4;

    [SerializeField] private TextMeshProUGUI result;

    [SerializeField] private GameObject resultat;
    [SerializeField] private GameObject questionObj;

    string[] quest = { "2 + 2 =", "������� ����� ����� Pi", "���� ����� �������� �����" };
    string[] answerOp1 = { "3", "��", "6,706e+8" };
    string[] answerOp2 = { "4", "3.14", "9,836e+8" };
    string[] answerOp3 = { "5", "� ���", "2,998e+8" };
    string[] answerOp4 = { "100", "���.������������", "��� ��������" };
    int[] correntBt = {2, 1, 4};

    private int countQuest = 10;
    private int currentQuest = 0;

    private int countScore = 0;

    private int numberButton = 0;
    private int correntButton = 0;

    public void FirstQuestion()
    {
        Question(quest[currentQuest], answerOp1[currentQuest], answerOp2[currentQuest], answerOp3[currentQuest], answerOp4[currentQuest], correntBt[currentQuest]);
    }

    public void Question(string ques, string ao1, string ao2, string ao3, string ao4, int cb)
    {
        questionNumber.text = "������ " + (currentQuest + 1);
        question.text = ques;
        answerOption1.text = ao1;
        answerOption2.text = ao2;
        answerOption3.text = ao3;
        answerOption4.text = ao4;
        correntButton = cb;
    }

    public void ClickOnButton(int number)
    {
        numberButton = number;

        if(correntButton == numberButton)
            countScore++;

        currentQuest++;

        if(currentQuest < 3)
            Question(quest[currentQuest], answerOp1[currentQuest], answerOp2[currentQuest], answerOp3[currentQuest], answerOp4[currentQuest], correntBt[currentQuest]);
        else
        {
            resultat.SetActive(true);
            questionObj.SetActive(false);

            if (countScore == 0)
                result.text = "�� �� ��������, ����� ������ �����, ����� ������� ������? ���� �������� ��� ����� � ����.";
            else if(countScore > 0 && countScore < 3)
                result.text = "������� �� ����� �����, ���������� � ����������� �������� � ������� ������!";
            else if (countScore == 3)
                result.text = "����� ������? ����� ����� �����. ������ ���� ������ �������� ������ � ������� ������!";

            currentQuest = 0;
            countScore = 0;
        }
    }
}
