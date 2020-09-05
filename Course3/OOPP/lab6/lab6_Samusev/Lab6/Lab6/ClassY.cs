namespace Lab6
{
    public class ClassY : Iy, Ix
    {
        public string Message;

        public ClassY()
        {
            Message = "Hello world!";
        }
        
        public string F0(int symbolNumber)
        {
            return Message.Substring(symbolNumber);
        }

        public void F0(int symbolNumber, out string message)
        {
            message = Message.Remove(symbolNumber, 1);
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