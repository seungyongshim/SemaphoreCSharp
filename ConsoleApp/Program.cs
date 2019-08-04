using System;
using System.Threading;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var sema = new Semaphore(2, 2, "5C67DB0C-0EAD-4802-A2AA-88897FF437A7");

            using (var semalock = new SemaphoreLockguard.SemaphoreLockguard(sema, TimeSpan.FromSeconds(1)))
            {
                if (semalock.IsGotOne == false)
                {
                    Console.WriteLine("2개 초과의 프로그램이 실행 중입니다.");
                    return;
                }

                // 정상 실행 루틴
                Console.WriteLine("프로그램이 정상 실행되었습니다.");
                Console.ReadKey();
            }
            return;
        }
    }
}
