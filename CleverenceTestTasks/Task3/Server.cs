

namespace CleverenceTestTasks.Task3
{
    static class Server
    {
        private static int _count;
        private readonly static object _locker = new();
        private static bool _lockWasTaken = false;
        public async static Task<int> GetCount()
        {

            int result = await Task.Run(() =>
            {
                while (_lockWasTaken)
                {
                    //делаем что-нибудь пока ждем окончания записи от других пользователей, например строку ниже
                    //Console.WriteLine($"WAITNIG in thread {Thread.CurrentThread.ManagedThreadId}");
                }
                return _count;
            });
            return result;

        }

        public static void AddToCount(int value)
        {
            lock (_locker)
            {
                _lockWasTaken = true;

                //Thread.Sleep(10); какая-то условная работа при записи
                
                _count += value;
                _lockWasTaken = false;
            }
        }
    }
}
