public class Main {

    public static void main(String[] args)
    {
        Test test = new Test();

        System.out.println(test.Multiply(1,2));

        System.out.println(Test.Multiply(2));
        System.out.println(Test.Multiply(4.1, 3.2));

        Monster human = new Monster();
        Monster monster = new Monster(3);
        Monster monster1 = new Monster(4, 5);
        Monster monster2 = new Monster(4, 3, 1);

        human.Voice();
        monster.Voice("Grrrrrrr!");
        monster2.Voice("AGGRRRR!!!!", 4);
    }
}
