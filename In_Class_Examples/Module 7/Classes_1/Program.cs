namespace Classes_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
        

            STUDENT st1 = new STUDENT();
            st1.strFirstName = "Mike";
            st1.strLastName = "Johnson";
            st1.intID = 109;
            st1.dbl1stGrade = 80;


            STUDENT st2 = new STUDENT();
            STUDENT st3 = new STUDENT();
            STUDENT st4 = new STUDENT();
            STUDENT MJ = new STUDENT();



            COURSE MIST352 = new COURSE();
            MIST352.intCRN = 76449;
            MIST352.strName = "Business Appl. Prog.";
            MIST352.strSemester = "Fall";
            MIST352.intYear = 2026;

            CIRCLE WVUCirle = new CIRCLE();
            WVUCirle.dblRaduis = 10;


            Console.WriteLine(MIST352.strName);

         

        }
    }
}
