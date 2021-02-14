package com.AiPRP_lab0_Ostapenko;

public class Monster
{
    public int EyesAmount;
    public int LegsAmount;
    public int ArmsAmount;

    public Monster()
    {
        EyesAmount = 2;
        LegsAmount = 2;
        ArmsAmount = 2;
    }

    public Monster(int eyesAmount)
    {
        EyesAmount = eyesAmount;
        LegsAmount = 2;
        ArmsAmount = 2;
    }

    public Monster(int eyesAmount, int legsAmount)
    {
        EyesAmount = eyesAmount;
        LegsAmount = legsAmount;
        ArmsAmount = 2;
    }

    public Monster(int eyesAmount, int legsAmount, int armsAmount)
    {
        EyesAmount = eyesAmount;
        LegsAmount = legsAmount;
        ArmsAmount = armsAmount;
    }

    public void Voice()
    {
        System.out.println("Voice!");
    }

    public void Voice(int n, String voice)
    {
        for (int i = 0; i < n; i++)
        {
            System.out.println(voice);
        }
    }
}
