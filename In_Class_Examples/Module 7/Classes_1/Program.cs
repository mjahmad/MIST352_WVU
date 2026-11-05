namespace Classes_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
        

            STUDENT st1 = new STUDENT("555-55-5444");
            st1.theFirstName = "Sarah";
            Console.WriteLine(st1.theFirstName);
 


            STUDENT st2 = new STUDENT("999-99-09990");
            STUDENT st3 = new STUDENT("Sarah","Conor");
            STUDENT st4 = new STUDENT("Trinity","Ahmad",10,90.8,"888-99-0000");
            STUDENT st5 = new STUDENT("Ripley", "", 10, 90.8, "888-99-0000");

            //st1.strFirstName = "Mike";
            //st1.strLastName = "Johnson";
            //st1.intID = 109;
            //st1.dbl1stGrade = 80;


            //STUDENT st2 = new STUDENT();
            //STUDENT st3 = new STUDENT();
            //STUDENT st4 = new STUDENT();
            //STUDENT MJ = new STUDENT();



            //COURSE MIST352 = new COURSE();
            //MIST352.intCRN = 76449;
            //MIST352.strName = "Business Appl. Prog.";
            //MIST352.strSemester = "Fall";
            //MIST352.intYear = 2026;

            //CIRCLE WVUCirle = new CIRCLE();
            //WVUCirle.dblRaduis = 10;


            //Console.WriteLine(MIST352.strName);



        }
    }
}
