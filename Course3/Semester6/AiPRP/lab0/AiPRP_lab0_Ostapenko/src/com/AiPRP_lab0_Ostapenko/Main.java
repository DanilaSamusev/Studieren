package com.AiPRP_lab0_Ostapenko;

import java.util.Scanner;

import static java.lang.System.*;

public class Main
{
    public static void main(String[] args)
    {
        out.println("Input first number");
        Scanner input = new Scanner(in);
        double n1 = input.nextDouble();
        out.println("Input second number");
        double n2 = input.nextDouble();

        out.printf("The sum of %f and %f is %f. %n", n1, n2, add(n1, n2));
        out.printf("The difference of %f and %f is %f. %n", n1, n2, subtract(n1, n2));
        out.printf("The multiplication of %f and %f is %f. %n", n1, n2, multiply(n1, n2));
        out.printf("The division of %f and %f is %f. %n", n1, n2, divide(n1, n2));
        out.printf("The reminder of division of %f and %f is %f. %n", n1, n2, getDivisionReminder(n1, n2));

        out.println();

        Test test = new Test();
        int a1 = 2;
        int b1 = 5;
        out.printf("%d * %d = %d %n", a1, b1, test.multiply(a1, b1));
        out.printf("%d * %d = %d %n", a1, b1, StaticTest.multiply(a1, b1));
        double a2 = 2.4;
        double b2 = 5.3;
        out.printf("%f * %f = %f %n", a2, b2, test.multiply(a2, b2));
        out.printf("%f * %f = %f %n", a2, b2, StaticTest.multiply(a2, b2));
        double a3 = 2.6;
        out.printf("%f^2 = %f %n", a3, test.multiply(a3));
        out.printf("%f^2 = %f %n", a3, StaticTest.multiply(a3));
        int a4 = 4;
        out.printf("%d^2 = %d %n", a4, test.multiply(a4));
        out.printf("%d^2 = %d %n", a4, StaticTest.multiply(a4));

        out.println();

        Monster mnstr1 = new Monster();
        mnstr1.Voice();
        Monster mnstr2 = new Monster(1, 2, 3);
        out.printf("Monster with %d arms, %d legs and %d eyes says: %n", mnstr2.ArmsAmount, mnstr2.LegsAmount, mnstr2.EyesAmount);
        mnstr2.Voice(5, "Argh!!!");
    }

    private static double add(double par1, double par2)
    {
        return par1 + par2;
    }

    private static double subtract(double par1, double par2)
    {
        return par1 - par2;
    }

    private static double multiply(double par1, double par2)
    {
        return par1 * par2;
    }

    private static double divide(double par1, double par2)
    {
        return par1 / par2;
    }

    private static double getDivisionReminder(double par1, double par2)
    {
        return par1 % par2;
    }
}