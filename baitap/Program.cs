using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess;

namespace baitap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var emloyeer_manager = new Employeer();
            var kq = emloyeer_manager.Employeer_Insert("<img", "anh", DateTime.Now);
            switch (kq)
            {
                case (int)EmployeerEnum.THANHCONG:
                    Console.WriteLine("THANH CONG");
                    break;
                case (int)EmployeerEnum.THATBAI:
                    Console.WriteLine("THATBAI");
                    break;
                case (int)EmployeerEnum.MASV_K_HOP_LE:
                    Console.WriteLine("MASV_K_HOP_LE");
                    break;
                case (int)EmployeerEnum.TEN_K_HOP_LE:
                    Console.WriteLine("TEN_K_HOP_LE");
                    break;
            }
            var path = "C:\\Users\\Dell\\Desktop\\Book1.xlsx";
            var sr = emloyeer_manager.Employeer_Insert_FromExcelFile(path);
            Console.WriteLine(sr);

        }

    }
}
