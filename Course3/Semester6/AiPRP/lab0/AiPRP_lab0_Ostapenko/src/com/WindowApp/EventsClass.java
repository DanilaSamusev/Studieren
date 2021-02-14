package com.WindowApp;

import java.awt.*;
import java.awt.event.*;

public class EventsClass extends Frame implements ActionListener, MouseListener {
    Button b = new Button("Exit");

    public EventsClass() {
        setLayout(null);
        setBackground(new Color(240, 230, 100));
        setSize(300, 300);
        setVisible(true);
        add(b);
        b.addActionListener(this);
        b.setBounds(20, 30, 100, 20);

        addMouseListener(this);
    }

    public void actionPerformed(ActionEvent ae) {
        if (ae.getSource() == b)
            System.exit(0);
    }


    public void mouseEntered(MouseEvent ev) {
    }

    public void mouseExited(MouseEvent ev) {
    }

    public void mousePressed(MouseEvent ev) {
        int x = ev.getX();
        int y = ev.getY();
        Graphics g = getGraphics();
        g.drawString("X=" + x + "; Y=" + y, x, y);
    }

    public void mouseReleased(MouseEvent ev) {
    }

    public void mouseClicked(MouseEvent ev) {
    }

    public static void main(String[] args) {
        EventsClass app = new EventsClass();
    }
}
