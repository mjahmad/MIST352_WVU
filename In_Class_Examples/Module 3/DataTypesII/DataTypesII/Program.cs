/*
=====================================================================
MIST 352 – Business Application Programming
Module 3.B – More with Data Types (Arrays + Index-from-End + Ranges)


This program is intentionally long and heavily documented. It demonstrates:
1) What arrays are (business use cases)
2) How to declare, create, and assign arrays
3) Zero-based indexing (index starts at 0)
4) Index-from-end operator: ^ (C# 8+)
5) Range operator: .. (C# 8+ slicing)
6) Common array mistakes (what NOT to do)
7) Basic array tools: Sort, BinarySearch, Reverse, Clear
8) Array members: Length, Rank, GetLength, Clone
9) Strings as arrays (characters)

IMPORTANT NOTE
- You may COMMENT/UNCOMMENT sections to focus on one topic at a time.
- Run using Ctrl + F5 (recommended).
=====================================================================
*/

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("============================================================");
        Console.WriteLine("MIST 352 - Module 3.B Demo: Arrays, ^, Ranges, and Tools");
        Console.WriteLine("============================================================\n");

        // ============================================================
        // SECTION 0: A business story (why arrays exist)
        // ============================================================
        Console.WriteLine("----- SECTION 0: Why arrays exist (business story) -----");
        Console.WriteLine("Business systems rarely store one value at a time.");
        Console.WriteLine("Example: weekly sales, monthly revenue, daily orders, product list.");
        Console.WriteLine("Arrays let us store many related values under ONE variable name.\n");

        // ============================================================
        // SECTION 1: Declaring arrays (1D and 2D)
        // ============================================================
        Console.WriteLine("----- SECTION 1: Declaring arrays -----");

        // Declaration means: define the variable and its type.
        // The brackets [] belong to the TYPE in C#.
        string[] departments;      // 1D array of strings
        int[,] seatingChart;       // 2D array (grid-like) of integers

        Console.WriteLine("Declared: string[] departments; (not created yet)");
        Console.WriteLine("Declared: int[,] seatingChart; (not created yet)\n");

        // ============================================================
        // SECTION 2: Instantiating/creating arrays + assignment styles
        // ============================================================
        Console.WriteLine("----- SECTION 2: Creating arrays and assigning values -----");

        // (A) Declare + assign immediately (array literal)
        departments = new string[] {
            "Sales", "HR", "Finance",
            "IT", "Legal", "Operations",
            "Marketing", "Audit", "Support"
        };

        Console.WriteLine("Departments array created with 9 items:");
        Console.WriteLine(string.Join(", ", departments));
        Console.WriteLine();

        // (B) Allocate size only (default values)
        // Business example: a company wants to store 7 daily order counts, but doesn't know them yet.
        int[] dailyOrders = new int[7]; // default values will be 0
        Console.WriteLine("Created dailyOrders = new int[7];");
        Console.WriteLine("At this moment, dailyOrders has default values (0s):");
        Console.WriteLine(string.Join(", ", dailyOrders));
        Console.WriteLine();

        // Assign values manually (no loops yet)
        dailyOrders[0] = 120; // Monday
        dailyOrders[1] = 95;  // Tuesday
        dailyOrders[2] = 110; // Wednesday
        dailyOrders[3] = 130; // Thursday
        dailyOrders[4] = 80;  // Friday
        dailyOrders[5] = 60;  // Saturday
        dailyOrders[6] = 70;  // Sunday

        Console.WriteLine("After assigning dailyOrders manually (still no loops):");
        Console.WriteLine(string.Join(", ", dailyOrders));
        Console.WriteLine();

        // ============================================================
        // SECTION 3: Forward indexing (zero-based)
        // ============================================================
        Console.WriteLine("----- SECTION 3: Forward indexing (zero-based) -----");

        // Key rule: index starts at 0.
        // Think of index as "offset from the beginning".
        Console.WriteLine($"First department (index 0): {departments[0]}");
        Console.WriteLine($"Second department (index 1): {departments[1]}");
        Console.WriteLine($"Third department (index 2): {departments[2]}");
        Console.WriteLine();

        // Business example: access Friday orders (index 4 if Monday is index 0)
        Console.WriteLine($"Friday orders (index 4): {dailyOrders[4]}");
        Console.WriteLine();

        // ============================================================
        // SECTION 4: Length vs last index (MOST COMMON MISTAKE)
        // ============================================================
        Console.WriteLine("----- SECTION 4: Length vs last index -----");

        // Length is the total number of items.
        // Last index is Length - 1.
        Console.WriteLine($"departments.Length = {departments.Length}");
        Console.WriteLine($"Last valid index = departments.Length - 1 = {departments.Length - 1}");
        Console.WriteLine($"Last department using Length - 1: {departments[departments.Length - 1]}");
        Console.WriteLine();

        // ============================================================
        // SECTION 5: Index-from-end operator (^) (C# 8+)
        // ============================================================
        Console.WriteLine("----- SECTION 5: Index-from-end operator (^) -----");

        // ^1 means "last item"
        // ^2 means "second from last"
        // ^0 is invalid when accessing a single element (it means 1 past the end).
        Console.WriteLine($"Last department (^1): {departments[^1]}");
        Console.WriteLine($"Second from last (^2): {departments[^2]}");
        Console.WriteLine($"Third from last (^3): {departments[^3]}");
        Console.WriteLine();

        // Business example: last day in a week (Sunday)
        Console.WriteLine($"Last day orders (^1): {dailyOrders[^1]}");
        Console.WriteLine($"Second-to-last day orders (^2): {dailyOrders[^2]}");
        Console.WriteLine();

        // ============================================================
        // SECTION 6: Ranges (..) - slicing arrays (C# 8+)
        // ============================================================
        Console.WriteLine("----- SECTION 6: Ranges (..) - slicing arrays -----");

        // RANGE RULE:
        // start..end includes start (inclusive) and stops BEFORE end (exclusive).
        // This is a professional standard rule and prevents off-by-one mistakes.

        // Example: First three departments: index 0..3 (0,1,2)
        Console.WriteLine($"0..3 (first three departments): {string.Join(", ", departments[0..3])}");

        // Example: last three departments: ^3..^0
        // NOTE: ^0 is allowed here because the END of a range is exclusive (it doesn't try to access ^0).
        Console.WriteLine($"^3..^0 (last three departments): {string.Join(", ", departments[^3..^0])}");

        // Example: middle slice (skip first 3 and last 3)
        Console.WriteLine($"3..^3 (middle slice): {string.Join(", ", departments[3..^3])}");

        // Example: everything except last 6 -> keeps first 3
        Console.WriteLine($"..^6 (keeps first 3): {string.Join(", ", departments[..^6])}");

        // Example: from index 6 to end
        Console.WriteLine($"6.. (from index 6 to end): {string.Join(", ", departments[6..])}");

        // Example: entire array
        Console.WriteLine($".. (entire array): {string.Join(", ", departments[..])}");
        Console.WriteLine();

        // Business-style range example: weekly orders
        // Suppose we want weekday orders only (Mon-Fri): 0..5 includes indices 0-4.
        Console.WriteLine("Business slice example: Weekday orders only (Mon-Fri):");
        Console.WriteLine(string.Join(", ", dailyOrders[0..5]));
        Console.WriteLine();

        // Suppose we want the last 2 days (Sat-Sun): ^2..^0
        Console.WriteLine("Business slice example: Weekend orders only (Sat-Sun):");
        Console.WriteLine(string.Join(", ", dailyOrders[^2..^0]));
        Console.WriteLine();

        // ============================================================
        // SECTION 7: Swapping values in an array (business correction)
        // ============================================================
        Console.WriteLine("----- SECTION 7: Swapping values (fixing data order) -----");

        // Business scenario: someone accidentally entered Finance and IT in the wrong order.
        // We will swap departments[2] and departments[3].

        Console.WriteLine("Before swap:");
        Console.WriteLine(string.Join(", ", departments));

        string temp = departments[3];      // store IT
        departments[3] = departments[2];   // put Finance in IT spot
        departments[2] = temp;             // put IT in Finance spot

        Console.WriteLine("After swap (Finance <-> IT):");
        Console.WriteLine(string.Join(", ", departments));
        Console.WriteLine();

        // ============================================================
        // SECTION 8: Multidimensional arrays (grid-like business data)
        // ============================================================
        Console.WriteLine("----- SECTION 8: Multidimensional arrays (2D grid concept) -----");

        // Business scenario: store a 3x3 seating chart (or a simple grid layout).
        // 0 means empty means no one assigned. 1 means filled/occupied (simple model).
        seatingChart = new int[3, 3];

        // Assign a few positions
        seatingChart[0, 0] = 1;
        seatingChart[1, 2] = 1;

        Console.WriteLine("Created seatingChart = new int[3,3]; and marked two seats as occupied.");
        Console.WriteLine("Note: We won't print the whole grid yet (printing grids is easier with loops).");

        // Array instance members for multidimensional arrays
        Console.WriteLine($"seatingChart.Rank (dimensions): {seatingChart.Rank}");
        Console.WriteLine($"seatingChart.GetLength(0) (rows): {seatingChart.GetLength(0)}");
        Console.WriteLine($"seatingChart.GetLength(1) (cols): {seatingChart.GetLength(1)}");
        Console.WriteLine($"seatingChart.Length (total cells): {seatingChart.Length}");
        Console.WriteLine();

        // ============================================================
        // SECTION 9: Jagged arrays (array of arrays) - concept only
        // ============================================================
        Console.WriteLine("----- SECTION 9: Jagged arrays (concept) -----");

        // Jagged arrays are useful when rows can have different lengths.
        // Business example: departments with different numbers of employees.
        int[][] employeesPerDepartment = new int[][]
        {
            new int[] { 10, 12, 9 },   // Dept A has 3 teams
            new int[] { 7, 5 },        // Dept B has 2 teams
            new int[] { 20, 18, 15, 11 } // Dept C has 4 teams
        };

        Console.WriteLine("Jagged array example created: teams per department can vary.");
        Console.WriteLine($"employeesPerDepartment.Length (departments count): {employeesPerDepartment.Length}");
        Console.WriteLine("Note: Printing all nested values is easier once we learn loops.\n");

        // ============================================================
        // SECTION 10: More Array Methods (Sort, BinarySearch, Reverse, Clear)
        // ============================================================
        Console.WriteLine("----- SECTION 10: Array methods (Sort, Search, Reverse, Clear) -----");

        // We'll use a copy of departments so we don't destroy our original order permanently.
        // Clone() makes a shallow copy of the array (new array reference).
        string[] departmentsCopy = (string[])departments.Clone();

        Console.WriteLine("Before Sort:");
        Console.WriteLine(string.Join(", ", departmentsCopy));
        Console.WriteLine();

        Array.Sort(departmentsCopy); // alphabetical
        Console.WriteLine("After Sort (alphabetical):");
        Console.WriteLine(string.Join(", ", departmentsCopy));
        Console.WriteLine();

        // BinarySearch requires sorted data.
        string searchFor = "HR";
        int foundIndex = Array.BinarySearch(departmentsCopy, searchFor);
        Console.WriteLine($"BinarySearch for '{searchFor}' returned index: {foundIndex}");
        Console.WriteLine("(If the value is not found, the returned index is negative.)\n");

        Array.Reverse(departmentsCopy);
        Console.WriteLine("After Reverse:");
        Console.WriteLine(string.Join(", ", departmentsCopy));
        Console.WriteLine();

        // Clear sets elements to default values; it does NOT shrink the array.
        Array.Clear(departmentsCopy, 0, departmentsCopy.Length);
        Console.WriteLine("After Clear (notice the size is unchanged, but items are default/null):");
        Console.WriteLine("string.Join will show blanks because each element is now null:");
        Console.WriteLine(string.Join(", ", departmentsCopy));
        Console.WriteLine($"Array size after Clear: {departmentsCopy.Length}\n");

        // ============================================================
        // SECTION 11: Array instance member recap (Length, Clone)
        // ============================================================
        Console.WriteLine("----- SECTION 11: Array member recap -----");
        Console.WriteLine($"departments.Length = {departments.Length}");
        Console.WriteLine("Clone() copies the array container. Changing the clone does not change the original container.\n");

        // Demonstrate clone independence (container-level)
        string[] cloneTest = (string[])departments.Clone();
        cloneTest[0] = "CHANGED-IN-CLONE";

        Console.WriteLine("Original departments[0]: " + departments[0]);
        Console.WriteLine("Clone departments[0]: " + cloneTest[0]);
        Console.WriteLine("(This shows the clone array is a different array container.)\n");

        // ============================================================
        // SECTION 12: Strings as arrays (characters)
        // ============================================================
        Console.WriteLine("----- SECTION 12: Strings as arrays (characters) -----");

        // Business example: product codes or employee IDs.
        string productCode = "A102X";

        Console.WriteLine($"Product code: {productCode}");
        Console.WriteLine($"First character (index 0): {productCode[0]}");
        Console.WriteLine($"Last character (^1): {productCode[^1]}");
        Console.WriteLine("Reminder: strings are immutable, so you can't do productCode[0] = 'B'.\n");

        // ============================================================
        // SECTION 13: Common errors (DO NOT RUN - examples only)
        // ============================================================
        Console.WriteLine("----- SECTION 13: Common array errors (examples only) -----");
        Console.WriteLine("These examples are COMMON mistakes. Do NOT run them.\n");

        Console.WriteLine("1) Wrong bracket placement:");
        Console.WriteLine("   WRONG: int numbers[];");
        Console.WriteLine("   RIGHT: int[] numbers;\n");

        Console.WriteLine("2) Assigning after declaration without 'new':");
        Console.WriteLine("   WRONG: numbers = {42, 84};");
        Console.WriteLine("   RIGHT: numbers = new int[]{42, 84};\n");

        Console.WriteLine("3) Using Length as an index (out of bounds):");
        Console.WriteLine("   WRONG: numbers[numbers.Length]");
        Console.WriteLine("   RIGHT: numbers[numbers.Length - 1]  OR  numbers[^1]\n");

        Console.WriteLine("4) Using ^0 as a single-element index (out of bounds):");
        Console.WriteLine("   WRONG: numbers[^0]");
        Console.WriteLine("   RIGHT: numbers[^1]\n");

        Console.WriteLine("5) Off-by-one indexing:");
        Console.WriteLine("   If array length is 3, valid indices are 0, 1, 2 (NOT 3).\n");

        Console.WriteLine("============================================================");
        Console.WriteLine("END of Module 3.B Demo");
        Console.WriteLine("============================================================");
    }
}
