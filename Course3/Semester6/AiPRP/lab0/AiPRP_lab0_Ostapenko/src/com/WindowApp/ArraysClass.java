package com.WindowApp;

import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.RandomAccessFile;

public class ArraysClass extends Frame implements ActionListener {
    Button b=new Button("Exit");
    Button b1=new Button("Write to File");
    Button b2=new Button("Read from  File");

    public ArraysClass()
    {
        setLayout(null);
        setBackground(new Color(240,230,100));
        setSize(300,300);
        setVisible(true);
        add(b);
        add(b1);
        add(b2);
        b.addActionListener(this);
        b1.addActionListener(this);
        b2.addActionListener(this);
        b.setBounds(20,30,100,20);
        b1.setBounds(20,60,100,20);
        b2.setBounds(20,90,100,20);
    }

    public void actionPerformed(ActionEvent ae) {
        if (ae.getSource() == b)
            System.exit(0);
        else if (ae.getSource() == b1) {
            try {

                RandomAccessFile raf = new RandomAccessFile("temp.dat", "rw");
                for (int i = 0; i < 10; i++)
                    raf.writeInt(i);
                raf.close();
            } catch (Exception ex) {
            }
        } else if (ae.getSource() == b2) {
            try {
                RandomAccessFile raf = new RandomAccessFile("temp.dat", "rw");
                Graphics g = getGraphics();

                for (int i = 0; i < 10; i++) {
                    raf.seek(i * 4);
                    int z = raf.readInt();
                    g.drawString("" + z, 130, 50 + 20 * i);
                }
                raf.close();
            } catch (Exception ex) {
            }
        }
    }

    public static void main(String[] args)
    {
        ArraysClass app = new ArraysClass();
    }
}
