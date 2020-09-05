namespace Lab6
{
    public class ClassX : Ix, Iy
    {
        public string Message;
        
        public ClassX()
        {
            Message = "Hello world!";
        }
        
        public void F0(int symbolNumber, out string message)
        {
            message = Message.Remove(symbolNumber, 1);
        }

        public string F0(int symbolNumber)
        {
            return Message.Substring(symbolNumber);
        }

        void Ix.F1(int symbolNumber)
        {
            Message = Message.Insert(symbolNumber, "+");
        }
        
        void Iy.F1(int symbolNumber)
        {
            throw new System.NotImplementedException();
        }
    }
}