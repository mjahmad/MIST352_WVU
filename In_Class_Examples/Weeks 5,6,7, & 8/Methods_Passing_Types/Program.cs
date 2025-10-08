using System;

namespace Methods_Passing_Types
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== PASS-BY-VALUE vs REF vs OUT (with arrays) ===\n");

            // --------------------------
            // 1) PASS-BY-VALUE (default)
            // --------------------------
            int intFirstVal = 1, intSecondVal = 2;
            Console.WriteLine("[Pass-by-VALUE] BEFORE MultiplyByValue: intFirstVal={0}, intSecondVal={1}", intFirstVal, intSecondVal);
            MultiplyByValue(intFirstVal, intSecondVal); // changes are local to the method
            Console.WriteLine("[Pass-by-VALUE] AFTER  MultiplyByValue: intFirstVal={0}, intSecondVal={1}\n", intFirstVal, intSecondVal);
            // Proof: unchanged outside the method.

            // -------------------------------------------
            // 2) PASS-BY-REFERENCE using 'ref' on scalars
            // -------------------------------------------
            Console.WriteLine("[REF scalars] BEFORE MultiplyByReference: intFirstVal={0}, intSecondVal={1}", intFirstVal, intSecondVal);
            MultiplyByReference(ref intFirstVal, ref intSecondVal); // method can modify caller's variables
            Console.WriteLine("[REF scalars] AFTER  MultiplyByReference: intFirstVal={0}, intSecondVal={1}\n", intFirstVal, intSecondVal);
            // Proof: both variables changed because we passed them by reference.

            // ---------------------------------------------------
            // 3) OUT parameters: method MUST assign before return
            //    Caller DOES NOT need to assign before the call.
            // ---------------------------------------------------
            int intThirdVal; // intentionally uninitialized to show 'out' behavior
            Console.WriteLine("[OUT + REF] BEFORE SumValues: intFirstVal={0}, intSecondVal={1}, intThirdVal=<unassigned>", intFirstVal, intSecondVal);
            SumValues(ref intFirstVal, ref intSecondVal, out intThirdVal);
            Console.WriteLine("[OUT + REF] AFTER  SumValues: intFirstVal={0}, intSecondVal={1}, intThirdVal={2}\n", intFirstVal, intSecondVal, intThirdVal);
            // Proof: intThirdVal is assigned inside the method; intFirstVal & intSecondVal also changed via 'ref'.

            // -------------------------------------------------
            // 4) ARRAYS: reference types (reference passed by value)
            //    - Mutating elements inside the method is visible.
            //    - Replacing the entire array requires 'ref int[]'.
            // -------------------------------------------------
            int[] intNumbers = { 10, 20, 30, 40 };
            Console.WriteLine("[Array] BEFORE PrintAndMutateArray: [{0}]", string.Join(", ", intNumbers));
            PrintAndMutateArray(intNumbers); // mutates elements; visible to caller because array is a reference type
            Console.WriteLine("[Array] AFTER  PrintAndMutateArray:  [{0}]\n", string.Join(", ", intNumbers));

            // Replacing the WHOLE array:
            Console.WriteLine("[Array REF] BEFORE ReplaceArray: [{0}]", string.Join(", ", intNumbers));
            ReplaceArray(ref intNumbers);  // needs 'ref int[]' to replace the caller's array reference
            Console.WriteLine("[Array REF] AFTER  ReplaceArray:  [{0}]\n", string.Join(", ", intNumbers));

            // ------------------------------------------------------
            // 5) 'in' parameters (readonly by-ref) — quick example:
            //    Method can READ but cannot MODIFY the variable.
            // ------------------------------------------------------
            int intA = 5, intB = 7;
            Console.WriteLine("[IN readonly] intA={0}, intB={1}", intA, intB);
            int intSum = SumReadonly(in intA, in intB);
            Console.WriteLine("[IN readonly] SumReadonly result={0}; after call intA={1}, intB={2}\n", intSum, intA, intB);

            // ------------------------------------------------------
            // 6) OUT with TryParse — a very common real-world pattern
            // ------------------------------------------------------
            Console.Write("Enter an integer (TryParse demo): ");
            string strInput = Console.ReadLine();
            if (int.TryParse(strInput, out int intParsed)) // 'out' variable introduced inline
            {
                Console.WriteLine("Parsed OK. You entered: {0}\n", intParsed);
            }
            else
            {
                Console.WriteLine("Not an int.\n");
            }

            // ------------------------------------------------------
            // 7) OUT with our own method: accept and verify email
            // ------------------------------------------------------
            Console.WriteLine("Email capture (using OUT):");
            AcceptAndVerifyEmail(out string strUserEmail);
            Console.WriteLine("Verified email: {0}\n", strUserEmail);

            Console.WriteLine("=== END OF DEMO ===");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        // ---------------------------------------------------------
        // PASS-BY-VALUE (DEFAULT):
        // - Parameters are copied.
        // - Changing them here does NOT affect the caller.
        // ---------------------------------------------------------
        static void MultiplyByValue(int intVal1, int intVal2)
        {
            Console.WriteLine("  [MultiplyByValue] Received: intVal1={0}, intVal2={1}", intVal1, intVal2);
            intVal1 = 20; // local change only
            Console.WriteLine("  [MultiplyByValue] After local change intVal1=20, product={0}", intVal1 * intVal2);
            // No effect on caller's variables.
        }

        // ---------------------------------------------------------
        // REF (pass-by-reference for scalars):
        // - Method receives a reference to the caller's variables.
        // - Changing them here WILL change the caller's values.
        // ---------------------------------------------------------
        static void MultiplyByReference(ref int intVal1, ref int intVal2)
        {
            Console.WriteLine("  [MultiplyByReference] Received (by ref): intVal1={0}, intVal2={1}", intVal1, intVal2);
            intVal1 = 20; // affects caller
            Console.WriteLine("  [MultiplyByReference] After intVal1=20, product now={0}", intVal1 * intVal2);
            intVal2 = 90; // also affects caller
            Console.WriteLine("  [MultiplyByReference] After intVal2=90, now intVal1={0}, intVal2={1}", intVal1, intVal2);
        }

        // ---------------------------------------------------------
        // OUT + REF combo:
        // - 'out intThird' MUST be assigned before the method returns.
        // - 'ref' parameters can be read/modified.
        // ---------------------------------------------------------
        static void SumValues(ref int intVal1, ref int intVal2, out int intVal3)
        {
            Console.WriteLine("  [SumValues] Received (ref, ref, out): intVal1={0}, intVal2={1}, intVal3=<unassigned>", intVal1, intVal2);
            intVal3 = 10; // required: assign 'out' before returning
            Console.WriteLine("  [SumValues] Sum={0}", intVal1 + intVal2 + intVal3);

            // Reset all to show the external effect of ref/out clearly
            intVal1 = 0;
            intVal2 = 0;
            intVal3 = 0;
            Console.WriteLine("  [SumValues] After resets: intVal1={0}, intVal2={1}, intVal3={2}", intVal1, intVal2, intVal3);
        }

        // ---------------------------------------------------------
        // ARRAYS are reference types:
        // - The reference is passed BY VALUE by default
        //   (the method gets a copy of the reference).
        // - Mutating elements via that reference IS visible to caller.
        // - Replacing the WHOLE array requires 'ref int[]'.
        // ---------------------------------------------------------
        static void PrintAndMutateArray(int[] intData)
        {
            Console.WriteLine("  [PrintAndMutateArray] Received: [{0}]", string.Join(", ", intData));
            intData[0] = 100; // mutation visible to caller
            Console.WriteLine("  [PrintAndMutateArray] After intData[0]=100: [{0}]", string.Join(", ", intData));
        }

        // Replace the entire array object (the caller's reference must be passed by ref)
        static void ReplaceArray(ref int[] intData)
        {
            Console.WriteLine("  [ReplaceArray] Current array: [{0}]", string.Join(", ", intData));
            intData = new int[] { 999, 888, 777 }; // replace the reference itself (requires 'ref int[]')
            Console.WriteLine("  [ReplaceArray] Replaced array: [{0}]", string.Join(", ", intData));
        }

        // ---------------------------------------------------------
        // 'in' parameters (readonly by-ref):
        // - Useful for large structs to avoid copying.
        // - Here for completeness; scalars gain little.
        // ---------------------------------------------------------
        static int SumReadonly(in int intA, in int intB)
        {
            // intA = 0; // not allowed; 'in' params are readonly in the method body
            return intA + intB;
        }

        // ---------------------------------------------------------
        // OUT example: accept and validate an email from the user
        // - Caller doesn't need to initialize 'out' before the call.
        // - Method guarantees assignment before returning.
        // ---------------------------------------------------------
        static void AcceptAndVerifyEmail(out string strTheEmail)
        {
            while (true)
            {
                Console.Write("What is your email? ");
                string input = Console.ReadLine() ?? string.Empty;
                if (input.Contains("@") && input.Contains("."))
                {
                    strTheEmail = input; // REQUIRED: assign OUT param
                    return;
                }
                Console.WriteLine("Wrong email - provide it again.");
            }
        }
    }
}
