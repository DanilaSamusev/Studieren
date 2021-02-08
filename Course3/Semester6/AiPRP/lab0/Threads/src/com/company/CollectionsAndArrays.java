package com.company;

import java.util.Iterator;
import java.util.ArrayList;
import java.util.Enumeration;
import java.util.Vector;
import java.util.*;

public class CollectionsAndArrays {

    public static void main(String[] args) {

        ArrayList arr = new ArrayList();
        arr.add("one");
        arr.add("two");
        arr.add("three");
        arr.add(4);
        arr.add("5");
        Iterator iter = arr.iterator();
        while (iter.hasNext())
            System.out.println("" + iter.next());
        iter = arr.iterator();
        while (iter.hasNext()) {
            if ("three".equals(iter.next())) {
                iter.remove();
            }
        }
        System.out.println("After remove:");
        System.out.println(arr);


        Vector<String> vl = new Vector<String>();
        Enumeration<String> enm = null;
        vl.add("one");
        vl.add("two");
        vl.add("three");
        vl.add("four");
        enm = vl.elements();
        while (enm.hasMoreElements()) {
            System.out.println(enm.nextElement());
        }

        System.out.println("new collection starts");
        Enumeration enm2 = null;
        Vector v2 = new Vector();
        v2.add(1);
        v2.add("two");
        v2.add(new Date());
        enm2 = v2.elements();
        while (enm2.hasMoreElements()) {
            System.out.println("" + enm2.nextElement());
        }
    }
}

