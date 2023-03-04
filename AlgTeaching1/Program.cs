
using System;
using System.Collections.Generic;

namespace AlgTeaching1
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var array1 = new int[] { 1, 2, 3, 4, 5, 6 };
            var array2 = new int[] { 1, 2, 3, 4, 7, 8, 10, 12, 22 };

            //Program.CountDisposition();
            //Program.SearchReverse();
            // Program.TranslateTimeGrad();
            //Program.CheckLeapYear();
            //Program.СountDistancePointLine();
            //Program.CheckParalelPerpendikular();
            //Program.CountPointIntersectPerp();
            //Program.CountProcent();
            //Program.CountNumber();
            //Program.CountCornerClock();
            //Program.CalculationFlightNoise();
            //Program.SearchSegment();
            //Program.ClimbHole();
            //Program.IsCorrectMove();
            //IsLuckiNumber();
            //CalculationTravelTime();
            //FindingIntersection();
            //CheckSquare();
            //CalculationRating();
            //ReverseNumber();
            //SearchSummNumb();
            //SearchPositionNumber();
            //SearchLongestSubArray();.//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //CheckGrammatik();
            //MovingArr(array1);
            //CalculationLogicalSet(array1, array2);
            //TransferringNumberSystem(array1);
            TranslateFractionDecimal();
        }

        private static void TranslateFractionDecimal()
        {
            Console.WriteLine($"Введите делимое");
            var divisible = EnteringIntNumber();

            Console.WriteLine($"Введите делитель");
            var divider = EnteringIntNumber();

            var n1 = divisible % divider;

            var result = divisible / (double)divider;

            if (CheckDivederest(n1))
            {
                Console.WriteLine($"Результат деления:{result}");

            }

            else
            {
                string period = TranslateFraction(divisible, divider);
                PrintResult(period, result);            
            }
        }

        private static void PrintResult(string period, double result)
        {
            var resArr = new String(result.ToString());

            int indexPeriod = resArr.IndexOf(period);
            resArr = resArr.Substring(0, indexPeriod);

            Console.WriteLine($"Результат деления:{resArr}({period})");
        }

        private static string TranslateFraction(int divisible, int divider)
        {
            var isEnd = true;
            var period = "";
            var ch = new string[1000];
            var ost = new int[1000];
            int i = 0;

            while (!isEnd)
            {
                while (divisible < divider)
                {
                    divisible *= 10;
                }
                i++;
                ost[i] = divisible % divider;
                ch[i] = (divisible / divider).ToString();
                divisible = ost[i];
                for (int j = 0; j < i; j++)
                {
                    if (divisible == ost[j])
                    {
                        for (int k = j; k < i; k++)
                        {
                            period = ch[k].ToString();
                        }
                        isEnd = true;
                    }
                }
            }
            return period;
        }

        private static bool CheckDivederest(int n1)
        {
            while ((n1 % 2 == 0) || (n1 % 5 == 0))
            {
                if (n1 % 2 == 0)
                    n1 /= 2;
                if (n1 % 5 == 0)
                    n1 /= 5;
            }

            return n1 == 0;
        }

        private static void TransferringNumberSystem(int[] iNumber)
        {
            Console.WriteLine($"Введите начальную систему счисления");
            var startNumSystem = EnteringIntNumber();

            Console.WriteLine($"Введите конечную систему счисления");
            var resultNumSystem = EnteringIntNumber();

            var doubleResult = TransferTenSystem(iNumber, startNumSystem);

            var subResult = (int)doubleResult;

            List<int> result = TransferNewSystem(subResult, resultNumSystem); 

            Console.WriteLine($"Результат перевода:");

            for (int i = result.Count - 1; i >= 0 ; i--)
            {
                Console.Write(result[i]);
            }
        }

        private static List<int> TransferNewSystem(int subResult, int resultNumSystem)
        {
            var result = new List<int>();

            while (subResult > 0)
            {
                result.Add(subResult % resultNumSystem);
                subResult /= resultNumSystem;
            }

            return result;
        }

        private static double TransferTenSystem(int[] iNumber, int startNumSystem)
        {
            var  doubleResult = 0.0;

            for (int i = 0; i < iNumber.Length; i++)
            {
                doubleResult += iNumber[iNumber.Length - i - 1] * Math.Pow(startNumSystem, i);
            }

            return doubleResult;
        }

        private static void CalculationLogicalSet(int[] array1, int[] array2)
        {
            if (array1.Length > array2.Length)
            {
                CalculationLogical(array1, array2);
            }
            else
            {
                CalculationLogical(array2, array1);
            }

        }

        private static void CalculationLogical(int[] array1, int[] array2)
        {
            CalculationIntersection(array1, array2);

            CalculationAssosiation(array1, array2);

            CalculationDifference(array1, array2);

            CalculationDifference(array2, array1);

        }

        private static void CalculationDifference(int[] array1, int[] array2)
        {
            var result = new int[array1.Length];
            var isCommonElement = false;
            var isCommon = true; 
            var count = 0;

            foreach (var element1 in array1)
            {
                isCommonElement = false;
                foreach (var element2 in array2)
                {
                    if (element1 == element2)
                    {
                        isCommonElement = true;
                    }
                }

                if (!isCommonElement)
                {
                    Array.Fill<int>(result, element1, count, result.Length - count);
                    isCommon = false;
                    count++;
                }
            }

            Console.WriteLine("Результат вычитания массивовов: ");

            if (isCommon)
            {
                for (int i = 0; i < array1.Length; i++)
                {
                    Console.WriteLine(array1[i]);
                }
            }
            else
            {
                for (int i = 0; i < result.Length; i++)
                {
                    Console.WriteLine(result[i]);
                }
            }

        }

        private static void CalculationAssosiation(int[] array1, int[] array2)
        {
            var result = new int[array2.Length + array1.Length];

            array2.CopyTo(result, 0);
            array1.CopyTo(result, array2.Length);

            Console.WriteLine("Результат сложения массивово: ");
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine(result[i]);
            }
        }

        private static void CalculationIntersection(int[] array1, int[] array2)
        {
            var result = new int[array2.Length];
            var isIntersect = false;
            var count = 0;

            foreach (var element2 in array2)
            {
                foreach (var element1 in array1)
                {
                    if (element1 == element2)
                    {
                        isIntersect = true;
                        Array.Fill<int>(result, element1, count, result.Length - count);
                        count++;
                    }
                }
            }

            if (isIntersect)
            {
                Console.WriteLine("Результат пересечения массивово: ");
                for (int i = 0; i < result.Length; i++)
                {
                    Console.WriteLine(result[i]);
                }
            }
            else
            {
                Console.WriteLine("Массивы не пересекаются.");
            }
        }

        /// <summary>
        /// Метод для цикличного сдвига массива без использования доп подмассива
        /// </summary>
        /// <param name="array"></param>
        private static void MovingArr(int[] array)
        {
            Console.WriteLine("Введитк сдвиг");
            var shift = EnteringIntNumber();

            for (int i = 0; i < shift; i++)
            {
                array = ShiftArray(array);
            }

            Console.WriteLine("Результат свдига");
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        private static int[] ShiftArray(int[] array)
        {
            var k = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                array[i - 1] = array[i];
            }
            array[^1] = k;

            return array;
        }

        /// <summary>
        /// Метод для проверки правильности расставления скобок
        /// </summary>
        private static void CheckGrammatik()
        {
            Console.WriteLine($"Введите строку скобочек");
            var input = Console.ReadLine();

            var leftBracket = 0;
            var maxDepth = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (leftBracket < 0)
                    break;

                if (input[i] == '(')
                    leftBracket++;
                else leftBracket--;

                if (maxDepth < leftBracket)
                    maxDepth = leftBracket;
            }

            PrintResultBracket(leftBracket, maxDepth);
        }

        private static void PrintResultBracket(int leftBracket, int maxDepth)
        {
            if (leftBracket == 0)
                Console.WriteLine($"Правильное построение скобочек, максимальная глубина:{maxDepth}");
            else
                Console.WriteLine("Неправильное построение скобочек");
        }

        /// <summary>
        /// Метод для поиска наибольшого подмассива с одинаковыми значениями  
        /// </summary>
        /// <param name="array"></param>
        private static void SearchLongestSubArray(int[] array)
        {
            var indexSub = 0;
            var sizeSub = 0;
            var indexMaxSub = 0;
            var sizeMaxSub = 1;

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] == array[i + 1])
                {
                    sizeSub++;
                }

                else
                {
                    indexSub = i + 1;
                    sizeSub = 1;
                }

                if (sizeSub > sizeMaxSub)
                {
                    sizeMaxSub = sizeSub;
                    indexMaxSub = indexSub;
                }
            }

            var result = new int[sizeMaxSub];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = array[indexMaxSub + i];
            }

            Console.WriteLine($"искомый подмассив:");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Метод для поиска цифры, стоящей на заданной позиции, в натуральном ряду 
        /// </summary>
        private static void SearchPositionNumber()
        {
            Console.WriteLine("Введите параметр N");

            var initialNumber = EnteringIntNumber();
            string naturalRow = "";
            var naturalInt = 1;

            while (naturalRow.Length < initialNumber)
            {
                naturalRow = naturalRow.Insert(naturalRow.Length, naturalInt.ToString());
                naturalInt++;
            }

            Console.WriteLine(naturalRow);
            Console.WriteLine($"цифра стоит в заданной позиции N：{naturalRow[initialNumber - 1]}");
        }

        /// <summary>
        /// Метод для поиска троичного числа, сумма цифр которого равна заданному числу
        /// </summary>
        private static void SearchSummNumb()
        {
            Console.WriteLine("Введите параметр N");
            var initialNumber = EnteringIntNumber();
            var result = 0;

            for (int hundred = 1; hundred < 10; hundred++)
            {
                for (int ten = 0; ten < 10; ten++)
                {
                    for (int unit = 0; unit < 10; unit++)
                    {
                        if ((hundred + ten + unit) == initialNumber)
                        {
                            result++;
                        }
                    }
                }
            }

            Console.WriteLine($"количество трехзначных натуральных чисел, сумма цифр которых равна N：{result}");
        }

        /// <summary>
        /// Метод для разворота числа
        /// </summary>
        private static void ReverseNumber()
        {
            Console.WriteLine("Введите параметр x, который будет перевернут");
            var initialNumber = EnteringIntNumber();
            var result = 0;

            while (initialNumber > 0)
            {
                result *= 10;
                result += initialNumber % 10;
                initialNumber /= 10;
            }

            Console.WriteLine($"Перевернутое число：{result}");
        }

        /// <summary>
        /// Метод для расчета количества голосов необходимых для понижения рейтинга до определенного значения
        /// </summary>
        private static void CalculationRating()
        {
            Console.WriteLine("Введите параметр x");
            var x = EnteringDoubleNumber();

            Console.WriteLine("Введите параметр y");
            var y = EnteringDoubleNumber();

            Console.WriteLine("Введите параметр n");
            var n = EnteringDoubleNumber();


            var k1 = Math.Round((n * x / y - n), 1, MidpointRounding.ToEven) / Math.Round((1 - 1 / y), 1, MidpointRounding.ToEven);

            Console.WriteLine($"Нужное количество единиц：{k1}");

        }

        /// <summary>
        /// Метод для консольного ввода числа типа double
        /// </summary>
        /// <returns></returns>
        private static double EnteringDoubleNumber()
        {
            while (true)
            {
                string input = Console.ReadLine();
                bool result = double.TryParse(input, out var number);
                if (result == true)
                {
                    Console.WriteLine($"Преобразование прошло успешно. Число: {number}");
                    return number;
                }
                else
                    Console.WriteLine("Преобразование завершилось неудачно. Введите число повторно");
            }
        }

        /// <summary>
        /// Проверка трех точек на квадрат и поиск последней точки
        /// </summary>
        private static void CheckSquare()
        {
            Console.WriteLine("Введите параметр x1 первой точки");
            var x1 = EnteringIntNumber();

            Console.WriteLine("Введите параметр x2 второй точки");
            var x2 = EnteringIntNumber();

            Console.WriteLine("Введите параметр x3 третьей точки");
            var x3 = EnteringIntNumber();

            Console.WriteLine("Введите параметр у1 первой точки");
            var y1 = EnteringIntNumber();

            Console.WriteLine("Введите параметр у2 второй точки");
            var y2 = EnteringIntNumber();

            Console.WriteLine("Введите параметр у3 третьей точки");
            var y3 = EnteringIntNumber();

            if (IsSquare(x1, x2, x3, y1, y2, y3))
            {
                FindfLastPoint(x1, x2, x3, y1, y2, y3);
            }
        }

        /// <summary>
        /// Поик последний точки квадрата
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <param name="x3"></param>
        /// <param name="y1"></param>
        /// <param name="y2"></param>
        /// <param name="y3"></param>
        private static void FindfLastPoint(int x1, int x2, int x3, int y1, int y2, int y3)
        {
            var v12 = (x1 - x2) * (y1 - y2);
            var v13 = (x1 - x3) * (y1 - y3);
            var v23 = (x2 - x3) * (y2 - y3);
            var x4 = 0.0;
            var y4 = 0.0;

            if (v12 == -v13)
            {
                x4 = x2 + x3 - x1;
                y4 = y2 + y3 - y1;
            }
            else
            {
                if (v12 == -v23)
                {
                    x4 = x1 + x3 - x2;
                    y4 = y1 + y3 - y2;
                }
                else
                {
                    x4 = x1 + x2 - x3;
                    y4 = y1 + y2 - y3;
                }

            }
            Console.WriteLine($"Координаты 4 точки квадрата:{x4},{y4}");
        }

        /// <summary>
        /// Проверка на возможность постороения квадрата
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <param name="x3"></param>
        /// <param name="y1"></param>
        /// <param name="y2"></param>
        /// <param name="y3"></param>
        /// <returns></returns>
        private static bool IsSquare(int x1, int x2, int x3, int y1, int y2, int y3)
        {
            var distanceX1X2 = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));

            var distanceX1X3 = Math.Sqrt(Math.Pow(x1 - x3, 2) + Math.Pow(y1 - y3, 2));

            var distanceX2X3 = Math.Sqrt(Math.Pow(x3 - x2, 2) + Math.Pow(y3 - y2, 2));

            if ((distanceX1X2 == distanceX1X3) && (distanceX2X3 == Math.Sqrt(2 * distanceX1X2)))
                return true;
            if ((distanceX1X2 == distanceX2X3) && (distanceX1X3 == Math.Sqrt(2 * distanceX1X2)))
                return true;
            if ((distanceX2X3 == distanceX1X3) && (distanceX1X2 == Math.Sqrt(2 * distanceX2X3)))
                return true;
            return false;
        }

        /// <summary>
        /// Поиск пересечния отрезков 
        /// </summary>
        private static void FindingIntersection()
        {
            Console.WriteLine("Введите параметр A первого отрезка");
            var a = EnteringIntNumber();

            Console.WriteLine("Введите параметр B первого отрезка");
            var b = EnteringIntNumber();

            Console.WriteLine("Введите параметр C второго отрезка");
            var c = EnteringIntNumber();

            Console.WriteLine("Введите параметр D второго отрезка");
            var d = EnteringIntNumber();

            if (IsIntersect(a, b, c, d))
            {
                OutputIntersection(a, b, c, d);
            }
            else
            {
                Console.WriteLine("Отрезки не пересекаются.");
            }
        }

        private static void OutputIntersection(int a, int b, int c, int d)
        {
            var startSegment = Math.Min(c, d);
            var endSegment = Math.Max(c, d);

            if (Math.Min(a, b) > Math.Min(c, d))
            {
                startSegment = Math.Min(a, b);
            }

            if (Math.Max(a, b) < Math.Max(c, d))
            {
                endSegment = Math.Max(a, b);
            }

            Console.WriteLine($"Отрезки пересекаются со значения {startSegment} до значения {endSegment}");
        }

        private static bool IsIntersect(int a, int b, int c, int d)
        {
            bool isPointExtA = ((a <= Math.Max(c, d)) && (a >= Math.Min(c, d)));

            bool isPointExtB = ((b <= Math.Max(c, d)) && (b >= Math.Min(c, d)));

            bool isPointExtC = ((c <= Math.Max(a, b)) && (c >= Math.Min(a, b)));

            bool isPointExtD = ((d <= Math.Max(a, b)) && (d >= Math.Min(a, b)));

            return isPointExtA || isPointExtB || isPointExtC || isPointExtD;
        }

        /// <summary>
        /// Ввод инт в консоль в проверкой
        /// </summary>
        /// <returns></returns>
        private static int EnteringIntNumber()
        {
            while (true)
            {
                string input = Console.ReadLine();
                bool result = int.TryParse(input, out var number);
                if (result == true)
                {
                    Console.WriteLine($"Преобразование прошло успешно. Число: {number}");
                    return number;
                }
                else
                    Console.WriteLine("Преобразование завершилось неудачно. Введите число повторно");
            }
        }

        /// <summary>
        /// Рассчет минимального и максимлаьного времени в пути якутского оленевода
        /// </summary>
        private static void CalculationTravelTime()
        {
            Console.WriteLine("vvedite parametr l");
            var l = int.Parse(Console.ReadLine());

            Console.WriteLine("vvedite parametr k");
            var k = int.Parse(Console.ReadLine());

            Console.WriteLine("vvedite parametr h");
            var h = int.Parse(Console.ReadLine());

            CalculationMinTimeTravel(l, k, h);

            CalculationMaxTimeTravel(l, k, h);
        }

        private static void CalculationMinTimeTravel(int l, int k, int h)
        {
            var timeTravel = (l / k) * h;
            Console.WriteLine($"Min time is{timeTravel}");
        }

        private static void CalculationMaxTimeTravel(int l, int k, int h)
        {
            var timeTravel = (l / k) * h;
            if (l % k > 0)
            {
                timeTravel += h;
            }
            Console.WriteLine($"Max time is{timeTravel}");
        }

        /// <summary>
        /// Проверка предыдущего и следующего билета на счастливость
        /// </summary>
        private static void IsLuckiNumber()
        {
            Console.WriteLine("vvedite nomer byleta");
            string input = Console.ReadLine();

            bool result = int.TryParse(input, out var number);
            if (result == true)
                Console.WriteLine($"Преобразование прошло успешно. Число: {number}");
            else
                Console.WriteLine("Преобразование завершилось неудачно");

            int secondNumber = number + 1;
            int pervesNumber = number - 1;

            CheckSecondPerves(secondNumber, pervesNumber);
        }

        private static void CheckSecondPerves(int secondNumber, int pervesNumber)
        {
            if (CheckLucky(secondNumber))
            {
                Console.WriteLine("Sleduyshiy chastlivyi");
            }
            else
            {
                if (CheckLucky(pervesNumber))
                {
                    Console.WriteLine("Prediduchiy chastlivyi");
                }
                else
                {
                    Console.WriteLine("Net chastlivih");
                }
            }
        }

        private static bool CheckLucky(int number1)
        {
            int summ1 = 0;
            int summ2 = 0;
            for (int i = 0; i < 3; i++)
            {
                summ1 += number1 % 10;
                number1 /= 10;
            }

            for (int i = 0; i < 3; i++)
            {
                summ2 += number1 % 10;
                number1 /= 10;
            }

            return summ1 == summ2;
        }

        /// <summary>
        /// Проверка корректности хода шахматной фигуры
        /// </summary>
        private static void IsCorrectMove()
        {
            Console.WriteLine("vvedite nachalnuyu kletku");
            string from = Console.ReadLine();

            Console.WriteLine("vvedite konecnuy kletku");
            string to = Console.ReadLine();

            var dx = Math.Abs(to[0] - from[0]); //смещение фигуры по горизонтали

            var dy = Math.Abs(to[1] - from[1]); //смещение фигуры по вертикали

            IsCorrectMove(from, to, dx, dy, "Bishop");

            IsCorrectMove(from, to, dx, dy, "Horse");

            IsCorrectMove(from, to, dx, dy, "Tower");

            IsCorrectMove(from, to, dx, dy, "Queen");

            IsCorrectMove(from, to, dx, dy, "King");

        }

        private static void IsCorrectMove(string from, string to, int dx, int dy, string figure)
        {
            var isCorrect = false;

            switch (figure)
            {
                case "Bishop":
                    isCorrect = IsCorrectMoveBishop(from, to, dx, dy);
                    break;
                case "Horse":
                    isCorrect = IsCorrectMoveHorse(from, to, dx, dy);
                    break;
                case "Tower":
                    isCorrect = IsCorrectMoveTower(from, to, dx, dy);
                    break;
                case "Queen":
                    isCorrect = IsCorrectMoveQueen(from, to, dx, dy);
                    break;
                case "King":
                    isCorrect = IsCorrectMoveKing(from, to, dx, dy);
                    break;
            }

            string result = isCorrect ? ("Correct move for " + figure) : ("Incorrect move for " + figure);

            Console.WriteLine(result);
        }

        private static bool IsCorrectMoveKing(string from, string to, int dx, int dy)
        {
            return (dx <= 1) && (dy <= 1) && (from != to);
        }

        private static bool IsCorrectMoveQueen(string from, string to, int dx, int dy)
        {
            return ((dx == 0) || (dy == 0) || ((dx * dx) == (dy * dy))) && (from != to);
        }

        private static bool IsCorrectMoveTower(string from, string to, int dx, int dy)
        {
            return ((dx == 0) || (dy == 0)) && (from != to);
        }

        private static bool IsCorrectMoveHorse(string from, string to, int dx, int dy)
        {
            return (((dx == 2) && (dy == 1)) || ((dx == 1) && (dy == 2))) && (from != to);
        }

        private static bool IsCorrectMoveBishop(string from, string to, int dx, int dy)
        {
            return ((dx * dx) == (dy * dy)) && (from != to);
        }

        /// <summary>
        /// Вывод в консоли пролезет ли брус в дырку
        /// </summary>
        private static void ClimbHole()
        {
            Console.WriteLine("vvedite parametr sideBalkA");
            var sideBalkA = double.Parse(Console.ReadLine());

            Console.WriteLine("vvedite parametr sideBalkB");
            var sideBalkB = double.Parse(Console.ReadLine());

            Console.WriteLine("vvedite parametr sideBalkC");
            var sideBalkC = double.Parse(Console.ReadLine());

            Console.WriteLine("vvedite parametr sideHoleA");
            var sideHoleA = double.Parse(Console.ReadLine());

            Console.WriteLine("vvedite parametr sideHoleB");
            var sideHoleB = double.Parse(Console.ReadLine());

            bool result = ComparSides(sideHoleA, sideHoleB, sideBalkA, sideBalkB, sideBalkC);

            if (result) { Console.WriteLine("Prolezet"); }
            else { Console.WriteLine("Ne prolezet"); }
        }

        /// <summary>
        /// проверка бруска на пролезания
        /// </summary>
        /// <param name="sideHoleA">перва сторона дырка</param>
        /// <param name="sideHoleB">вторая сторона дырка</param>
        /// <param name="sideBalkA">первый сторона брусок</param>
        /// <param name="sideBalkB">второй стороная брусок</param>
        /// <param name="sideBalkC">третий сторона брус</param>
        /// <returns></returns>
        private static bool ComparSides(double sideHoleA, double sideHoleB, double sideBalkA, double sideBalkB, double sideBalkC)
        {
            if (CheckTwoSide(sideBalkA, sideBalkB, sideHoleA, sideHoleB))
            {
                return true;
            }

            if (CheckTwoSide(sideBalkA, sideBalkC, sideHoleA, sideHoleB))
            {
                return true;
            }

            if (CheckTwoSide(sideBalkB, sideBalkC, sideHoleA, sideHoleB))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Проверка одной плоскости бруска
        /// </summary>
        /// <param name="sideBalkA"></param>
        /// <param name="sideBalkB"></param>
        /// <param name="sideHoleA"></param>
        /// <param name="sideHoleB"></param>
        /// <returns></returns>
        private static bool CheckTwoSide(double sideBalkA, double sideBalkB, double sideHoleA, double sideHoleB)
        {
            if ((sideBalkA <= sideHoleA) && (sideBalkB <= sideHoleB))
            {
                return true;
            }

            if ((sideBalkA <= sideHoleA) && (sideBalkB <= sideHoleB))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// рассчитывает, какой размер от огорода съест коза
        /// </summary>
        private static void SearchSegment()
        {
            double circleRadius = 0;
            double areaSquare = 0;
            double result = 0;

            Console.WriteLine("vvedite parametr circleRadius");
            circleRadius = double.Parse(Console.ReadLine());

            Console.WriteLine("vvedite parametr areaSquare");
            areaSquare = double.Parse(Console.ReadLine());

            double sideSquare = Math.Sqrt(areaSquare);
            double diagonalSquare = sideSquare * Math.Sqrt(2);

            if (circleRadius > (diagonalSquare / 2))
            {
                result = areaSquare;
            }
            else
            {
                if (circleRadius < (sideSquare / 2))
                {
                    result = circleRadius * circleRadius * Math.PI;
                }
                else
                {
                    double corner = 2 * Math.Acos((sideSquare / 2) / circleRadius);
                    double segment = 2 * Math.Sqrt(circleRadius * circleRadius - (sideSquare / 2) * (sideSquare / 2));
                    result = (circleRadius * circleRadius) * (corner - Math.Sin(corner)) / 2;
                    result = Math.PI * (circleRadius * circleRadius) - result * 4;
                }
            }


            Console.WriteLine($"kozel cyel:{result}");

        }

        /// <summary>
        /// рассчитывает максимальное и минимальное время шума при взлете
        /// </summary>
        private static void CalculationFlightNoise()
        {
            double time = 0;
            double high = 0;
            double maxVelocity = 0;
            double noiseSpeed = 0;

            Console.WriteLine("vvedite parametr time");
            time = double.Parse(Console.ReadLine());

            Console.WriteLine("vvedite parametr high");
            high = double.Parse(Console.ReadLine());

            Console.WriteLine("vvedite parametr velocity");
            maxVelocity = double.Parse(Console.ReadLine());

            Console.WriteLine("vvedite parametr velocity");
            noiseSpeed = double.Parse(Console.ReadLine());

            double minVelocity = high / time;
            double maxTime = high / noiseSpeed;
            double minTime = 0;
            double timeFly = high / (noiseSpeed - 0.0001);


            if (minVelocity > noiseSpeed)
            {
                timeFly = timeFly - time;
                timeFly = timeFly * (noiseSpeed - 0.0001) / (maxVelocity - noiseSpeed);
                minTime = timeFly;
            }

            if (maxTime > time)
            {
                maxTime = time;
            }

            Console.WriteLine($"minimalnoe vremya:{minTime}, maximalnoe vremya:{maxTime}");

        }

        /// <summary>
        /// рассчитывает градус между минутной и часовой стрелкой
        /// </summary>
        private static void CountCornerClock()
        {
            double hourse = 0;
            double minut = 0;
            double grad = 0;
            double dopMin = 0;

            Console.WriteLine("vvedite chas");
            hourse = int.Parse(Console.ReadLine());

            Console.WriteLine("vvedite minuty");
            minut = int.Parse(Console.ReadLine());

            dopMin = 30 / 60 * minut;
            minut = minut * 6;
            hourse = (hourse % 12) * 30 + dopMin;

            grad = hourse - minut;
            if (grad < 0)
            {
                grad = grad * (-1);
            }
            if ((grad) > 180)
            {
                grad = 360 - (grad);
            }

            Console.WriteLine($" chislo gradusov:{grad}");
        }

        /// <summary>
        /// выводит сумму чисел делящихся на 5 и на 3 до 1000
        /// </summary>
        private static void CountNumber()
        {
            int result = ((10 + 5 * (999 / 5 - 1)) / 2) * (999 / 5);
            result = result + ((6 + 3 * (999 / 3 - 1)) / 2) * (999 / 3);
            double result1 = ((30 + 15 * (66 - 1)) / (double)2) * 66;
            result = result - (int)result;

            Console.WriteLine($":{result}");
        }

        /// <summary>
        /// Расчет процентной ставки по месяцам;
        /// </summary>
        private static void CountProcent()
        {
            Console.WriteLine($"Введите начальные данные");
            var userData = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            var initialAmount = double.Parse(userData[0], System.Globalization.CultureInfo.InvariantCulture);
            var interestRate = double.Parse(userData[1], System.Globalization.CultureInfo.InvariantCulture);
            var depositTerm = double.Parse(userData[2], System.Globalization.CultureInfo.InvariantCulture);

            Console.WriteLine($"Итоговая сумма: {Program.Calculate(initialAmount, interestRate, depositTerm)}");
        }

        private static double Calculate(double initialAmount, double interestRate, double depositTerm)
        {
            var interestMonth = (double)interestRate / (100 * 12);
            double summ = initialAmount * Math.Pow((1 + (interestMonth)), depositTerm);

            return summ;
        }


        /// <summary>
        /// Метод для нахождения точки пересечения прямой L с перпендикулярной ей прямой P, проходящей через точку A. 
        /// </summary>
        private static void CountPointIntersectPerp()
        {

            double a1 = 0;
            double b1 = 0;
            double c1 = 0;

            Console.WriteLine("vvedite parametr a pryamoy ");
            a1 = double.Parse(Console.ReadLine());

            Console.WriteLine("vvedite parametr b pryamoy");
            b1 = double.Parse(Console.ReadLine());

            Console.WriteLine("vvedite parametr с pryamoy");
            c1 = double.Parse(Console.ReadLine());

            double x1 = 0;
            double y1 = 0;

            Console.WriteLine("vvedite parametr x tochky ");
            x1 = double.Parse(Console.ReadLine());

            Console.WriteLine("vvedite parametr y tochky");
            y1 = double.Parse(Console.ReadLine());

            double a2 = -a1;
            double b2 = -(a1 / b1) * (-a1);
            double c2 = (-x1 + y1 * (a1 / b1)) * (-a1);

            double y2 = -(c1 + c2) / (b1 + b2);
            double x2 = (-y2 * b1 - c1) / (a1);


            Console.WriteLine($"Параметры точки пересечния:({x2},{y2})");

        }

        /// <summary>
        /// мeтод для нахождение направляющей прямой и нормали
        /// </summary>
        static void CheckParalelPerpendikular()
        {

            double a = 0;
            double b = 0;
            double c = 0;

            Console.WriteLine("vvedite parametr a pryamoy ");
            a = double.Parse(Console.ReadLine());

            Console.WriteLine("vvedite parametr b pryamoy");
            b = double.Parse(Console.ReadLine());

            Console.WriteLine("vvedite parametr с pryamoy");
            c = double.Parse(Console.ReadLine());

            Console.WriteLine($"vektor paralelnoy pryamoy:({-b},{a})");

            Console.WriteLine($"vektor perpedikularnoy pryamoy:({a},{b})");



        }

        /// <summary>
        /// Метод рассчитывает расстояние от точки до прямой
        /// </summary>
        private static void СountDistancePointLine()
        {
            double firstParametrPoint = 0;
            double secondParametrPoint = 0;
            double result = 0;

            Console.WriteLine("vvedite pervye parametr tochki");
            firstParametrPoint = double.Parse(Console.ReadLine());

            Console.WriteLine("vvedite vtoroy parametr tochki");
            secondParametrPoint = double.Parse(Console.ReadLine());

            double firstParametrPryam1 = 0;
            double secondParametrPryam1 = 0;

            double firstParametrPryam2 = 0;
            double secondParametrPryam2 = 0;

            Console.WriteLine("vvedite pervye parametr 1 tochki pryamoy ");
            firstParametrPryam1 = double.Parse(Console.ReadLine());

            Console.WriteLine("vvedite vtoroy parametr 1 tochki pryamoy");
            secondParametrPryam1 = double.Parse(Console.ReadLine());

            Console.WriteLine("vvedite pervye parametr 2 tochki pryamoy");
            firstParametrPryam2 = double.Parse(Console.ReadLine());

            Console.WriteLine("vvedite vtoroy parametr 2 tochki pryamoy");
            secondParametrPryam2 = double.Parse(Console.ReadLine());

            double k = (secondParametrPryam2 - secondParametrPryam1) / (firstParametrPryam2 - firstParametrPryam1);
            double b = (firstParametrPryam2 * secondParametrPryam1 - firstParametrPryam1 * secondParametrPryam2) / (firstParametrPryam2 - firstParametrPryam1);


            result = k * firstParametrPoint - secondParametrPoint + b;
            result = result * result;
            result = Math.Sqrt(result);
            result = result / Math.Sqrt(k * k + 1);

            Console.WriteLine($" rsstoyaniy ot tochki do pram:{result}");

            return;

        }


        /// <summary>
        /// Метод для оределения количества високосных годов
        /// </summary>
        static void CheckLeapYear()
        {
            int date1 = 0;
            int date2 = 0;
            int result = 0;

            Console.WriteLine("vvedite pervyi god");
            date1 = int.Parse(Console.ReadLine());

            Console.WriteLine("vvedite vtoroy god");
            date2 = int.Parse(Console.ReadLine());

            if (date1 == date2)
            {
                if (date1 % 4 == 0)
                {
                    result++;
                    Console.WriteLine($" chislo vis let:{result}");
                    return;
                }
                Console.WriteLine($" chislo vis let:{result}");
                return;
            }

            result = date2 / 4 - (date1 - 1) / 4 - date2 / 100 + date2 / 400 + date1 / 100 - date1 / 400;

            Console.WriteLine($" chislo vis let:{result}");
            return;

        }

        /// <summary>
        /// Метод, определяющий градус отклонение часовой стрелки от 12 часов в градусах 
        /// </summary>
        private static void TranslateTimeGrad()
        {
            int hourse = 0;
            int grad = 0;
            int flag = 0;

            Console.WriteLine("vvedite vremya");
            hourse = int.Parse(Console.ReadLine());

            hourse = hourse % 12;
            flag = hourse / 7;
            grad = (hourse * 30) - flag * (hourse * 30) + flag * (12 - hourse) * 30;
            Console.WriteLine($" chislo gradusov:{grad}");

        }

        /// <summary>
        /// Метод для разворота 3-хзнаного числа
        /// </summary>
        static void SearchReverse()
        {
            int number = 0;
            Console.WriteLine("vvedite chislo");

            number = int.Parse(Console.ReadLine());
            number = (number + ((number % 10) * 10000)) / 10 * 10;
            number = (number + ((number % 100) * 100)) / 100 * 100;
            number = number / 100;
            Console.WriteLine($"Reverse chislo:{number}");


        }

        /// <summary>
        /// Метод для изменения значения двух чисел местами
        /// </summary>
        static void CountDisposition()
        {
            int secondNumber = 0;
            int firstNumber = 0;

            Console.WriteLine("vvedite pervoe chislo");
            firstNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("vvedite vtoroe chislo");
            secondNumber = int.Parse(Console.ReadLine());

            if (firstNumber > secondNumber)
            {
                firstNumber = firstNumber - secondNumber;
                secondNumber = secondNumber + firstNumber;
                firstNumber = secondNumber - firstNumber;
                Console.WriteLine($"firstNumber is:{firstNumber}  secondnumb is:{secondNumber}");
                return;
            }
            if (firstNumber < secondNumber)
            {
                secondNumber = secondNumber - firstNumber;
                firstNumber = firstNumber + secondNumber;
                secondNumber = firstNumber - secondNumber;
                Console.WriteLine($"firstNumber is:{firstNumber}  secondnumb is:{secondNumber}");
                return;
            }
            Console.WriteLine($"firstNumber is:{firstNumber}  secondnumb is:{secondNumber}");
            return;
        }
    }
}
