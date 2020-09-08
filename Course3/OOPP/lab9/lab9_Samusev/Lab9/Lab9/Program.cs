namespace Lab9
{
    class Program
    {
        public static event ChangeString ChangeStringEvent;
        public delegate void ChangeString(int k, string message);

        public static void Main(string[] args)
        {
            Class1 class1 = new Class1();
            Class2 class2 = new Class2();

            int k = 2;
            string message = "Message";

            ChangeString changeString = new ChangeString(class1.DoubleString);
            changeString.Invoke(k, message);

            changeString = new ChangeString(class1.ChangeString);
            changeString.Invoke(k, message);

            changeString = new ChangeString(class2.GetSubstring);
            changeString.Invoke(k, message);

            changeString += class1.DoubleString;
            changeString += class1.ChangeString;
            changeString.Invoke(k, message);

            ChangeStringEvent += new ChangeString(class1.DoubleString);
            ChangeStringEvent += new ChangeString(class1.ChangeString);
            ChangeStringEvent += new ChangeString(class2.GetSubstring);

            OnChangeStringEvent(k, message);
        }

        public static void OnChangeStringEvent(int k, string message)
        {
            ChangeStringEvent?.Invoke(k, message);
        }
    }
}
