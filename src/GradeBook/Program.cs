
using GradeBook;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var book = new DiskBook("Scott's Grade Book");
            EnterGrades(book);
            
            var stats = book.GetStats();

            Console.WriteLine($"The highest grade is: {stats.High}");
            Console.WriteLine($"The lowest grade is: {stats.Low}");
            Console.WriteLine($"The average grade is: {stats.Average:N1}");
            Console.WriteLine($"The letter is: {stats.Letter}");
        }

        private static void EnterGrades(IBook book)
        {
            while(true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();

                if(input == "q")
                {   
                    break;
                }

                if(string.IsNullOrEmpty(input)){
                    continue;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }
        }
    }
}