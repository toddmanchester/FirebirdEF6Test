using FirebirdEF6Test.Model;

namespace FirebirdEF6Test
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var db = new QBOEntities())
                {
                    db.ACCOUNTS.Add(new ACCOUNT{ ID = "1", NAME = "Payable" });
                    db.SaveChanges();
                }
            }
            catch //(Exception ex)
            {
                throw;
            }
        }
    }
}