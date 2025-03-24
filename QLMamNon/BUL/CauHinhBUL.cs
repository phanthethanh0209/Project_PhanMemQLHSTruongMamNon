using DAL;
using DTO;
using System.Data;

namespace BUL
{
    public class CauHinhBUL
    {
        CauHinhDAL dal = new CauHinhDAL();

        public void Save(CauHinhDTO config)
        {
            dal.Save(config);
        }

        public DataTable GetDatabase(CauHinhDTO config)
        {
            DataTable dt = new DataTable();
            return dal.GetDatabase(config);
        }
    }
}
