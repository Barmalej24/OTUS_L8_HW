using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml.Linq;

namespace OTUS_L8_HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = 1_000_000,
                index = 496_753, 
                element = 777;

            Console.WriteLine("================= RunTime Init ================");
            var list = InitList(count, true);
            var arrayList = InitArrayList(count, true);
            var linkedList = InitLinkedList(count, false);

            Console.WriteLine("================= RunTime Search Index ================");
            Search(index, list);
            Search(index, arrayList);
            Search(index, linkedList);

            Console.WriteLine("================= RunTime Foreach Element ================");
            ForeachElement(element, list, false);
            ForeachElement(element, arrayList, true);
            ForeachElement(element, linkedList, false);
        }

        static List<int> InitList(int count, bool fullTime)
        {
            List<int> list = new List<int>();
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            for (int i = 1; i <= count; i++)
            {
                list.Add(i);
            }
            stopWatch.Stop();

            Console.WriteLine($"RunTime InitList {TimeToString(stopWatch, fullTime)}");
            return list;
        }
        static ArrayList InitArrayList(int count, bool fullTime)
        {
            ArrayList arrayList = new ArrayList();
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            for (int i = 1; i <= count; i++)
            {
                arrayList.Add(i);
            }
            stopWatch.Stop();

            Console.WriteLine($"RunTime InitArrayList {TimeToString(stopWatch, fullTime)}");
            return arrayList;
        }
        static LinkedList<int> InitLinkedList(int count, bool fullTime)
        {
            LinkedList<int> linkedList = new LinkedList<int>();
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            for (int i = 1; i <= count; i++)
            {
                linkedList.AddLast(i);
            }
            stopWatch.Stop();

            Console.WriteLine($"RunTime InitLinkedList {TimeToString(stopWatch, fullTime)}");
            return linkedList;
        }

        static void Search(int index, List<int> list)
        {            
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            var element = list[index];
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine($"Значение элемента с индексом [{index}] => {element}");
            Console.WriteLine($"RunTime list[{index}] {ts.TotalMicroseconds}");
            
        }
        static void Search(int index, ArrayList list)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            var element = list[index];
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine($"Значение элемента с индексом [{index}] => {element}");
            Console.WriteLine($"RunTime arrayList[{index}] {ts.TotalMicroseconds}");
        }
        static void Search(int index, LinkedList<int> list)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            var element = list.ElementAt(index);
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine($"Значение элемента с индексом [{index}] => {element}");
            Console.WriteLine($"RunTime linkedList.Find {ts.TotalMicroseconds}");
        }

        static void ForeachElement(int element, List<int> list, bool fullTime, bool printResult = false)
        {
            Stopwatch stopWatch = new Stopwatch();
            StringBuilder sb = new StringBuilder();

            stopWatch.Start();
            foreach (var item in list)
            {
                if (item % element == 0)
                    sb.Append($"{item} ");
            }
            stopWatch.Stop();

            if (printResult)
                Console.WriteLine(sb.ToString());
            Console.WriteLine($"RunTime foreach List {TimeToString(stopWatch, fullTime)}");
        }
        static void ForeachElement(int element, ArrayList list, bool fullTime, bool printResult = false)
        {
            Stopwatch stopWatch = new Stopwatch();
            StringBuilder sb = new StringBuilder();

            stopWatch.Start();
            foreach (var item in list)
            {
                if ((int)item % element == 0)
                    sb.Append($"{item} ");
            }
            stopWatch.Stop();

            if (printResult)
                Console.WriteLine(sb.ToString());
            Console.WriteLine($"RunTime foreach ArrayList {TimeToString(stopWatch, fullTime)}");
        }
        static void ForeachElement(int element, LinkedList<int> list, bool fullTime, bool printResult = false)
        {
            Stopwatch stopWatch = new Stopwatch();
            StringBuilder sb = new StringBuilder();

            stopWatch.Start();
            foreach (var item in list)
            {
                if (item % element == 0)
                    sb.Append($"{item} ");
            }
            stopWatch.Stop();

            if (printResult)
                Console.WriteLine(sb.ToString());
            Console.WriteLine($"RunTime foreach LinkedList {TimeToString(stopWatch, fullTime)}");
        }
        
        static string TimeToString(Stopwatch time, bool fullTime)
        {
            TimeSpan ts = time.Elapsed;
            if (fullTime)
            {
                return $"- Microseconds => {ts.TotalMicroseconds}";
            }
            else
            {                
                return $"- Human-readable format => {ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds:000}";
            }
        }

    }
}