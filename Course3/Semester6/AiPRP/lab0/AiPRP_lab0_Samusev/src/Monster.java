public class Monster {

    public int LegsCount;
    public int ArmsCount;
    public int EyesCount;

    public Monster(){
        LegsCount = 2;
        ArmsCount = 2;
        EyesCount = 2;
        System.out.println("Создан монстр, его параметры: ноги: " + LegsCount + " руки: " + ArmsCount + " глаза: " + EyesCount);
    }

    public Monster(int legsCount){
        LegsCount = legsCount;
        System.out.println("Создан монстр, его параметры: ноги: " + LegsCount + " руки: " + ArmsCount + " глаза: " + EyesCount);

    }

    public Monster(int legsCount, int armsCount){
        LegsCount = legsCount;
        ArmsCount = armsCount;
        System.out.println("Создан монстр, его параметры: ноги: " + LegsCount + " руки: " + ArmsCount + " глаза: " + EyesCount);

    }

    public Monster(int legsCount, int armsCount, int eyesCount){
        LegsCount = legsCount;
        ArmsCount = armsCount;
        EyesCount = eyesCount;
        System.out.println("Создан монстр, его параметры: ноги: " + LegsCount + " руки: " + ArmsCount + " глаза: " + EyesCount);

    }

    public void Voice(){
        System.out.println("Голос");

    }

    public void Voice(String word){
        System.out.println(word);
    }

    public void Voice(String word, int repeatCount){

        for (int i = 0; i < repeatCount; i++){
            System.out.println(word);
        }
    }
}
