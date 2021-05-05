package com.company;
import java.awt.*;
import javax.swing.*;

public class NewMain1 extends javax.swing.JFrame implements java.lang.Runnable{
    public NewMain1() {
        aPanel = new javax.swing.JPanel();
        aLabel = new javax.swing.JLabel();
        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        setLocationRelativeTo(null);
        setPreferredSize(new java.awt.Dimension(50, 110));
        setBackground(Color.PINK);
        add(aPanel);
        aPanel.add(aLabel);
        pack();
        start();
    }

    public final void start() {
        if (fThread == null){
            fThread = new java.lang.Thread (this);
            fThread.start();
        }
    }


    public void run() {
        while ( fThread != null){

            try{
                Thread.sleep (300);
                ++bellTolls;

                javax.swing.ImageIcon img =
                        new javax.swing.ImageIcon("C:\\Users\\Aldamar\\Desktop\\1.gif");
                aLabel.setIcon(img);
            }
            catch  (InterruptedException e) { }
            anOther();
            if (this.isDone())  fThread = null;
        }
    }

    public void anOther(){

        try{
            Thread.sleep (300);
            javax.swing.ImageIcon img =new javax.swing.ImageIcon("C:\\Users\\Aldamar\\Desktop\\2.gif");
            aLabel.setIcon(img);

        }
        catch  (InterruptedException e) { }

    }

    public boolean isDone() {
        boolean temp=false;
        if(bellTolls==COUNTS) {
            temp=true;
            bellTolls=0;
        }
        return temp;
    }

    public static void main(String args[]) {
        NewMain1 z=
                new NewMain1();
        z.setVisible(true);
        z.setBackground(Color.PINK);

    }
    private javax.swing.JLabel aLabel;
    private javax.swing.JPanel aPanel;
    Thread fThread;
    int bellTolls=0;
    final int COUNTS=50;

}
