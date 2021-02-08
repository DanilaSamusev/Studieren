package com.company;

import java.awt.event.*;
import java.io.*;
import java.awt.*;

public class fileexample extends Frame implements ActionListener
{
    Button bt=new Button("Выход");
    Button bt1=new Button("Записать");
    Button bt2=new Button("Прочитать");
    TextField tf=new TextField();

    public  fileexample()
    {
        super("Work with Files");
        setLayout(null);
        setBackground(new Color(250,200,120));
        setSize(250,200);
        setVisible(true);
        add(bt);
        add(bt1);
        add(bt2);
        add(tf);
        bt.addActionListener(this);
        bt1.addActionListener(this);
        bt2.addActionListener(this);
        bt.setBounds(20,40,100,20);
        bt1.setBounds(20,65,100,20);
        bt2.setBounds(20,90,100,20);
        tf.setBounds(20,115,150,20);

    }
    public void actionPerformed(ActionEvent ae)
    {

        if(ae.getSource()==bt1)
        {
            try{
                FileOutputStream fout=new FileOutputStream("D:/my.txt");
                DataOutputStream dout=new DataOutputStream(fout);
                dout.writeUTF("Hello, File World!");
                dout.close();
            }
            catch(Exception ex){}
        }
        else
        if(ae.getSource()==bt)
            System.exit(0);

        else
        if(ae.getSource()==bt2)
        {
            try{
                FileInputStream finp= new FileInputStream("D:/my.txt");
                DataInputStream dinp=new DataInputStream(finp);
                String s=dinp.readUTF();
                dinp.close();
                tf.setText(s);
            }
            catch(Exception ex) {}
        }

    }

    public static void main(String[] args)
    {
        new fileexample();

    }
}

